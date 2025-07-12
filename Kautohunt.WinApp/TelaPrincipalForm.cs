using System;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Kautohunt.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
        private List<ClientDTO> clients;
        public static string pastaDeMapas;
        public static string pastaDeZipMap;
        private static string pastaDoScript;

        public TelaPrincipalForm()
        {
            InitializeComponent();
            InitializeAsync();
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
            clients = new List<ClientDTO>();

            try
            {
                string remoteServersRaw = await httpClient.GetStringAsync("https://storage.googleapis.com/4rtools/supported_servers.json");
                clients.AddRange(JsonConvert.DeserializeObject<List<ClientDTO>>(remoteServersRaw));

            }
            finally
            {
                foreach (ClientDTO clientDTO in clients)
                    ClientListSingleton.AddClient(new Client(clientDTO));
            }
        }

        private CancellationTokenSource _monitorHpCTS;

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

                pastaDoScript = Path.GetDirectoryName(FileFolder.FileName);

                pastaDeZipMap = Path.Combine(pastaDoScript, "assets", "zimap");

                pastaDeMapas = Path.Combine(pastaDoScript, "assets", "Maps");
            }

            foreach (var map in MapLoader.ListarMapas(pastaDeZipMap))
            {
                cmbMapa.Items.Add(map);
            }

        }

        private void cmbMapa_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkListMobs.Items.Clear();

            string mapaSelecionado = '/' + cmbMapa.SelectedItem.ToString();

            foreach (var mob in MapLoader.ListarMobs(pastaDeMapas, mapaSelecionado))
            {
                chkListMobs.Items.Add(mob);
            }
        }
    }
}
