using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RickAndMorty.Models
{
    public class Location
    {
        public Info? info { get; set; }

        public List<R3>? results { get; set; }
    }

    public class R3 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string? name { get; set; }

        public string? type { get; set; }

        public string? dimension { get; set; }

        //public List<string>? residents { get; set; }
    }
}
