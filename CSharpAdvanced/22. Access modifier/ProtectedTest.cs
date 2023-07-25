namespace AccessModifier
{
    class Customer
    {
        private int Id;
        protected int protectedModifier;
        protected void Promote()
        {

        }
    }
    class ProtectedTest : Customer
    {
        static void Main(string[] args)
        {
            //protected cho phép truy cập trong cùng class, hoặc class khác kế thừa nó
            ProtectedTest customer = new ProtectedTest();
            customer.Promote();
        }
    }

    //dunp: public, private, internal, protected
    //https://www.w3schools.com/cs/cs_access_modifiers.php đọc kỹ để viết các trường hợp tương ứng
    // internal, protected  tạo thêm prj lib  để viết các code test và thể hiện đúng các trưowngf hợp dùng 
}