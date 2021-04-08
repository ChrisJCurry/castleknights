using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Castle
    {
        public Castle()
        {

        }

        public Castle(string name, int year, string kingName, string size)
        {
            Name = name;
            Year = year;
            KingName = kingName;
            Size = size;
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string KingName { get; set; }
        [Required]
        public string Size { get; set; }

        public int Id { get; set; }
    }
}