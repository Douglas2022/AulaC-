
namespace tabuleiro
{
    abstract class Peca
    {
        public Posicaocs Posicao { get; set; }
        public Cor Cor { get;protected set; }
        public int QtdeMOvimentos { get;protected set; }
        public Tabuleiro Tab { get;protected set; }

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
        public abstract bool[,] MovimentosPossiveis();
       
        
    }
}
