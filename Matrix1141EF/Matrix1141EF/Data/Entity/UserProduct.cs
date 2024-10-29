namespace Matrix1141EF.Data.Entity
{
    public class UserProduct
    {
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
        public int Count { get; set; }
    }
}
