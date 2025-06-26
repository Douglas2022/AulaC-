using tabuleiro;
namespace xadrez
{
    internal class Rei : Peca
    {
        private PartidadeXadres partida;
        public Rei(Tabuleiro tab, Cor cor,PartidadeXadres partida) : base(tab, cor)
        {
            this.partida = partida;
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
        private bool testePraRoque(Posicaocs pos)
        {
            Peca p = Tab.peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QtdeMOvimentos == 0;
        }
           
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicaocs Pos = new Posicaocs(0, 0);

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
            // Abaixo
            Pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.PosicaoValida(Pos) && PodeMover(Pos))
            {
                mat[Pos.Linha, Pos.Coluna] = true;
            }
            // Sudoeste
            Pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(Pos) && PodeMover(Pos))
            {
                mat[Pos.Linha, Pos.Coluna] = true;
            }
            // Esquerda
            Pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(Pos) && PodeMover(Pos))
            {
                mat[Pos.Linha, Pos.Coluna] = true;
            }
            // Noroeste
            Pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(Pos) && PodeMover(Pos))
            {
                mat[Pos.Linha, Pos.Coluna] = true;
            }

            // Jogada especial roque
            if(QtdeMOvimentos == 0 && !partida.Xeque)
            {
                //Jogada especial roque pequeno
                Posicaocs posT1 = new Posicaocs(Posicao.Linha,Posicao.Coluna + 3);
                if (testePraRoque(posT1))
                {
                    Posicaocs p1 = new Posicaocs(Posicao.Linha,Posicao.Coluna + 1);
                    Posicaocs p2 = new Posicaocs(Posicao.Linha, Posicao.Coluna + 2);
                    if(Tab.peca(p1) == null && Tab.peca(p2) == null)
                    {
                        mat[Posicao.Linha,Posicao.Coluna +2] = true;
                    }
                }
                //Jogada especial roque grande
                Posicaocs posT2 = new Posicaocs(Posicao.Linha, Posicao.Coluna + 4);
                if (testePraRoque(posT2))
                {
                    Posicaocs p1 = new Posicaocs(Posicao.Linha, Posicao.Coluna - 1);
                    Posicaocs p2 = new Posicaocs(Posicao.Linha, Posicao.Coluna - 2);
                    Posicaocs p3 = new Posicaocs(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tab.peca(p1) == null && Tab.peca(p2) == null && Tab.peca(p3) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna -2] = true;
                    }
                }
            }
            return mat;
        }
    }

}
//teste de alteração