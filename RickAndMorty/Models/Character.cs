using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RickAndMorty.Models
{
    public class Character
    {
        public Info? info { get; set; }

        public List<R2>? results { get; set; }
    }

    public class R2
    {
        public int id { get; set; }

        public string? name { get; set; }

        public string? status { get; set; }

        public string? species { get; set; }

        public string? type { get; set; }

        public string? gender { get; set; }

        public _origin? origin { get; set; }

        public _location? location { get; set; }

        public string? image { get; set; }

        //public List<string>? episode { get; set; }
    }

    public class _origin
    {
        public string? name { get; set; }

        public string? url { get; set; }
    }
    
    public class _location
    {
        public string? name { get; set; }

        public string? url { get; set; }
    }
}
