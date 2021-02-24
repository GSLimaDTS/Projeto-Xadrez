using System;
using tabuleiro;
using xadrez_console.Xadrez;

namespace Xadrez

{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8 ) ;
            turno = 1;
            jogadorAtual = Cor.Branca;
            colocarPecas();
        }

        public void ExecutaMovimento(Posicao origem,Posicao destino)
        {
            Peca p = tab.removerPeca(origem);
            p.incrementarQTEMovimentos();
            Peca pecaCapturada = tab.removerPeca(destino);
            tab.colocarPeca(p, destino);

        }

        private void colocarPecas()
        {
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('a',1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('c',3).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao());

        }
    }
}
