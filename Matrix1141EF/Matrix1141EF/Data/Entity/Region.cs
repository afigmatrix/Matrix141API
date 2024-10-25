namespace Matrix1141EF.Data.Entity
{
    public class Region
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Country country { get; set; }
    }
}
