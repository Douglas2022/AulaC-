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
                    Console.Clear();
                    Tela.imprimirPartida(Partida);
                    Console.WriteLine();
                    Console.WriteLine("Turno: " + Partida.Turno);
                    Console.WriteLine("Aguardando jogada: " + Partida.JogadorAtual);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicaocs Origem = Tela.LerPosicaoXadrez().ToPosicao();
                    Partida.ValidarPosicaoDeOrigem(Origem);

                    bool[,] posicoesPossiveis = Partida.Tab.peca(Origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(Partida.Tab, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicaocs Destino = Tela.LerPosicaoXadrez().ToPosicao();
                    Partida.ValidarPosicaoDeDestino(Origem, Destino);

                    Partida.RealizaJogada(Origem, Destino);

                }

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

            

        }


    }
          
    

}




