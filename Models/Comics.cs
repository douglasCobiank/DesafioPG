using System.Collections.Generic;

namespace DesafioPG.Models
{
    public class Comics
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public List<Items> items { get; set; }
        public int returned { get; set; }
    }
}
