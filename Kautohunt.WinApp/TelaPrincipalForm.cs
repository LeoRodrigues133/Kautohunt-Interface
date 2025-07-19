using System;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using Python.Runtime;
using System.Linq;
namespace Kautohunt.WinApp
{


    public partial class TelaPrincipalForm : Form
    {
        public System.Windows.Forms.Timer logTimer;
        public System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
        public List<ClientDTO> _clients;
        public string[] _mobsAlvo;
        public static string _pastaDeMapas;
        public static string _pastaDeZipMap;
        public static string _pastaDoScript;
        public static string _mapaSelecionado;
        public static string _mobsDetectaveis;
        public CancellationTokenSource _monitorHpCTS;

        public dynamic _script;

        public TelaPrincipalForm()
        {
            InitializeComponent();

            logTimer = new System.Windows.Forms.Timer();
            logTimer.Interval = 500; // ms
            logTimer.Tick += LogTimer_Tick;
            logTimer.Start();

            InitializeAsync();

            Runtime.PythonDLL = @"C:\Users\Leo_Rodrigues\AppData\Local\Programs\Python\Python310\python310.dll"; // <-- aqui cola o caminha do seu python 
            PythonEngine.PythonHome = @"C:\Users\Leo_Rodrigues\AppData\Local\Programs\Python\Python310";         //      --> deve utilizar o 3.10 <--

            string pythonPath = string.Join(";", new[]
            {
                    $"{_pastaDoScript}\\Py310\\Lib",
                    $"{_pastaDoScript}\\Py310\\Lib\\site-packages",
                    $"{_pastaDoScript}"
                });
            Environment.SetEnvironmentVariable("PYTHONPATH", pythonPath);

            PythonEngine.Initialize();
            PythonEngine.BeginAllowThreads();
        }

        private void LogTimer_Tick(object sender, EventArgs e)
        {
            using (Py.GIL())
            {
                dynamic sys = Py.Import("sys");
                sys.path.append(_pastaDoScript);

                dynamic redirector_module = Py.Import("Utils.output_redirector");
                dynamic redirector = redirector_module.redirector;

                var messages = redirector.messages;

                foreach (var msg in messages)
                {
                    rtxLog.AppendText(msg.ToString());
                }

                redirector.messages.clear();
            }
            rtxLog.SelectionStart = rtxLog.Text.Length;
            rtxLog.ScrollToCaret();
        }

