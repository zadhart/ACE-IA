namespace test
{
    public class Player
    {
        public string nome = "";
        public int tipo = 0;
        public int numero = 0;
        public int haveBall = 0;
        public int team = 0;
        public List<int> jogador = new List<int>();

        public int[] position = new int[] { 0, 0 };
        // public List<List<int>>  position = new List<List<int>>();
        // public List<int> position = new List<int>();

        public Player(int linha, int coluna, string nome, int numero)
        {
            this.jogador.Add(numero);
            this.nome = nome;
            this.position[0] = linha;
            this.position[1] = coluna;
            this.numero = numero;
        }
    }
}