using static test.Player;
using static test.Graph;
using static test.Dijkstra;

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

            Player jogador = new Player(15, 40, "Jeremias", 1);
            Player jogador1 = new Player(20, 30, "Josue", 2);
            Player jogador2 = new Player(10, 10, "Moises", 3);
            Player jogador3 = new Player(0, 0, "Rafael", 4);
            Player jogador4 = new Player(13, 17, "ChrisTiroCerto", 5);
            Player jogador5 = new Player(24, 24, "SucoFruta", 6);
            Player final = new Player(25, 50, "Gol", 0);

            team.Add(jogador);
            team.Add(jogador1);
            team.Add(jogador2);
            team.Add(jogador3);
            team.Add(jogador4);
            team.Add(jogador5);
            team.Add(final);

            static List<int> neighbors(Player jogador, List<Player> team)
            {
                List<int> viz = new List<int>();

                foreach (Player item in team)
                {
                    if ((item.numero != 0) && (jogador.numero != item.numero))
                    {
                        viz.Add(item.numero);
                    }
                    else if (item.numero == 1 & jogador.numero != item.numero)
                    {
                        viz.Add(item.numero);
                    }
                }
                return viz;
            }

            List<int> viz = neighbors(jogador, team);
            List<int> viz1 = neighbors(jogador1, team);
            List<int> viz2 = neighbors(jogador2, team);
            List<int> viz3 = neighbors(jogador3, team);
            List<int> viz4 = neighbors(jogador4, team);
            List<int> viz5 = neighbors(jogador5, team);
            List<int> viz6 = new List<int>();

            grafo.AddNode(jogador, viz);
            grafo.AddNode(jogador1, viz1);
            grafo.AddNode(jogador2, viz2);
            grafo.AddNode(jogador3, viz3);
            grafo.AddNode(jogador4, viz4);
            grafo.AddNode(jogador5, viz5);
            grafo.AddNode(final, viz6);


            grafo.ShowNeighbors(grafo);
            // for(int i = 0; i < grafo.allNodesData.Count; i++){
            //     int z = grafo.allNodesData[i].position[0];
            //     int w = grafo.allNodesData[i].position[1];

            //     matrix[z, w] = 1;
            // }

            // for(int x = 0; x < linha; x++){
            //     for(int y = 0; y < coluna; y++){
            //         Console.Write(matrix[x,y]);
            //     }
            //     Console.WriteLine("");
            // }
        }
    }
}