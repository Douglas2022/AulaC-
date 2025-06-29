using tabuleiro;

namespace Xadrez.xadrez
{
    internal class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }
        public override string ToString()
        {
            return "P";
        }
        private bool existeInimigo(Posicaocs pos)
        {
            Peca p = Tab.peca(pos);
            return p != null && p.Cor != Cor;
        }
        private bool Livre(Posicaocs pos)
        {
            return Tab.peca(pos) == null;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicaocs pos = new Posicaocs(0, 0);

            if (Cor == Cor.Branca)
            {
                // Uma casa à frente
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // Duas casas à frente
                Posicaocs pos2 = new Posicaocs(Posicao.Linha - 2, Posicao.Coluna);
                Posicaocs pos1 = new Posicaocs(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos2) && Livre(pos2) && Livre(pos1) && QtdeMOvimentos == 0)
                {
                    mat[pos2.Linha, pos2.Coluna] = true;
                }

                // Captura à esquerda
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // Captura à direita
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            else
            {
                // Uma casa à frente
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // Duas casas à frente
                Posicaocs pos2 = new Posicaocs(Posicao.Linha + 2, Posicao.Coluna);
                Posicaocs pos1 = new Posicaocs(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos2) && Livre(pos2) && Livre(pos1) && QtdeMOvimentos == 0)
                {
                    mat[pos2.Linha, pos2.Coluna] = true;
                }

                // Captura à esquerda
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // Captura à direita
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }

            return mat;
        }

    }
}

