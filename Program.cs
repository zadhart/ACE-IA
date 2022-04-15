
int coluna = 50;
int linha = 25;
int[,] matrix = new int [linha, coluna];

Graph teste = new Graph();

Player jogador =new Player();

jogador.position.Add(15);
jogador.position.Add(40);
List<int> viz = new List<int>();


teste.AddNode(jogador, viz); 

Player jogador1 =new Player();

jogador1.position.Add(20);
jogador1.position.Add(20);
List<int> viz1 = new List<int>();


teste.AddNode(jogador1, viz1); 

/*
Console.WriteLine(teste.allNodesData[0].position[0]);
Console.WriteLine(teste.allNodesData[0].position[1]);
*/

for(int i = 0; i < teste.allNodesData.Count; i++){
    matrix[teste.allNodesData[i].position[0], teste.allNodesData[i].position[1]] = 1;
}


for(int x = 0; x < linha; x++){
    for(int y = 0; y < coluna; y++){
        Console.Write(matrix[x,y]);
    }
    Console.WriteLine("");
}



class Player{
    public string nome =  "";
    public int tipo = 0;
    public int numero = 0;
    public int haveBall = 0;
    public int team = 0;
    public List<int> position = new List<int>();

}

class Graph{
    public int size = 0;
    public List<Player> allNodesData = new List<Player>();
    public List<List<int>> neighbors = new List<List<int>>();
    public List<int> ballPosition = new List<int>();
    public int whoHaveBall = 0;

    public void Show(){
        for(int i = 0; i < this.allNodesData.Count; i++){
            Console.WriteLine(this.allNodesData[i]);
        }
    }

    public void AddNode(Player jogador, List<int> vizinhos){
        this.allNodesData.Add(jogador);
        this.neighbors.Add(vizinhos);
        this.size++;
    }
}

