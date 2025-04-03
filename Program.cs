using System;

class Program
{
    static void Main()
    {
        TelaInicia();
        ComecarJogo();
    }

    static void TelaInicia()
    {
        Console.WriteLine("Qual seu nome?");
        string nome = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Jogo Dos Dados");
        Console.WriteLine("Você -> " + nome);
        Console.WriteLine("Aperte Enter para continuar");
        Console.ReadLine();
    }

    static void ComecarJogo()
    {
        int posicaoJogador = 0, posicaoBot = 0;

        while (true)
        {
            posicaoJogador = Jogador(posicaoJogador);
            posicaoJogador = AplicarEfeitoCasa(posicaoJogador, "Jogador");

            if (posicaoJogador >= 30)
            {
                Console.WriteLine("\nParabéns! Você venceu!");
                break;
            }

            posicaoBot = Bot(posicaoBot);
            posicaoBot = AplicarEfeitoCasa(posicaoBot, "Bot");

            if (posicaoBot >= 30)
            {
                Console.WriteLine("\nO bot venceu! Tente novamente.");
                break;
            }

            tabuleiro(posicaoBot, posicaoJogador);
        }
    }

    static void tabuleiro(int posicaoBot, int posicaoJogador)
    {
        for (int i = 0; i < 31; i++)
        {
            if (posicaoBot == i && posicaoJogador == i)
                Console.Write("(X)");
            else if (posicaoBot == i)
                Console.Write("(0-0)");
            else
                Console.Write("_");
        }

        Console.WriteLine();

        for (int i = 0; i < 31; i++)
        {
            if (posicaoJogador == i && posicaoBot != i)
                Console.Write("(uwu)");
            else if (posicaoBot != i)
                Console.Write("_");
        }

        Console.WriteLine("\n");
    }

    static int Jogador(int posicaoJogador)
    {
        Console.WriteLine("\nPara rolar o dado, digite R");
        while (Console.ReadKey(true).Key != ConsoleKey.R) { }

        int valorDadoJ = rodarDado();
        posicaoJogador += valorDadoJ;

        Console.WriteLine("O valor do dado do jogador é: " + valorDadoJ);
        return posicaoJogador;
    }

    static int Bot(int posicaoBot)
    {
        int valorDadoB = rodarDado();
        posicaoBot += valorDadoB;

        Console.WriteLine("O valor do dado do bot é: " + valorDadoB);
        return posicaoBot;
    }

    static int AplicarEfeitoCasa(int posicao, string jogador)
    {
        int[] avanco = { 5, 10, 15, 20, 25 };
        int[] recuo = { 7, 13, 18, 23, 28 };

        if (Array.Exists(avanco, e => e == posicao))
        {
            posicao += (posicao % 10 == 0) ? 2 : 1;
            Console.WriteLine($"{jogador} avançou para a casa {posicao}!");
        }
        else if (Array.Exists(recuo, e => e == posicao))
        {
            posicao -= (posicao % 5 == 3) ? 2 : 1;
            Console.WriteLine($"{jogador} recuou para a casa {posicao}.");
        }

        return posicao;
    }

    static Random random = new Random();
    static int rodarDado()
    {
        return random.Next(1, 7);
    }
}
