namespace LifePathBuilder.Server.Models
{
    public class CharakterDraft
    {
        public string StreetName { get; set; }

        public string Name { get; set; }

        public int Karma { get; set; }

        public MetaType MetaType { get; set; }

        public int Age { get; set; }

        public bool Mundane { get; set; }

        public bool Awakened { get; set; }

        public bool Technomancer { get; set; }

        public string Nationality { get; set; }

        public List<Trait> Traits { get; set; }
    }
}
