namespace _22._Access_modifier
{
    public class Customer
    {
        private int Id = 1;
        private string Name = "Phương";
        public void Promote()
        {
            Console.WriteLine(Id + " " + Name);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            // private chỉ cho phép truy cập trong class, ngoài class thì phải truy cập gián tiếp thông qua các access
            // modifier có độ truy cập rộng hơn như public hay protected
            //Không thể truy cập vì thuộc tính name đặt là public
            //customer.Name

            customer.Promote();
        }
    }
}
