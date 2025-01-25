using tabuleiro;
namespace xadrez
{
    internal class Rei: Peca
    {
        public Rei(Tabuleiro tab,Cor cor) : base(tab, cor)
        {
            
        }
        public override string ToString()
        {
            return "R";
        }
        private bool PodeMover(Posicaocs Pos)
        {
            Peca P = Tab.peca(Pos);
            return P == null || P.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicaocs Pos = new Posicaocs(0,0);

            // Acima
            Pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tab.PosicaoValida(Pos) && PodeMover(Pos))
            {
                mat[Pos.Linha, Pos.Coluna] = true;
            }
            // Nordeste
            Pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(Pos) && PodeMover(Pos))
            {
                mat[Pos.Linha, Pos.Coluna] = true;
            }
            // Direita
            Pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(Pos) && PodeMover(Pos))
            {
                mat[Pos.Linha, Pos.Coluna] = true;
            }
            // Sudeste
            Pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(Pos) && PodeMover(Pos))
            {
                mat[Pos.Linha, Pos.Coluna] = true;
            }
        }
    }
}
