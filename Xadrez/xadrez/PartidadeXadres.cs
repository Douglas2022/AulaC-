using System;
using System.Collections.Generic;
using System.Security.Authentication;
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

        public PartidadeXadres()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }
        public void ExecutarMovimento(Posicaocs Origem, Posicaocs Destino)
        {
            Peca P = Tab.RetirarPeca(Origem);
            P.IncrementarQtdeMovimentos();
            Peca PecaCapturada = Tab.RetirarPeca(Destino);
            Tab.ColocarPeca(P, Destino);
            if (PecaCapturada != null)
            {
                Capturadas.Add(PecaCapturada);
            }
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
        public void ColocarNovaPecas(char Coluna, int Linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(Coluna, Linha).ToPosicao());
            peca.Add(peca);
        }
        private void ColocarPecas()
        {

            ColocarNovaPecas('c', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPecas('c', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPecas('d', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPecas('e', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPecas('e', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPecas('d', 1, new Torre(Tab, Cor.Branca));

            ColocarNovaPecas('c', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPecas('c', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPecas('d', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPecas('e', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPecas('e', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPecas('d', 8, new Torre(Tab, Cor.Preta));
        }

    }
                
}