        private async void InitializeAsync()
        {
            await StartUpdate();
            CarregarProcessos();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.cmbProcessos.Items.Clear();
            });
            CarregarProcessos();
        }

        private void CarregarProcessos()
        {
            foreach (Process p in Process.GetProcesses())
                if (p.MainWindowTitle != "" && ClientListSingleton.ExistsByProcessName(p.ProcessName))
                {
                    this.cmbProcessos.Items.Add(string.Format("{0}.exe - {1}", p.ProcessName, p.Id));
                }
        }

        private void cmbProcessos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Client client = new Client(this.cmbProcessos.SelectedItem.ToString());
            ClientSingleton.Instance(client);

            Update();
        }

        public void Update()
        {
            Client client = ClientSingleton.GetClient();
            if (client != null)
            {
                this.lblNomeChar.Text = client.ReadCharacterName();

                this.lblHpChar.Text = client.ReadCurrentHp().ToString();
                this.lblMaxHpChar.Text = client.ReadMaxHp().ToString();

                this.lblSpChar.Text = client.ReadCurrentSp().ToString();
                this.lblMaxSpChar.Text = client.ReadMaxSp().ToString();

                VerificarHp();
            }
        }



        private async Task StartUpdate()
        {
            _clients = new List<ClientDTO>();

            try
            {
                string remoteServersRaw = await httpClient.GetStringAsync("https://storage.googleapis.com/4rtools/supported_servers.json");
                _clients.AddRange(JsonConvert.DeserializeObject<List<ClientDTO>>(remoteServersRaw));

            }
            finally
            {
                foreach (ClientDTO clientDTO in _clients)
                    ClientListSingleton.AddClient(new Client(clientDTO));
            }
        }


        public void VerificarHp()
        {
            if (_monitorHpCTS != null)
            {
                _monitorHpCTS.Cancel();
                _monitorHpCTS.Dispose();
            }

            Client client = ClientSingleton.GetClient();

            if (client != null)
            {
                _monitorHpCTS = new CancellationTokenSource();
                CancellationToken token = _monitorHpCTS.Token;

                MonitorarHpAsync(client, token);
            }
        }

        private async Task MonitorarHpAsync(Client client, CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    uint hpAtual = client.ReadCurrentHp();
                    uint hpMaximo = client.ReadMaxHp();
                    uint spAtual = client.ReadCurrentSp();
                    uint spMaximo = client.ReadMaxSp();

                    if (this.lblHpChar.InvokeRequired)

                        this.lblHpChar.Invoke((MethodInvoker)delegate
                        {
                            this.lblHpChar.Text = hpAtual.ToString();
                            this.lblMaxHpChar.Text = hpMaximo.ToString();
                            this.lblSpChar.Text = spAtual.ToString();
                            this.lblMaxSpChar.Text = spMaximo.ToString();
                        });

                    else
                    {
                        this.lblHpChar.Text = hpAtual.ToString();
                        this.lblMaxHpChar.Text = hpMaximo.ToString();
                        this.lblSpChar.Text = spAtual.ToString();
                        this.lblMaxSpChar.Text = spMaximo.ToString();
                    }
                    await Task.Delay(200, token);
                }
            }
            catch (TaskCanceledException) { }
        }



        private void btnSelecionarPasta_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileFolder = new OpenFileDialog();
            FileFolder.CheckFileExists = false;
            FileFolder.FileName = "Pasta Selecionada";

            if (FileFolder.ShowDialog() == DialogResult.OK)
            {
                cmbMapa.Items.Clear();

                _pastaDoScript = Path.GetDirectoryName(FileFolder.FileName);

                _pastaDeZipMap = Path.Combine(_pastaDoScript, "assets", "Zimap");

                _pastaDeMapas = Path.Combine(_pastaDoScript, "assets", "Maps");
            }

            foreach (var map in MapLoader.ListarMapas(_pastaDeZipMap))
            {
                cmbMapa.Items.Add(map);
            }

        }

        private void cmbMapa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mapaSelecionado = $"/{cmbMapa.SelectedItem.ToString()}";

            chkListMobs.Items.Clear();

            var bag = MapLoader.CarregarMapa(_pastaDeZipMap, mapaSelecionado, _pastaDeMapas);

            _mapaSelecionado = bag.modelo;
            _mobsDetectaveis = bag.nomes;

            foreach (var mob in MapLoader.ListarMobs(_pastaDeMapas, mapaSelecionado))
            {
                chkListMobs.Items.Add(mob);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            _mobsAlvo = new string[0];

            foreach (string mob in chkListMobs.CheckedItems)
            {
                if (!listCacando.Items.Contains(mob))
                    listCacando.Items.Add(mob);

                Array.Resize(ref _mobsAlvo, _mobsAlvo.Length + 1);
                _mobsAlvo[_mobsAlvo.Length - 1] = mob;
            }

            using (Py.GIL())
            {
                dynamic sys = Py.Import("sys");
                sys.path.append(_pastaDoScript);

                dynamic settings_module = Py.Import("config.settings");
                dynamic settings = settings_module.settings;

                settings.CarregarCaminhos(model: _mapaSelecionado, arquivoDeMobs: _mobsDetectaveis, mobsAlvo: _mobsAlvo.ToList());
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            foreach (string mob in chkListMobs.CheckedItems)
            {
                listCacando.Items.Remove(mob);
            }
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {

            await Task.Run(() =>
            {
                using (Py.GIL())
                {
                    dynamic sys = Py.Import("sys");
                    sys.path.append(_pastaDoScript);

                    dynamic main = Py.Import("src.main");

                    main.iniciar_programa();

                }
            });
        }

    }
}
