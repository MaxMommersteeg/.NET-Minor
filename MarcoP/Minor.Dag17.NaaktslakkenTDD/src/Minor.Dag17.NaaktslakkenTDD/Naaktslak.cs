namespace Minor.Dag17.NaaktslakkenTDD.Entities
{
    public class Naaktslak
    {
        public long ID { get; set; }
        public string Naam { get; set; }
        public double Kooktijd { get; set; }
        public Saus BijbehorendeSaus { get; set; }
    }
}