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
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicaocs Pos = new Posicaocs(0, 0);

            //Acima
            Pos.DefinirValores(Posicao.Linha -1, Posicao.Coluna);
            while(Tab.PosicaoValida(Pos) && PodeMover(Pos))
            {
                mat[Pos.Linha,Pos.Coluna] = true;
                if(Tab.peca(Pos) == null && Tab.peca(Pos).Cor != Cor) 
                {
                    break;
                }
                Pos.Linha = Pos.Linha -1;
            }


            return mat;
        }
    }
}