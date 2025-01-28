using System.Text.RegularExpressions;
using tabuleiro;
namespace xadrez
{
    internal class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }
        public override string ToString()
        {
            return "T";
        }
        private bool PodeMover(Posicaocs Pos)
        {
            Peca P = Tab.peca(Pos);
            return P == null || P.Cor != Cor;

        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] Mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicaocs Pos = new Posicaocs(0, 0);


            // Acima

            Posicaocs posicao = Posicao;
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna);
            while (Tab.PosicaoValida(Pos) && PodeMover(Pos))
            {
                Mat[Pos.Linha, Pos.Coluna] = true;
                if (Tab.peca(Pos) != null && Tab.peca(Pos).Cor != Cor)
                {
                    break;
                }
                Pos.Linha = Pos.Linha -= 1;
            }
            // baixo

            posicao.DefinirValores(posicao.Linha += 1, posicao.Coluna);
            while (Tab.PosicaoValida(Pos) && PodeMover(Pos))
            {
                Mat[Pos.Linha, Pos.Coluna] = true;
                if (Tab.peca(Pos) != null && Tab.peca(Pos).Cor != Cor)
                {
                    break;
                }
                Pos.Linha = Pos.Linha += 1;

            }
            // Direita

            posicao.DefinirValores(posicao.Linha , posicao.Coluna + 1);
            while (Tab.PosicaoValida(Pos) && PodeMover(Pos))
            {
                Mat[Pos.Linha, Pos.Coluna] = true;
                if (Tab.peca(Pos) != null && Tab.peca(Pos).Cor != Cor)
                {
                    break;
                }
                Pos.Coluna = Pos.Coluna += 1;
            }
            // Esquerda

            posicao.DefinirValores(posicao.Linha, posicao.Coluna - 1);
            while (Tab.PosicaoValida(Pos) && PodeMover(Pos))
            {
                Mat[Pos.Linha, Pos.Coluna] = true;
                if (Tab.peca(Pos) != null && Tab.peca(Pos).Cor != Cor)
                {
                    break;
                }
                Pos.Coluna = Pos.Coluna - 1;
            }
            return Mat;

        }
    }
}