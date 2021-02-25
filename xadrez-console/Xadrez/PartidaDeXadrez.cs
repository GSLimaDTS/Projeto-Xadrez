using System;
using tabuleiro;
using xadrez_console.Xadrez;

namespace Xadrez

{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            colocarPecas();
            terminada = false;
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.removerPeca(origem);
            p.incrementarQTEMovimentos();
            Peca pecaCapturada = tab.removerPeca(destino);
            tab.colocarPeca(p, destino);

        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        public void validarPosicaoOrigem(Posicao pos)
        {
            if(tab.peca(pos)== null)
            {
                throw new TabuleiroException("Selecione uma posição que tenha uma peça.");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça não pertence ao jogador atual.");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("A peça escolhida não possui movimentos disponíveis");
            }
        }

        public void validarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverpara(destino))
            {
                throw new TabuleiroException("Selecione uma posição de destino válida");
            }
        }

        public void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
               jogadorAtual = Cor.Preta;
            }
            else
            {
               jogadorAtual = Cor.Branca;
            }
        }

        private void colocarPecas()
        {
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('a',1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('c',3).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao());

        }
    }
}
