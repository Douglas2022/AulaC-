using tabuleiro;
using xadrez;

namespace Xadrez.xadrez
{
    internal class Peao : Peca
    {
        private PartidadeXadres partidade;
        public Peao(Tabuleiro tab, Cor cor,PartidadeXadres partidade) : base(tab, cor)
        {
            this.partidade = partidade;     .
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
                pos.DefinirValores(Posicao.Linha -2,Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && Livre(pos) && QtdeMOvimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
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
                // #Jogada en passant
                if(Posicao.Linha == 3)
                {
                   Posicaocs esquerda = new Posicaocs(Posicao.Linha,Posicao.Coluna -1);
                    if(Tab.PosicaoValida(esquerda) &&  existeInimigo(esquerda) && Tab.peca(esquerda) == partidade.vuneravelEnPassant){
                        mat[esquerda.Linha, esquerda.Coluna] = true;
                    }
                    Posicaocs direita = new Posicaocs(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && existeInimigo(direita) && Tab.peca(direita) == partidade.vuneravelEnPassant)
                    {
                        mat[direita.Linha, direita.Coluna] = true;
                    }
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

                pos.DefinirValores(Posicao.Linha +2,Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && Livre(pos) && QtdeMOvimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
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
                // #Jogada en passant
                if (Posicao.Linha == 4)
                {
                    Posicaocs esquerda = new Posicaocs(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && existeInimigo(esquerda) && Tab.peca(esquerda) == partidade.vuneravelEnPassant)
                    {
                        mat[esquerda.Linha, esquerda.Coluna] = true;
                    }
                    Posicaocs direita = new Posicaocs(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && existeInimigo(direita) && Tab.peca(direita) == partidade.vuneravelEnPassant)
                    {
                        mat[direita.Linha, direita.Coluna] = true;
                    }
                }
            }

            return mat;
        }

    }
}

