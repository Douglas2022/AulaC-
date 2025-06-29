﻿namespace tabuleiro
{
    abstract class Peca
    {
        public Posicaocs Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdeMOvimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.Posicao = null;
            this.Tab = tab;
            this.Cor = cor;
            this.QtdeMOvimentos = 0;
        }
        public void IncrementarQtdeMovimentos()
        {
            QtdeMOvimentos++;
        }
        public void decrementarQtdeMovimentos()
        {
            QtdeMOvimentos--;
        }
        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < Tab.Linhas; i++)
            {
                for (int j = 0; j < Tab.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }

            }
            return false;

        }
        public bool movimentoPossivel(Posicaocs Pos)
        {
            return movimentosPossiveis()[Pos.Linha, Pos.Coluna];
        }

        public abstract bool[,] movimentosPossiveis();

    }


}
