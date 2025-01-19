using System;
using tabuleiro;
using xadrez;
namespace Xadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PosicaoXadrez Pos = new PosicaoXadrez('c',7);

            Console.WriteLine(Pos);
            Console.WriteLine(Pos.ToPosicao());

            Console.ReadLine();

        }
    }
}
