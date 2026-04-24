using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace RPGConsole
{
    internal class SaveInfo
    {
        public string NomeArquivo;
        public string NomePersonagem;
    }

    internal static class PersonagemStorage
    {
        private static string PastaSave
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }

        public static bool ExisteSave()
        {
            return ListarSaves().Count > 0;
        }

        public static void Salvar(Personagem personagem)
        {
            if (personagem == null)
            {
                throw new ArgumentNullException(nameof(personagem));
            }

            string nomeArquivo = MontarNomeArquivo(personagem.nome);
            string caminho = Path.Combine(PastaSave, nomeArquivo);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(personagem);
            File.WriteAllText(caminho, json, Encoding.UTF8);
        }

        public static List<SaveInfo> ListarSaves()
        {
            var lista = new List<SaveInfo>();
            var serializer = new JavaScriptSerializer();

            foreach (string arquivo in Directory.GetFiles(PastaSave, "*.json"))
            {
                try
                {
                    string json = File.ReadAllText(arquivo, Encoding.UTF8);
                    Personagem personagem = serializer.Deserialize<Personagem>(json);
                    if (personagem == null)
                    {
                        continue;
                    }

                    lista.Add(new SaveInfo
                    {
                        NomeArquivo = Path.GetFileName(arquivo),
                        NomePersonagem = string.IsNullOrWhiteSpace(personagem.nome) ? "(Sem nome)" : personagem.nome
                    });
                }
                catch
                {
                    // Ignora arquivos JSON que não são saves válidos.
                }
            }

            return lista
                .OrderBy(s => s.NomePersonagem, StringComparer.OrdinalIgnoreCase)
                .ThenBy(s => s.NomeArquivo, StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        public static Personagem Carregar(string nomeArquivo)
        {
            if (string.IsNullOrWhiteSpace(nomeArquivo))
            {
                throw new ArgumentException("Informe um arquivo de save válido.", nameof(nomeArquivo));
            }

            string caminho = Path.Combine(PastaSave, nomeArquivo);
            if (!File.Exists(caminho))
            {
                throw new FileNotFoundException($"Arquivo de personagem não encontrado: {caminho}");
            }

            string json = File.ReadAllText(caminho, Encoding.UTF8);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Personagem personagem = serializer.Deserialize<Personagem>(json);

            if (personagem == null)
            {
                throw new InvalidOperationException("Não foi possível carregar os dados do personagem.");
            }

            if (personagem.bag == null)
            {
                personagem.bag = new List<Itens>();
            }

            if (personagem.parteAtual <= 0)
            {
                personagem.parteAtual = 1;
            }

            if (string.IsNullOrWhiteSpace(personagem.localAtual))
            {
                if (personagem.parteAtual <= 1)
                    personagem.localAtual = "TAVERNA";
                else if (personagem.parteAtual <= 2)
                    personagem.localAtual = "FLORESTA";
                else if (personagem.parteAtual <= 3)
                    personagem.localAtual = "RUINAS";
                else if (personagem.parteAtual <= 4)
                    personagem.localAtual = "CATACUMBAS";
                else if (personagem.parteAtual <= 5)
                    personagem.localAtual = "TORRE";
                else if (personagem.parteAtual <= 6)
                    personagem.localAtual = "PORTO";
                else
                    personagem.localAtual = "CIDADELA";
            }

            return personagem;
        }

        private static string MontarNomeArquivo(string nomePersonagem)
        {
            string nomeBase = string.IsNullOrWhiteSpace(nomePersonagem) ? "Personagem" : nomePersonagem.Trim();
            foreach (char invalido in Path.GetInvalidFileNameChars())
            {
                nomeBase = nomeBase.Replace(invalido, '_');
            }

            return $"{nomeBase}.json";
        }
    }
}
