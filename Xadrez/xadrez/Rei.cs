using tabuleiro;

namespace xadrez
{
    internal class Rei : Peca
    {
        private PartidadeXadres partida;

        public Rei(Tabuleiro tab, Cor cor, PartidadeXadres partida) : base(tab, cor)
        {
            this.partida = partida;
            
        }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicaocs pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != Cor;
        }

        private bool testeTorrePraRoque(Posicaocs pos)
        {
            Peca p = Tab.peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QtdeMOvimentos == 0;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicaocs pos = new Posicaocs(0, 0);

            // Acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Jogada especial Roque pequeno e grande
            if (qtdeMovimentos == 0 && !partida.Xeque)
            {
                // Roque pequeno
                Posicaocs posTorre1 = new Posicaocs(Posicao.Linha, Posicao.Coluna + 3);
                if (testeTorrePraRoque(posTorre1))
                {
                    Posicaocs p1 = new Posicaocs(Posicao.Linha, Posicao.Coluna + 1);
                    Posicaocs p2 = new Posicaocs(Posicao.Linha, Posicao.Coluna + 2);
                    if (Tab.peca(p1) == null && Tab.peca(p2) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

                // Jogada especial Roque pequeno e grande
                if (qtdeMovimentos == 0 && !partida.Xeque)
                {
                    // Roque pequeno
                    Posicaocs posTorre1 = new Posicaocs(Posicao.Linha, Posicao.Coluna + 3);
                    if (testeTorrePraRoque(posTorre1))
                    {
                        Posicaocs p1 = new Posicaocs(Posicao.Linha, Posicao.Coluna + 1);
                        Posicaocs p2 = new Posicaocs(Posicao.Linha, Posicao.Coluna + 2);
                        if (Tab.peca(p1) == null && Tab.peca(p2) == null)
                        {
                            mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                        }
                    }

                    // Roque grande
                    Posicaocs posTorre2 = new Posicaocs(Posicao.Linha, Posicao.Coluna - 4);
                    if (testeTorrePraRoque(posTorre2))
                    {
                        Posicaocs p1 = new Posicaocs(Posicao.Linha, Posicao.Coluna - 1);
                        Posicaocs p2 = new Posicaocs(Posicao.Linha, Posicao.Coluna - 2);
                        Posicaocs p3 = new Posicaocs(Posicao.Linha, Posicao.Coluna - 3);
                        if (Tab.peca(p1) == null && Tab.peca(p2) == null && Tab.peca(p3) == null)
                        {
                            mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                        }
                    }
                }

                return mat;
            }
