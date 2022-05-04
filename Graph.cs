namespace test
{
    public class Graph{
        public List<Player> allNodesData = new List<Player>();
        public List<int> ballPosition = new List<int>();
        double[,] gmatrix = new double[22,22];

        public void calculateDistance(){
            for(int x = 0; x < 7; x++){
                for(int y = 0; y < 7; y++){
                    Player jogador1 = allNodesData[x];
                    Player jogador2 = allNodesData[y];
                    double dist = Math.Sqrt((Math.Pow(jogador1.position[0] - jogador2.position[0], 2) 
                    + Math.Pow(jogador1.position[1] - jogador2.position[1], 2)));
                    gmatrix[x,y] = dist;
                }
            }
        }

        public void printMatrix(){
            for(int x = 0; x < 7; x++){
                for(int y = 0; y < 7; y++){
                    Console.Write(gmatrix[x,y]);
                }
                Console.WriteLine("");
            }
        }

        public void AddPlayer(Player jogador){
            allNodesData.Add(jogador);
        }

        public List<int> nextToGK(int initPlayer, int gk){
            //Encontrando a distancia entre o jogador atual e o goleiro
            double dist = gmatrix[initPlayer, gk];

            List<int> possiblePlayers = new List<int>();

            for(int w = 0; w < 7; w++){
                if(gmatrix[w, gk] < gmatrix[initPlayer, gk]){
                    possiblePlayers.Add(w);
                }
            }

            return possiblePlayers;
        }

        public int nextPlayer(int initPlayer, List<int> possiblePlayers){
            int minor = possiblePlayers[0];

            for(int x = 0; x < possiblePlayers.Count; x++){
                if(gmatrix[initPlayer, minor] < gmatrix[initPlayer, x]){
                    minor = x;
                }
            }

            return minor;
        }

        public List<int> findPath(int initPlayer, int gk, int[,] matrix){

            List<int> caminho = new List<int>();

            caminho.Add(initPlayer);

            while(initPlayer != gk){

                int z = this.allNodesData[initPlayer].position[0];
                int w = this.allNodesData[initPlayer].position[1];

                matrix[z, w] = 1;

                initPlayer = this.nextPlayer(initPlayer, this.nextToGK(initPlayer, gk));
                caminho.Add(initPlayer);

                z = this.allNodesData[initPlayer].position[0];
                w = this.allNodesData[initPlayer].position[1];

                matrix[z, w] = 2;

                Console.WriteLine("###############################################################");

                for(int x = 0; x < 25; x++){
                    for(int y = 0; y < 50; y++){
                        Console.Write(matrix[x,y]);
                    }
                    Console.WriteLine("");
                }

            }

            return caminho;
        }


    }
}
