namespace GameSystem {
    public class Game {
        private int id { get; set; }
        private string name { get; set; }

        public Game(int id, string name) {
            this.id = id;
            this.name = name;
        }  

        public string toString() {
            return $"ID = {id}, NAME = {name}";
        }
    }
}
