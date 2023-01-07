namespace ConsoleApp1 {
    class MainClass {

        public static void Main() {

            LinkedList l = new LinkedList(); // can be simplified as well to new();
            l.insert(2);
            l.insert(4);
            l.insert(5);

            l.insert(7);

            l.insertAtLast(-1);

            l.display();

        }
  
    }
}
