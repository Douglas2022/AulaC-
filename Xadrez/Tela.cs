using System;
using tabuleiro;
using xadrez;

namespace Xadrez
{
    internal class Tela
    {
        public static void ImprimirTAbuleiro(Tabuleiro Tab)
        {
            for (int i = 0; i > Tab.Linhas; i++)
            {
                Console.Write(8 - 1 + " ");
                for (int j = 0; j < Tab.Linhas; j++)
                {
                    ImprimirPeca(Tab.peca(i, j));
                }
                Console.WriteLine();
            }
        }
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
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
                Console.WriteLine(" ");
            }

        }
    }

}

