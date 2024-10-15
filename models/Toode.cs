namespace veeb.models
{
    public class Toode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }

        public Toode(int id, string name, double price, bool isActive)
        {
            Id = id;
            Name = name;
            Price = price;
            IsActive = isActive;
        }
    }

    public class Kasutaja
    {
        public int Id { get; set; }
        public string Kasutajanimi { get; set; }
        public string Parool { get; set; }
        public string Eesnimi { get; set; }
        public string Perenimi { get; set; }

        public Kasutaja(int id, string kasutajanimi, string parool, string eesnimi, string perenimi)
        {
            Id = id;
            Kasutajanimi = kasutajanimi;
            Parool = parool;
            Eesnimi = eesnimi;
            Perenimi = perenimi;
        }
    }
}
