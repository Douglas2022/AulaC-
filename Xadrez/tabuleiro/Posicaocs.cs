﻿
namespace tabuleiro
{
    internal class Posicaocs
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posicaocs(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }
        public void DefinirValores(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public override string ToString()
        {
            return Linha
                + ", "
                + Coluna;
        }
    }
}
