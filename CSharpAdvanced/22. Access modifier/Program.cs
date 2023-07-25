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

    //dunp: public, private, internal, protected
    //https://www.w3schools.com/cs/cs_access_modifiers.php đọc kỹ để viết các trường hợp tương ứng
    // internal, protected  tạo thêm prj lib  để viết các code test và thể hiện đúng các trưowngf hợp dùng 
}