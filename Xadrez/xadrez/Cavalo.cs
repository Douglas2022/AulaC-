using tabuleiro;

namespace Xadrez.xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }
        public override string ToString()
        {
            return "C";
        }
        private bool podeMover(Posicaocs pos)
        {
            Peca P = Tab.peca(pos);
            return P == null || P.Cor != Cor;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicaocs pos = new Posicaocs(0, 0);

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            return mat;


        }

    }
}

