namespace Models
{
    public class Knight
    {
        public Knight()
        {
        }

        public Knight(string name, string title, int age, int castleId)
        {
            Name = name;
            Title = title;
            Age = age;
        }

        public string Name { get; set; }
        public string Title { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }
        public int CastleId { get; set; }
    }

    public class CastleKnight : Knight
    {
        public Castle Castle { get; set; }

    }
}