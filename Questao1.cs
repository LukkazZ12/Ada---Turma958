using System;

namespace Questoes123
{
    internal class Questao1
    {
        static void Main(string[] args)
        {
            Console.Write("Este programa recebe do usuário uma tabela com as distâncias (inteiro em km maior que zero) " +
                "entre uma quantidade de cidades. Então o usuário fornece um percurso com a ordem das cidades a serem visitadas, " +
                "e o programa retorna a distância a ser percorrida." +
                "\nPara começar, digite a quantidade de cidades (inteiro maior que um): ");
            int quantidade = 0;
            while (quantidade <= 1)
            {
                int.TryParse(Console.ReadLine(), out quantidade);
                if (quantidade > 1)
                    break;
                Console.Write("\nVocê digitou uma quantidade inválida." +
                    "\nPor favor, digite a quantidade de cidades (inteiro maior que zero): ");
            }
            int[,] distancias = new int[quantidade, quantidade];
            Console.Write("\n");
            for (int i = 0; i < quantidade; i++)
                for (int j = i + 1; j < quantidade; j++)
                {
                    Console.Write($"Digite a distância (inteiro maior que zero) entre as cidades {i + 1} e {j + 1}: ");
                    while (distancias[i, j] <= 0)
                    {
                        int.TryParse(Console.ReadLine(), out distancias[i, j]);
                        if (distancias[i, j] > 0)
                        {
                            distancias[j, i] = distancias[i, j];
                            break;
                        }
                        Console.Write("\nVocê digitou uma distância inválida." +
                            $"\nPor favor, digite a distância (inteiro maior que zero) entre as cidades {i + 1} e {j + 1}: ");
                    }
                }
            Console.Write("\nDigite a quantidade de cidades (inteiro maior que um) que tem no percurso desejado: ");
            int quantCidades = 0;
            while (quantCidades <= 1)
            {
                int.TryParse(Console.ReadLine(), out quantCidades);
                if (quantCidades > 1)
                    break;
                Console.Write("\nVocê digitou uma quantidade inválida." +
                    $"\nPor favor, digite a quantidade de cidades (inteiro maior que zero) que tem no percurso desejado: ");
            }
            int[] percurso = new int[quantCidades];
            Console.Write("\n");
            for (int k = 0; k < quantCidades; k++)
            {
                Console.Write($"Digite, um por vez, os números (inteiro maior que zero e menor que {quantidade + 1}) " +
                    $"das {quantCidades} cidades do percurso: ");
                while (percurso[k] <= 0 || percurso[k] > quantidade)
                {
                    int.TryParse(Console.ReadLine(), out percurso[k]);
                    if (percurso[k] > 0 && percurso[k] <= quantidade)
                        break;
                    Console.Write("\nVocê digitou um número inválido." +
                        "\nPor favor, digite, um por vez, os números (inteiro maior que zero) das cidades do percurso: ");
                }
            }
            int distanciaTotal = 0;
            for (int l = 0; l < quantCidades - 1; l++)
                distanciaTotal += distancias[percurso[l] - 1, percurso[l + 1] - 1];
            Console.WriteLine($"\nA distância total do percurso é {distanciaTotal} km.");
        }
    }
}
