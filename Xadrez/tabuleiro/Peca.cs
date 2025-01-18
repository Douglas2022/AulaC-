
namespace tabuleiro
{
    internal class Peca
    {
        public Posicaocs Posicao { get; set; }
        public Cor Cor { get;protected set; }
        public int QtdeMOvimentos { get;protected set; }
        public Tabuleiro Tab { get;protected set; }

        public Peca(Posicaocs posicao,Tabuleiro tab, Cor cor)
        {
            Posicao = null;
            Cor = cor;
            Tab = tab;
            QtdeMOvimentos = 0;
        }

        public Peca(Tabuleiro tab, Cor cor)
        {
            Tab = tab;
            Cor = cor;
        }
    }
}
