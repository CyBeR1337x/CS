namespace ConsoleApp1 {
    class LinkedList {
        Node? head;
        
        public void insert(int d) {
            Node n = new Node(d);
            if (head == null)
                head = n;
            else {
                n.next = head;
                head = n;
            }
        }

        public void insertAtLast(int data) {
            Node n = new Node(data);
            if (head == null)
                head = n;
            else {
                Node temp = head;
                while (temp.next != null)
                    temp = temp.next;

                temp.next = n;
            }
        }


        public void display() {
            Node temp = head;
            while (temp != null) {
                Console.Write(temp.data + "->");
                temp = temp.next;
            }
            Console.WriteLine("NULL");
        }

        
    }
}
