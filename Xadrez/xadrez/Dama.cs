using tabuleiro;
using System;

class Dama : Peca
{
    public Dama(Tabuleiro tab, Cor cor) : base(tab, cor)
    {

    }
    public override string ToString()
    {
        return "D";
    }
    private bool podeMover(Posicaocs pos)
    {
        Peca P = Tab.peca(pos);
        return P == null || P.Cor != Cor;
    }
    public override bool[,] movimentosPossiveis()
    {

    }

}
