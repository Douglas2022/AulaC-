using System;
using tabuleiro;
using xadrez;
namespace Xadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidadeXadres Partida = new PartidadeXadres();

                while (!Partida.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(Partida.Tab);
                        Console.WriteLine("Turno: " + Partida.Turno);
                        Console.WriteLine("Aguardando jogada: " + Partida.JogadorAtual);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicaocs Origem = Tela.LerPosicaoXadrez().ToPosicao();
                        Partida.ValidarPosicaoDeOrigem(Origem);


                        bool[,] PosicaoPossivel = Partida.Tab.peca(Origem).MovimentosPossiveis();


                        Console.Clear();
                        Tela.ImprimirTabuleiro(Partida.Tab, PosicaoPossivel);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicaocs Destino = Tela.LerPosicaoXadrez().ToPosicao();

                        Partida.RealizaJogada(Origem, Destino);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
               
                }

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
