using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RPGConsole
{
    internal static class LoreReader
    {
        private static readonly object LockObj = new object();
        private static Dictionary<string, string> _lore = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private static bool _inicializado;

        public static void Inicializar(string caminhoArquivo)
        {
            if (string.IsNullOrWhiteSpace(caminhoArquivo))
            {
                throw new ArgumentException("Informe um caminho de arquivo válido.", nameof(caminhoArquivo));
            }

            string caminhoCompleto = Path.IsPathRooted(caminhoArquivo)
                ? caminhoArquivo
                : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, caminhoArquivo);

            if (!File.Exists(caminhoCompleto))
            {
                throw new FileNotFoundException($"Arquivo de lore não encontrado: {caminhoCompleto}");
            }

            var resultado = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            string chaveAtual = null;
            StringBuilder buffer = new StringBuilder();

            foreach (string linhaOriginal in File.ReadAllLines(caminhoCompleto, Encoding.UTF8))
            {
                string linha = linhaOriginal ?? string.Empty;
                string linhaTrim = linha.Trim();

                if (linhaTrim.StartsWith("[") && linhaTrim.EndsWith("]") && linhaTrim.Length > 2)
                {
                    SalvarBlocoSeNecessario(resultado, chaveAtual, buffer);
                    chaveAtual = linhaTrim.Substring(1, linhaTrim.Length - 2).Trim();
                    buffer.Clear();
                    continue;
                }

                if (string.IsNullOrEmpty(chaveAtual))
                {
                    if (string.IsNullOrWhiteSpace(linha))
                    {
                        continue;
                    }

                    throw new FormatException("Formato inválido em lore.txt. Texto encontrado antes de uma chave [CHAVE].");
                }

                if (buffer.Length > 0)
                {
                    buffer.AppendLine();
                }

                buffer.Append(linha);
            }

            SalvarBlocoSeNecessario(resultado, chaveAtual, buffer);

            lock (LockObj)
            {
                _lore = resultado;
                _inicializado = true;
            }
        }

        public static string Obter(string chave)
        {
            if (string.IsNullOrWhiteSpace(chave))
            {
                throw new ArgumentException("Informe uma chave válida.", nameof(chave));
            }

            Dictionary<string, string> loreAtual;
            bool inicializado;

            lock (LockObj)
            {
                loreAtual = _lore;
                inicializado = _inicializado;
            }

            if (!inicializado)
            {
                throw new InvalidOperationException("LoreReader não foi inicializado. Chame LoreReader.Inicializar(\"lore.txt\").");
            }

            if (!loreAtual.TryGetValue(chave, out string valor))
            {
                throw new KeyNotFoundException($"Chave de lore não encontrada: {chave}");
            }

            return valor;
        }

        private static void SalvarBlocoSeNecessario(Dictionary<string, string> destino, string chave, StringBuilder buffer)
        {
            if (string.IsNullOrWhiteSpace(chave))
            {
                return;
            }

            if (destino.ContainsKey(chave))
            {
                throw new FormatException($"Chave duplicada no arquivo de lore: [{chave}]");
            }

            destino[chave] = buffer.ToString().Trim();
        }
    }
}
