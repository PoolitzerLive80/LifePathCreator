namespace LifePathBuilder.Server.Models
{
    public class Trait
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Karma { get; set; }

        public List<Modification>? Modifications { get; set; }
    }
}
