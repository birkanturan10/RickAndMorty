using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RickAndMorty.Models
{
    public class Episode
    {
        public Info? info { get; set; }

        public List<R1>? results { get; set; }
    }

    public class Info
    {
        public int count { get; set; }
        public int pages { get; set; }
        public string? next { get; set; }
        public string? prev { get; set; }
    }

    public class R1
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string? name { get; set; }

        public string? air_date { get; set; }

        public string? episode { get; set; }

        //public List<string>? characters { get; set; }
    }
}
