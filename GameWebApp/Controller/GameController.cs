using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MidsForms.Models;
using System.Data;

namespace MidsForms.Controllers {
    public class GameController : Controller {
        // GET: Game
        public ActionResult Index() {
            return View();
        }

        [HttpGet]
        public ActionResult AddGame() {
            return View();
        }
        //Insert into DB
        [HttpPost]
        public ActionResult AddGame(Game x) {
            string connectionString = @"Data Source=CYBER;User ID=sa;Password=123; Initial Catalog=VP_ADO;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            if (con.State != ConnectionState.Open)
                con.Open();
            x.MatureAudience = x.Pg18 ? "Yes" : "No";
            string q = $"INSERT INTO Games VALUES('{x.Id}', '{x.Name}', '{x.Developer}', '{x.Publisher}', '{x.Category}', '{x.ReleaseDate}', '{x.Pov}', '{x.Price}', '{x.MatureAudience}')";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return View(x);
        }
        //Read From DB
        [HttpGet]
        public ActionResult ShowGame() {
            string connectionString = @"Data Source=CYBER;User ID=sa;Password=123; Initial Catalog=VP_ADO;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            if (con.State != ConnectionState.Open)
                con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Games", con);
            SqlDataReader data = cmd.ExecuteReader();
            List<Game> games = new List<Game>();
            while (data.Read()) {
                Game g = new Game {
                    Id = int.Parse(data["id"].ToString()),
                    Name = data["name"].ToString(),
                    Developer = data["developer"].ToString(),
                    Publisher = data["publisher"].ToString(),
                    Pov = data["pov"].ToString(),
                    Category = data["category"].ToString(),
                    ReleaseDate = (DateTime)data["releaseDate"],
                    Price = float.Parse(data["price"].ToString()),
                    MatureAudience = data["pg18"].ToString()
                };
                games.Add(g);
            }
            data.Close();
            con.Close();
            return View(games);
        }
    }
}
