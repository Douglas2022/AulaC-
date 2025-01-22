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
     

                Tela.ImprimirTAbuleiro(Partida.Tab);

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
