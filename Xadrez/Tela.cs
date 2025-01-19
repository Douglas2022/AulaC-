using System;
using tabuleiro;

namespace Xadrez
{
    internal class Tela
    {
        public static void ImprimirTAbuleiro(Tabuleiro Tab)
        {
            for (int i = 0; i < Tab.Linhas; i++)
            {
                Console.Write(8 -  i + " ");
                for (int j = 0; j < Tab.Colunas; j++)
                {
                    if (Tab.peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(Tab.peca(i, j) + " ");
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine(" a b c d e f g h");
        }

        
    }
}
