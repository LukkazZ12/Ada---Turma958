using System;

namespace Questoes123
{
    internal class Questao2
    {
        static void Mainddd(string[] args)
        {
            bool conversao = true;
            string caminhoDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var caminhoMatriz = new FileInfo(Path.Combine(caminhoDesktop, "matriz.txt"));
            var caminhoCaminho = new FileInfo(Path.Combine(caminhoDesktop, "caminho.txt"));
            if (!caminhoMatriz.Exists || !caminhoCaminho.Exists)
            {
                Console.WriteLine("O arquivo matrix.txt ou caminho.txt não existe no Desktop.");
                return;
            }
            string matriz = System.IO.File.ReadAllText(caminhoMatriz.FullName);
            string caminho = System.IO.File.ReadAllText(caminhoCaminho.FullName);
            if (matriz == "" || caminho == "")
            {
                Console.WriteLine("Não foi possível ler o arquivo matriz.txt ou caminho.txt.");
                return;
            }
            string[] submatriz = matriz.Split(Environment.NewLine);
            if (submatriz.Length <= 1)
            {
                Console.WriteLine("A quantidade de cidades é inválida.");
                return;
            }
            int[,] submatriz2 = new int[submatriz.Length, submatriz.Length];
            for (int i = 0; i < submatriz.Length; i++)
            {
                string[] subaux = submatriz[i].Split(',');
                if (subaux.Length != submatriz.Length)
                {
                    Console.WriteLine("A matriz não é quadrada.");
                    return;
                }
                for (int j = 0; j < submatriz.Length; j++)
                {
                    conversao = int.TryParse(subaux[j], out submatriz2[i, j]);
                    if (!conversao || submatriz2[i, j] < 0 || (i != j && submatriz2[i, j] == 0) || (i == j && submatriz2[i, j] != 0))
                    {
                        Console.WriteLine("Há uma distância inválida na matriz.");
                        return;
                    }
                }
            }
            string[] subcaminho = caminho.Split(',');
            int[] subcaminho2 = new int[subcaminho.Length];
            for (int i = 0; i < subcaminho.Length; i++)
            {
                int.TryParse(subcaminho[i], out subcaminho2[i]);
                if (subcaminho2[i] <= 0 || subcaminho2[i] > submatriz.Length)
                {
                    Console.WriteLine("Há uma cidade inválida no caminho.");
                    return;
                }
            }
            int distanciaTotal = 0;
            for (int i = 0; i < subcaminho.Length - 1; i++)
                distanciaTotal += submatriz2[subcaminho2[i] - 1, subcaminho2[i + 1] - 1];
            Console.WriteLine($"A distância total do percurso é {distanciaTotal} km.");
        }
    }
}
