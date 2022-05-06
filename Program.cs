using static test.Player;
using static test.Graph;
using static test.Dijkstra;
using System.Collections.Generic;

namespace test
{
    public class Program
    {
        public static void Main()
        {
            int coluna = 50;
            int linha = 25;
            int[,] matrix = new int[linha, coluna];

            string[] jogadores = {"Jogador","Jogador1","Jogador2","Jogador3","Jogador4","Jogador5","Jogador6", "Final"};

            string[] nomes = {"Jeremias","Josue","Moises","Rafael","ChrisTiroCerto","SucoDeFruta","Gol"};

            List<Player> team = new List<Player>();

            Graph grafo = new Graph();
            
            var PosJogador = new List<(int, int)>
            {
                (15,40),
                ( 20,30), 
                ( 10,10), 
                ( 0,0 ), 
                ( 13,17), 
                ( 24,24), 
                ( 24,49)
            };

            var listaJogadores = new List<Player>();

            for(int i = 0; i < 7; i++){
                listaJogadores.Add( new Player(PosJogador[i].Item1, PosJogador[i].Item2, nomes[i], i));
            }

            foreach (var ind in listaJogadores){
                Console.WriteLine(ind.nome);
            }

            static double distance(Player jogador, Player item)
            {
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
                        weight.Add(distance(jogador, item));
                    }
                    else if (item.numero == jogador.numero || item.numero == 6 || jogador.numero == 6)
                    {
                        weight.Add(0);
                    }
                    else
                    {
                        weight.Add(distance(jogador, item));
                    }
                }
                return weight;
            }

            List<List<int>> Viz = new List<List<int>>{};

            foreach (var ind in listaJogadores){
                Viz.Add(neighbors (ind,listaJogadores));
            }

            List<List<double>> ListaWeight = new List<List<double>>{};

            foreach (var ind in listaJogadores){
                ListaWeight.Add(weight(ind,listaJogadores));
            }

            for(int n = 0; n <7; n++){
                grafo.AddNode(listaJogadores[n],Viz[n],ListaWeight[n]);
            }

            Dijkstra dij = new Dijkstra();

            dij.dijkstra(grafo, listaJogadores[0],listaJogadores[6] );



            // for (int i = 0; i < grafo.allNodesData.Count; i++)
            // {
            //     int z = grafo.allNodesData[i].position[0];
            //     int w = grafo.allNodesData[i].position[1];

            //     matrix[z, w] = 1;
            // }

            // for (int x = 0; x < linha; x++)
            // {
            //     for (int y = 0; y < coluna; y++)
            //     {
            //         Console.Write(matrix[x, y]);
            //     }
            //     Console.WriteLine("");
            // }
        }
    }
}