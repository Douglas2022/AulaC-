using System;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class PartidadeXadres
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }


        public PartidadeXadres()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            ColocarPeca();
        }
        public void ExecutarMovimento(Posicaocs Origem, Posicaocs Destino)
        {
            Peca P = Tab.RetirarPeca(Origem);
            P.IncrementarQtdeMovimentos();
            Peca PecaCapturada = Tab.RetirarPeca(Destino);
            Tab.ColocarPeca(P, Destino);
        }
        public void RealizaJogada(Posicaocs Origem, Posicaocs Destino)
        {
            ExecutarMovimento(Origem, Destino);
            Turno++;
            MudaJogador();
        }
        public void ValidarPosicaoDeOrigem(Posicaocs Pos)
        {
            if (Tab.peca(Pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem");
            }

            if (JogadorAtual != Tab.peca(Pos).Cor)
            {
                throw new TabuleiroException("A peca de origem escolhida não é a sua");
            }

            if (!Tab.peca(Pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos para peça de origem escolhido ");
            }
        }
        public void ValidarPosicao(Posicaocs origem,Posicaocs destino)
        {
            if (!Tab.peca(origem).PodemoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }
        private void ColocarPeca()
        {
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());

            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());
        }
    }
}
