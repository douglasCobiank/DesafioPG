using System.Collections.Generic;

namespace DesafioPG.Models
{
    public class Results
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string modified { get; set; }
        public Thumbnail thumbnail { get; set; }
        public string resourceURI { get; set; }
        public Comics comics { get; set; }
        public Comics series { get; set; }
        public Comics stories { get; set; }
        public Comics events { get; set; }
        public List<Urls> urls { get; set; }
    }
}
