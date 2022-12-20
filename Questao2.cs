using System;

namespace Questoes123
{
    internal class Questao2
    {
        static void Main(string[] args)
        {
            bool conversao = true;
            string caminhoDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string caminhoMatriz = Path.Combine(caminhoDesktop, "matriz.txt");
            string caminhoCaminho = Path.Combine(caminhoDesktop, "caminho.txt");
            string matriz = System.IO.File.ReadAllText(caminhoMatriz);
            string caminho = System.IO.File.ReadAllText(caminhoCaminho);
            string[] submatriz = matriz.Split('\n');
            int i = submatriz.Length;
            int[,] submatriz2 = new int[i, i];
            for (int j = 0; j < i; j++)
            {
                string[] subaux = submatriz[j].Split(',');
                if (subaux.Length != i)
                {
                    Console.WriteLine("A matriz não é quadrada.");
                    return;
                }
                for (int k = 0; k < i; k++)
                {
                    conversao = int.TryParse(subaux[k], out submatriz2[j, k]);
                    if (!conversao || submatriz2[j, k] < 0 || (j != k && submatriz2[j, k] == 0) || (j == k && submatriz2[j, k] != 0))
                    {
                        Console.WriteLine("Há uma distância inválida na matriz.");
                        return;
                    }
                }  
            }
            string[] subcaminho = caminho.Split(',');
            int n = subcaminho.Length;
            int[] subcaminho2 = new int[n];
            for (int l = 0; l < n; l++)
            {
                conversao = int.TryParse(subcaminho[l], out subcaminho2[l]);
                if (!conversao || subcaminho2[l] <= 0 || subcaminho2[l] > i)
                {
                    Console.WriteLine("Há uma cidade inválida no caminho.");
                    return;
                }
            }
            int distanciaTotal = 0;
            for (int m = 0; m < n - 1; m++)
                distanciaTotal += submatriz2[subcaminho2[m] - 1, subcaminho2[m + 1] - 1];
            Console.WriteLine($"A distância total do percurso é {distanciaTotal} km.");
        }
    }
}
