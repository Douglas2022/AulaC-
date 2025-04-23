using System;
using System.Collections.Generic;
using tabuleiro;


namespace xadrez
{
    internal class PartidadeXadres
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public bool Xeque { get;private set; }

        public PartidadeXadres()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }
        public Peca ExecutarMovimento(Posicaocs Origem, Posicaocs Destino)
        {
            Peca P = Tab.RetirarPeca(Origem);
            P.IncrementarQtdeMovimentos();
            Peca PecaCapturada = Tab.RetirarPeca(Destino);
            Tab.ColocarPeca(P, Destino);
            if (PecaCapturada != null)
            {
                Capturadas.Add(PecaCapturada);
            }
            return PecaCapturada;
        }
        public void desfazMovimento(Posicaocs Origem,Posicaocs Destino,Peca pecaCapiturada)
        {
            Peca p = Tab.RetirarPeca(Destino);
            p.decrementarQtdeMovimentos();
            if(pecaCapiturada != null)
            {
                Tab.ColocarPeca(pecaCapiturada , Destino);
                Capturadas.Remove(pecaCapiturada);
            }
            Tab.ColocarPeca(p ,Origem);
        }
        public void RealizaJogada(Posicaocs Origem, Posicaocs Destino)
        {
            Peca pecaCapiturada = ExecutarMovimento(Origem, Destino);

            if (estarEmXeque(JogadorAtual))
            {
                desfazMovimento(Origem, Destino, pecaCapiturada);
                throw new TabuleiroException("Voce não pode se colocar em xeque!");
            }
            if (estarEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }


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

            if (!Tab.peca(Pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possiveis para peça de origem escolhido ");
            }
        }
        public void ValidarPosicaoDeDestino(Posicaocs Origem, Posicaocs Destino)
        {
            if (!Tab.peca(Origem).PodemoverPara(Destino))
            {
                throw new TabuleiroException("Posição de destino inválida");
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
       
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor){
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas)
            {
                if (x.Cor == cor){
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }
        private Cor Adversaria(Cor cor)
        {
            if(cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
                
        }
        private Peca rei(Cor cor)
        {
            foreach(Peca x in pecasEmJogo(cor))
            {
                if(x is Rei)
                {
                    return x;
                }
            }
            return null;
        }
        public bool estarEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if(R == null)
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro");
            }
            foreach(Peca x in pecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
            
        }
        public void ColocarNovaPecas(char Coluna, int Linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(Coluna, Linha).ToPosicao());
            Pecas.Add(peca);
           
        }
        private void ColocarPecas()
        {

            ColocarNovaPecas('c', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPecas('c', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPecas('d', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPecas('e', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPecas('e', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPecas('d', 1, new Rei(Tab, Cor.Branca));

            ColocarNovaPecas('c', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPecas('c', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPecas('d', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPecas('e', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPecas('e', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPecas('d', 8, new Rei(Tab, Cor.Preta));
        }

    }
                
}
