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
                    Tela.ImprimirTabuleiro(Partida.Tab);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicaocs Origem = Tela.LerPosicaoXadrez().ToPosicao();
                    Console.Clear();

                    bool[,] PosicaoPossivel = Partida.Tab.peca(Origem).MovimentosPossiveis();
                    Tela.ImprimirTabuleiro(Partida.Tab, PosicaoPossivel);


                    Console.Write("Destino: ");
                    Posicaocs Destino = Tela.LerPosicaoXadrez().ToPosicao();

                    Partida.ExecutarMovimento(Origem, Destino);

                }

           /s }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
  dd      }
    }
}
