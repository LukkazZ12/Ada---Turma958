using System.Formats.Asn1;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace Questoes123
{
    internal class Questao3
    {
        static void Main(string[] args)
        {
            bool conversao = true;
            bool leitura;
            string[] linha = { "0" };
            string caminhoDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var caminhoMatriz = new FileInfo(Path.Combine(caminhoDesktop, "matriz.txt"));
            var caminhoCaminho = new FileInfo(Path.Combine(caminhoDesktop, "caminho.txt"));
            if (!caminhoMatriz.Exists || !caminhoCaminho.Exists)
            {
                Console.WriteLine("O arquivo matrix.txt ou caminho.txt não existe no Desktop.");
                return;
            }
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using var reader = new StreamReader(caminhoMatriz.FullName);
            using var csv = new CsvParser(reader, config);
            leitura = csv.Read();
            if (!leitura)
            {
                Console.WriteLine("Não foi possível ler o arquivo matriz.txt.");
                return;
            }
            int quantidade = csv.Record.Length;
            if (quantidade <= 1)
            {
                Console.WriteLine("A quantidade de cidades é inválida.");
                return;
            }
            int[,] distancias = new int[quantidade, quantidade];
            for (int i = 0; i < quantidade; i++)
            {
                if (leitura)
                    linha = csv.Record;
                if (linha.Length != quantidade || !leitura)
                {
                    Console.WriteLine("A matriz não é quadrada.");
                    return;
                }
                for (int j = 0; j < quantidade; j++)
                {
                    conversao = int.TryParse(linha[j], out distancias[i, j]);
                    if (!conversao || distancias[i, j] < 0 || (i != j && distancias[i, j] == 0) || (i == j && distancias[i, j] != 0))
                    {
                        Console.WriteLine("Há uma distância inválida na matriz.");
                        return;
                    }
                }
                leitura = csv.Read();
                if (leitura && i == quantidade - 1)
                {
                    Console.WriteLine("A matriz não é quadrada.");
                    return;
                }
            }
            using var reader2 = new StreamReader(caminhoCaminho.FullName);
            using var csv2 = new CsvParser(reader2, config);
            leitura = csv2.Read();
            if (!leitura)
            {
                Console.WriteLine("Não foi possível ler o arquivo caminho.txt.");
                return;
            }
            int quantidade2 = csv2.Record.Length;
            int[] caminho = new int[quantidade2];
            var percurso = csv2.Record;
            for (int i = 0; i < quantidade2; i++)
            {
                int.TryParse(percurso[i], out caminho[i]);
                if (caminho[i] <= 0 || caminho[i] > quantidade)
                {
                    Console.WriteLine("Há uma cidade inválida no caminho.");
                    return;
                }
            }
            int distanciaTotal = 0;
            for (int i = 0; i < caminho.Length - 1; i++)
                distanciaTotal += distancias[caminho[i] - 1, caminho[i + 1] - 1];
            Console.WriteLine($"A distância total do percurso é {distanciaTotal} km.");
        }
    }
}
