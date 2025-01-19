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
                Tabuleiro Tab = new Tabuleiro(8,8);

                Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new Posicaocs(0, 0));
                Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new Posicaocs(1, 3));
                Tab.ColocarPeca(new Rei(Tab, Cor.Preta), new Posicaocs(0, 2));

                Tela.ImprimirTAbuleiro(Tab);

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
