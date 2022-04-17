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

            Player jogador = new Player(15, 40, "Jeremias", 0);
            Player jogador1 = new Player(20, 30, "Josue", 1);
            Player jogador2 = new Player(10, 10, "Moises", 2);
            Player jogador3 = new Player(0, 0, "Rafael", 3);
            Player jogador4 = new Player(13, 17, "ChrisTiroCerto", 4);
            Player jogador5 = new Player(24, 24, "SucoFruta", 5);
            Player final = new Player(25, 50, "Gol", 6);

            team.Add(jogador);
            team.Add(jogador1);
            team.Add(jogador2);
            team.Add(jogador3);
            team.Add(jogador4);
            team.Add(jogador5);
            team.Add(final);

            static double distance(Player jogador, Player item){
                // a2 = b2 + c2
                var dist = Math.Sqrt((Math.Pow(jogador.position[0] - item.position[0], 2) + Math.Pow(jogador.position[1] - item.position[1], 2)));
                return dist;
            }

            static List<int> neighbors(Player jogador, List<Player> team)
            {
                List<int> viz = new List<int>();

                foreach (Player item in team)
                {
                    viz.Add(item.numero);
                }
                return viz;
            }

            static List<double> weight(Player jogador, List<Player> team)
            {
                List<double> weight = new List<double>();

                foreach (Player item in team)
                {
                    if ((jogador.numero == 1) && (item.numero == 6))
                    {
                        weight.Add(distance(jogador,item));
                    }
                    else if(item.numero == jogador.numero || item.numero == 6 || jogador.numero == 6)
                    {
                        weight.Add(0);
                    }
                    else
                    {
                        weight.Add(distance(jogador,item));
                    }
                }
                return weight;
            }

            List<int> viz = neighbors(jogador, team);
            List<int> viz1 = neighbors(jogador1, team);
            List<int> viz2 = neighbors(jogador2, team);
            List<int> viz3 = neighbors(jogador3, team);
            List<int> viz4 = neighbors(jogador4, team);
            List<int> viz5 = neighbors(jogador5, team);
            List<int> viz6 = neighbors(final, team);

            List<double> weight1= weight(jogador, team);
            List<double> weight2 = weight(jogador1, team);
            List<double> weight3 = weight(jogador2, team);
            List<double> weight4 = weight(jogador3, team);
            List<double> weight5 = weight(jogador4, team);
            List<double> weight6 = weight(jogador5, team);
            List<double> weight7 = weight(final,team);

            grafo.AddNode(jogador, viz, weight1);
            grafo.AddNode(jogador1, viz1,weight2);
            grafo.AddNode(jogador2, viz2,weight3);
            grafo.AddNode(jogador3, viz3,weight4);
            grafo.AddNode(jogador4, viz4,weight5);
            grafo.AddNode(jogador5, viz5,weight6);
            grafo.AddNode(final, viz6,weight7);


            // grafo.ShowNeighbors(grafo);
            // grafo.ShowWeight(grafo);
            
            // Console.WriteLine(grafo.weight[3][3]);

            Dijkstra dij = new Dijkstra();

            dij.dijkstra(grafo,jogador3, final);



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