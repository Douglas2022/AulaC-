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
                    Tela.ImprimirTAbuleiro(Partida.Tab);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicaocs Origem = Tela.LerPosicaoXadrez().ToPosicao();
                    Console.Write("Destino: ");
                    Posicaocs Destino = Tela.LerPosicaoXadrez().ToPosicao();

                    Partida.ExecutarMovimento(Origem, Destino);

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
