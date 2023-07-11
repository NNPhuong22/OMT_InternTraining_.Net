namespace AccessModifier
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Promote()
        {

        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            customer.Promote();
        }
    }
}