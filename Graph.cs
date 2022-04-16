namespace test
{
    public class Graph
    {
        public int size = 0;
        public List<Player> allNodesData = new List<Player>();
        public List<List<int>> neighbors = new List<List<int>>();
        public List<int> ballPosition = new List<int>();
        public int whoHaveBall = 0;

        public void ShowNodes(Graph grafo)
        {
            grafo.allNodesData.ForEach(p => Console.WriteLine(p.numero));
        }

        public void ShowNeighbors(Graph grafo)
        {
            int count = 0;
            foreach (var x in grafo.neighbors)
            {
                Console.WriteLine("Vizinhos de : " + grafo.allNodesData[count].numero);
                foreach (var j in x)
                {
                    Console.WriteLine(j);
                }
                count++;
            }
        }

        public void AddNode(Player jogador, List<int> vizinhos)
        {
            this.allNodesData.Add(jogador);
            this.neighbors.Add(vizinhos);
            this.size++;
        }
    }
}