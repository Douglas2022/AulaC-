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
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicaocs(0, 0));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicaocs(1, 3));
                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicaocs(0,2));

                Tela.ImprimirTAbuleiro(tab);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }
    }
}
