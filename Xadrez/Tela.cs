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
                        Tela.ImprimirPeca(Tab.peca(i, j));
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void ImprimirPeca(Peca peca)
        {
            if( peca.Cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
        
    }
}
