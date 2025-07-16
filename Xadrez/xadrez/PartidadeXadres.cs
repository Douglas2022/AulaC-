using System.Collections.Generic;
using tabuleiro;
using Xadrez.xadrez;


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
        public bool Xeque { get; private set; }
        public Peca vuneravelEnPassant;

        public PartidadeXadres()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            vuneravelEnPassant = null;  
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
            //# Jogada especial roque pequeno
            if(P  is Rei && Destino.Coluna == Origem.Coluna + 2)
            {
                Posicaocs origemT = new Posicaocs(Origem.Linha, Origem.Coluna + 3);
                Posicaocs destinoT = new Posicaocs(Origem.Linha, Origem.Coluna + 1);
                Peca T = Tab.RetirarPeca(origemT);
                T.IncrementarQtdeMovimentos();
                Tab.ColocarPeca(T,destinoT);
            }
            //# Jogada especial roque grande
            if (P is Rei && Destino.Coluna == Origem.Coluna - 2)
            {
                Posicaocs origemT = new Posicaocs(Origem.Linha, Origem.Coluna - 4);
                Posicaocs destinoT = new Posicaocs(Origem.Linha, Origem.Coluna - 1);
                Peca T = Tab.RetirarPeca(origemT);
                T.IncrementarQtdeMovimentos();
                Tab.ColocarPeca(T, destinoT);
            }

            //jogadaespecial en passant
           if(P is Peao)
            {
                if(Origem.Coluna != Destino.Coluna && pecasCapturadas == null)
                {
                    Posicaocs posP;
                    if(P.Cor == Cor.Branca)
                    {
                        posP = new Posicaocs(Destino.Linha +1, Origem.Coluna);
                    }
                    else
                    {
                        posP = new Posicaocs(Destino.Linha -1,Destino.Coluna);
                    }
                    pecasCapturadas = Tab.RetirarPeca(posP);
                    Capturadas.Add((pecasCapturadas));
                }
            }

            return PecaCapturada;
        }
        public void desfazMovimento(Posicaocs Origem, Posicaocs Destino, Peca pecaCapiturada)
        {
            Peca p = Tab.RetirarPeca(Destino);
            p.decrementarQtdeMovimentos();
            if (pecaCapiturada != null)
            {
                Tab.ColocarPeca(pecaCapiturada, Destino);
                Capturadas.Remove(pecaCapiturada);
            }
            Tab.ColocarPeca(p, Origem);
            //# Jogada especial roque pequeno
            if (p is Rei && Destino.Coluna == Origem.Coluna + 2)
            {
                Posicaocs origemT = new Posicaocs(Origem.Linha, Origem.Coluna + 3);
                Posicaocs destinoT = new Posicaocs(Origem.Linha, Origem.Coluna + 1);
                Peca T = Tab.RetirarPeca(destinoT);
                T.decrementarQtdeMovimentos();
                Tab.ColocarPeca(T,origemT);
            }
            //# Jogada especial roque grande
            if (p is Rei && Destino.Coluna == Origem.Coluna - 2)
            {
                Posicaocs origemT = new Posicaocs(Origem.Linha, Origem.Coluna - 4);
                Posicaocs destinoT = new Posicaocs(Origem.Linha, Origem.Coluna - 1);
                Peca T = Tab.RetirarPeca(destinoT);
                T.IncrementarQtdeMovimentos();
                Tab.ColocarPeca(T, origemT);
            }
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
                Turno++;
                MudaJogador();
            }
            Peca p = Tab.peca(Destino);
            //Jogada especial passant
            if (p is Peao && (Destino.Linha == Origem.Linha - 2 || Destino.Linha == Origem.Linha + 2))
            {
                vuneravelEnPassant = p;
            }
            else
            {
                vuneravelEnPassant = null;
            }
        }
        public void ValidarPosicaoDeOrigem(Posicaocs Pos)
        {
            if (Tab.peca(Pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");
            }

            if (JogadorAtual != Tab.peca(Pos).Cor)
            {
                throw new TabuleiroException("A peca de origem escolhida não é a sua");
            }

            if (!Tab.peca(Pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para peça de origem escolhido ");
            }
        }
        public void ValidarPosicaoDeDestino(Posicaocs Origem, Posicaocs Destino)
        {
            if (!Tab.peca(Origem).movimentoPossivel(Destino))
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
                if (x.Cor == cor)
                {
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
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }
        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
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
            foreach (Peca x in pecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }
        public bool estarEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro");
            }
            foreach (Peca x in pecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;

        }
        public bool testeXequemate(Cor cor)
        {
            if (!estarEmXeque(cor))
            {
                return false;
            }
            foreach (Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.movimentosPossiveis();
                for (int i = 0; i < Tab.Linhas; i++)
                {
                    for (int j = 0; j < Tab.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicaocs origem = x.Posicao;
                            Posicaocs destino = new Posicaocs(i, j);
                            Peca pecaCapturadas = ExecutarMovimento(origem, destino);
                            bool testeXeque = estarEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturadas);
                            if (!testeXeque)
                            {
                                return false;
                            }

                        }
                    }
                }
            }
            return true;
        }

        public void ColocarNovaPecas(char Coluna, int Linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(Coluna, Linha).ToPosicao());
            Pecas.Add(peca);

        }
        private void ColocarPecas()
        {

            ColocarNovaPecas('a', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPecas('b', 1, new Cavalo(Tab, Cor.Branca));
            ColocarNovaPecas('c', 1, new Bispo(Tab, Cor.Branca));
            ColocarNovaPecas('d', 1, new Dama(Tab, Cor.Branca));
            ColocarNovaPecas('e', 1, new Rei(Tab, Cor.Branca,this));
            ColocarNovaPecas('f', 1, new Bispo(Tab, Cor.Branca));
            ColocarNovaPecas('g', 1, new Cavalo(Tab, Cor.Branca));
            ColocarNovaPecas('h', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPecas('a', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPecas('b', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPecas('c', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPecas('d', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPecas('e', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPecas('f', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPecas('g', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPecas('h', 2, new Peao(Tab, Cor.Branca));

            ColocarNovaPecas('a', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPecas('b', 8, new Cavalo(Tab, Cor.Preta));
            ColocarNovaPecas('c', 8, new Bispo(Tab, Cor.Preta));
            ColocarNovaPecas('d', 8, new Dama(Tab, Cor.Preta));
            ColocarNovaPecas('e', 8, new Rei(Tab, Cor.Preta,this));
            ColocarNovaPecas('f', 8, new Bispo(Tab, Cor.Preta));
            ColocarNovaPecas('g', 8, new Cavalo(Tab, Cor.Preta));
            ColocarNovaPecas('h', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPecas('a', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPecas('b', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPecas('c', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPecas('d', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPecas('e', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPecas('f', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPecas('g', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPecas('h', 7, new Peao(Tab, Cor.Preta));

        }

    }

}
