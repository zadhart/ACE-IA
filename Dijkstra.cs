namespace test
{
    public class Dijkstra
    {
        int minDistance(double[] dist, bool[] sptSet, Graph grafo, int u)
        {
            double min = double.MaxValue;
            int min_index = -1;

            foreach(int v in grafo.neighbors[u]){
                // Console.WriteLine("Vizinhos: " + v);
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }
            }
            // Console.WriteLine("Min Index aqui: " + min_index);
            return min_index;
        }
        void printSolution(double[] dist, Graph grafo, List <int> caminho, Player src, Player destino)
        {
            Console.Write("Vertex     Distance "
                          + "from Source\n");
            for (int i = 0; i < grafo.allNodesData.Count; i++)
            {
                Console.Write(i + " \t\t " + dist[i] + "\n");
            }

            Console.WriteLine("Caminho: ");
            Console.Write(src.numero);
            foreach(var v in caminho)
            {
                Console.Write( " " + v);
            }
            Console.Write(" " + destino.numero);

        }
        public void dijkstra(Graph grafo, Player src, Player destino)
        {
            double[] dist = new double[grafo.allNodesData.Count];
            List<int> caminho = new List<int>();
            bool[] visitado = new bool[grafo.allNodesData.Count];

            for (int i = 0; i < grafo.allNodesData.Count; i++)
            {
                dist[i] = double.MaxValue;
                visitado[i] = false;
            }

            dist[src.numero] = 0;

            for (int count = 0; count < grafo.allNodesData.Count; count++)
            {
                int u = minDistance(dist, visitado, grafo, count);
                visitado[u] = true;
                // Console.WriteLine(u);
                if(u!= 6){
                    foreach(int v in grafo.neighbors[u]){
                        if (!visitado[v] && grafo.weight[u][v] != 0 && dist[u] != double.MaxValue && dist[u] + grafo.weight[u][v] < dist[v]){
                            // Console.WriteLine("esse e o V:  " + v + "Esse e o U: " + u); 
                            dist[v] = dist[u] + grafo.weight[u][v];
                            if(v == destino.numero){
                                caminho.Add(u);
                            }
                        }
                    }
                }
            }

            printSolution(dist, grafo, caminho, src, destino);
        }
    }
}