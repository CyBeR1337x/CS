using System;
using System.Collections.Generic;
namespace GameSystem {
    public class Program {
        public static void Main(string[] args) {
            DBMgr db = new DBMgr();
            int ch = 0;
            do {
                Console.Write("1. Display Games\n2. Add Game\n3. Delete Game\n4. Exit\nInput: ");
                ch = int.Parse(Console.ReadLine());
                if (ch == 1) {
                    List<Game> ls = db.SelectQuery();
                    foreach (Game g in ls)
                        Console.WriteLine(g.toString());
                }
                else if (ch == 2) {
                    Console.WriteLine("Enter ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine(db.InsertQuery(id, name) + " Row(s) affected!");
                }
                else if (ch == 3) {
                    Console.WriteLine("Enter ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine(db.DeleteQuery(id) + " Row(s) affected!");
                }
            } while (ch != 4);
            db.Close();

        }
    }
}
