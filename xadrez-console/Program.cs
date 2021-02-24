﻿using System;
using tabuleiro;
using xadrez_console.Xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            try
            {
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.colocarPeca(new Rei(tab, Cor.Branca), new Posicao(2, 4));
                tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(1, 1));
                tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(3, 6));
                tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(4, 4));

                Tela.imprimirTabuleiro(tab);
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
