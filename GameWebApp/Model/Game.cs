using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MidsForms.Models {
    public class Game {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Pov { get; set; }
        public bool Pg18 { get; set; }
        public string MatureAudience { get; set; }  
        public double Price { get; set; }

    }
}
