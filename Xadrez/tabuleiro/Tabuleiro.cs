//System.Diagnostics.SymbolStore;
namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        public Peca peca(Posicaocs pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }
        public bool ExistePeca(Posicaocs Pos)
        {
            ValidarPosicao(Pos);
            return peca(Pos) != null;
        }
        public void ColocarPeca(Peca P, Posicaocs Pos)
        {
            if (ExistePeca(Pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posiçao!");
            }

            pecas[Pos.Linha, Pos.Coluna] = P;
            P.Posicao = Pos;
        }
        public Peca RetirarPeca(Posicaocs Pos)
        {
            if (peca(Pos) == null)
            {
                return null;
            }
            Peca aux = peca(Pos);
            aux.Posicao = null;
            pecas[Pos.Linha, Pos.Coluna] = null;
            return aux;
        }
        public bool PosicaoValida(Posicaocs Pos)
        {
            if (Pos.Linha < 0 || Pos.Linha >= Linhas || Pos.Coluna < 0 || Pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }
        public void ValidarPosicao(Posicaocs Pos)
        {
            if (!PosicaoValida(Pos))
            {
                throw new TabuleiroException("Posicao invalida!");
            }
        }
    }
}
