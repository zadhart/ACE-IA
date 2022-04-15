int coluna = 50;
int linha = 25;
int[,] matrix = new int [linha, coluna];
 
Graph grafo = new Graph();
 
Player jogador =new Player(15,40,"Jeremias",1);
Player jogador1 =new Player(20,30,"Josue",2);
Player jogador2 =new Player(10,10,"Moises",3);
Player jogador3 =new Player(0,0,"Rafael",4);
Player jogador4 =new Player(13,17,"ChrisTiroCerto",5);
Player jogador5 =new Player(24,24,"SucoFruta",6); 
Player final =new Player(25,50,"Gol",0); 

List<int> viz = new List<int>();
viz.Add(jogador1.numero);
viz.Add(jogador2.numero);
viz.Add(jogador3.numero);
viz.Add(jogador4.numero);
viz.Add(jogador5.numero);
viz.Add(final.numero);

List<int> viz2 = new List<int>();
viz.Add(jogador1.numero);
viz.Add(jogador2.numero);
viz.Add(jogador3.numero);
viz.Add(jogador4.numero);
viz.Add(jogador5.numero);
List<int> viz3 = new List<int>();
List<int> viz4 = new List<int>();
List<int> viz5 = new List<int>();


grafo.AddNode(jogador, viz);
grafo.AddNode(jogador1, viz);
grafo.AddNode(jogador2, viz);
grafo.AddNode(jogador3, viz);
grafo.AddNode(jogador4, viz);
grafo.AddNode(jogador5, viz); 
 
for(int i = 0; i < grafo.allNodesData.Count; i++){
    int z = grafo.allNodesData[i].position[0];
    int w = grafo.allNodesData[i].position[1];
 
    matrix[z, w] = 1;
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

    public int[] position = new int[] {0,0};
    // public List<List<int>>  position = new List<List<int>>();
    // public List<int> position = new List<int>();
    
    public Player(int linha, int coluna,string name, int numero)
   {
      nome = nome;
      position[0] = linha;
      position[1] = coluna;
      numero = numero;
   }
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