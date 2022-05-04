using static test.Player;
using static test.Graph;

namespace test
{
    public class Program
    {
        public static void Main()
        {
            int coluna = 50;
            int linha = 25;
            int[,] matrix = new int[linha, coluna];

            List<Player> team = new List<Player>();

            Graph grafo = new Graph();

            Player jogador = new Player(15, 15, "Jeremias", 0);
            Player jogador1 = new Player(20, 10, "Josue", 1);
            Player jogador2 = new Player(10, 10, "Moises", 2);
            Player jogador3 = new Player(0, 0, "Rafael", 3);
            Player jogador4 = new Player(13, 17, "ChrisTiroCerto", 4);
            Player jogador5 = new Player(24, 24, "SucoFruta", 5);
            Player final = new Player(24, 49, "Gol", 6);

            grafo.AddPlayer(jogador);
            grafo.AddPlayer(jogador1);
            grafo.AddPlayer(jogador2);
            grafo.AddPlayer(jogador3);
            grafo.AddPlayer(jogador4);
            grafo.AddPlayer(jogador5);
            grafo.AddPlayer(final);

            grafo.calculateDistance();

            for(int i = 0; i < grafo.allNodesData.Count; i++){
                int z = grafo.allNodesData[i].position[0];
                int w = grafo.allNodesData[i].position[1];

                matrix[z, w] = 1;
            }

            
            grafo.findPath(2, 6, matrix);

            
            
        }
    }
}