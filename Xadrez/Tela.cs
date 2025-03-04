using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace Xadrez
{
    internal class Tela
    {
        public static void imprimirPartida(PartidadeXadres Partida)
        {
            ImprimirTabuleiro(Partida.Tab);
            Console.WriteLine();
            imprimirPecasCapturadas(Partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + Partida.Turno);
            Console.WriteLine("Aguardando jogada: " + Partida.JogadorAtual);
        }
        public static void imprimirPecasCapturadas(PartidadeXadres Partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Peças brancas: ");
            imprimirConjuntos(Partida.pecasCapturadas(Cor.Branca));

            Console.WriteLine();

            //Console.WriteLine("Peças capturadas: ");
            Console.Write("Peças pretas: ");
            imprimirConjuntos(Partida.pecasCapturadas(Cor.Preta));
        }
        public static void imprimirConjuntos(HashSet<Peca> Conjunto)
        {
            Console.Write("[");
            foreach (Peca x in Conjunto)
            {
                Console.Write( x + " ");
            }
            Console.Write("}");
        }
        public static void ImprimirTabuleiro(Tabuleiro Tab)
        {
            for (int i = 0; i < Tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < Tab.Colunas; j++)
                {
                    ImprimirPeca(Tab.peca(i, j));

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void ImprimirTabuleiro(Tabuleiro Tab, bool[,] PosicoesPossiveis)
        {
            ConsoleColor FundoOriginal = Console.BackgroundColor;
            ConsoleColor FundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < Tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");


                for (int j = 0; j < Tab.Colunas; j++)
                {
                    if (PosicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = FundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = FundoOriginal;
                    }
                    ImprimirPeca(Tab.peca(i, j));
                    Console.BackgroundColor = FundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = FundoOriginal;
        }
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            var coluna = s[0];
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
                Console.Write(" ");
            }

        }
    }

}

