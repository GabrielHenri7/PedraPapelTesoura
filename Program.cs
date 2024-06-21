using System;
 
namespace ProjetoFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("\n ---> Pedra, Papel e Tesoura  <---");
            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
 

            string[] opcoes = { "Pedra", "Papel", "Tesoura" };
            int vitoriasJogador = 0;
            int vitoriasMaquina = 0;
 
            Random random = new Random();
 
            while (vitoriasJogador < 5 && vitoriasMaquina < 5)
            {
                // Jogador
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Jogador: Escolha 0 para Pedra, 1 para Papel ou 2 para Tesoura");
                Console.ResetColor();
                int escolhaJogador = ObterEscolhaDoJogador();
                if (escolhaJogador == -1) continue;
 
                // Máquina (IA)
                int escolhaMaquina = random.Next(0, 3);
                Console.WriteLine($"Máquina escolheu: {opcoes[escolhaMaquina]}");
 
                // Mostrar escolhas
                Console.WriteLine($"Jogador escolheu: {opcoes[escolhaJogador]}");
 
                string resultado = DeterminarVencedor(escolhaJogador, escolhaMaquina, opcoes);
 
                if (resultado.Contains("Houve um empate") || resultado.Contains("Jogador venceu") || resultado.Contains("Máquina venceu"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine(resultado);
                Console.ResetColor();
 
                // Atualizar placar
                if (resultado.Contains("Jogador venceu"))
                    vitoriasJogador++;
                else if (resultado.Contains("Máquina venceu"))
                    vitoriasMaquina++;
 
                // Mostrar placar
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Placar - Jogador: {vitoriasJogador}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Placar - Máquina: {vitoriasMaquina}");
                Console.ResetColor();
                Console.WriteLine();
            }
 
            // Mensagem final
            Console.ResetColor();
            if (vitoriasJogador == 5)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Jogador venceu a partida! Parabéns!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Máquina venceu a partida! Parabéns!");
            }
            Console.ResetColor();
        }
 
        static int ObterEscolhaDoJogador()
        {
            int escolha;
            while (true)
            {
                Console.Write("Digite sua escolha: ");
                if (!int.TryParse(Console.ReadLine()!.Trim(), out escolha) || escolha < 0 || escolha > 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }
            return escolha;
        }
 
        static string DeterminarVencedor(int escolhaJogador, int escolhaMaquina, string[] opcoes)
        {
            if (escolhaJogador == escolhaMaquina)
                return "Houve um empate.";
            else if ((escolhaJogador == 0 && escolhaMaquina == 2) ||
                     (escolhaJogador == 1 && escolhaMaquina == 0) ||
                     (escolhaJogador == 2 && escolhaMaquina == 1))
                return $"Jogador venceu! {opcoes[escolhaJogador]} ganha de {opcoes[escolhaMaquina]}.";
            else
                return $"Máquina venceu! {opcoes[escolhaMaquina]} ganha de {opcoes[escolhaJogador]}.";
        }
    }
}