using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO.Compression;

namespace Kautohunt.WinApp
{
    public class MapLoader
    {
        public static List<string> ListarMapas(string path)
        {
            List<string> mapas = new List<string>();
            try
            {
                var arquivos = Directory.GetFiles(path, "*.zip");

                if (Directory.Exists(path))
                {
                    foreach (var arquivo in arquivos)
                    {
                        var arquivoZipNome = Path.GetFileName(arquivo);

                        var mapaNome = arquivoZipNome.Split(new string[] { ".zip" }, StringSplitOptions.None)[0];

                        mapas.Add(mapaNome);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar mapas: " + ex.Message);

            }

            return mapas;
        }

        public (string modelo, string nomes) CarregarMapa(string PathZip, string dest)
        {
            string nomeBase = Path.GetFileNameWithoutExtension(PathZip);

            Directory.CreateDirectory(dest);

            string modeloDestino = Path.Combine(dest, $"{nomeBase}.h5");

            string nomesDestino = Path.Combine(dest, $"{nomeBase}.txt");

            if (modeloDestino == ".h5" || nomesDestino == ".txt")
                return (null, null);
            try
            {
                using (ZipArchive zip = ZipFile.OpenRead(PathZip))
                {
                    foreach (ZipArchiveEntry entry in zip.Entries)
                    {
                        if (!File.Exists(modeloDestino) && !File.Exists(nomesDestino))

                            if (entry.FullName == "keras_model.h5")
                            {
                                entry.ExtractToFile(modeloDestino, overwrite: true);
                            }
                        if (entry.FullName == "labels.txt")
                        {
                            entry.ExtractToFile(nomesDestino, overwrite: true);
                        }
                        else
                            continue;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar mapa: " + ex.Message);
            }

            return (modeloDestino, nomesDestino);
        }

        public static List<string> ListarMobs(string path, string nomeDoArquivo)
        {
            List<string> mobs = new List<string>();

            try
            {
                string[] linhas = File.ReadAllLines(path + nomeDoArquivo + ".txt");

                foreach (string linha in linhas)
                {
                    var nomeCompleto = linha.Split(new[] { ' ' }, 2);
                    if (nomeCompleto.Length == 2)

                        mobs.Add(nomeCompleto[1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar mobs: " + ex.Message);
            }

            return mobs;
        }

    }
}
