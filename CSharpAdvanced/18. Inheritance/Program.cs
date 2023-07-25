namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            /*lớp text kế thừa abstract class của presentation object
            Lớp abstract class cha khai báo các abstract class không được phép khai báo thân hàm
           
             */
            var text = new Text();
            text.Width = 100;
            text.Copy();
            text.AddHyperLink("Facebook.com");

            // với kiểu khai báo này, đối tượng con là a có kiểu là text, nhưng chỉ truy cập được các thuộc tính và phương thức 
            // từ object cha 
            PresentationObject a = new Text();
            // không thể sử dụng a.AddHyperLink("Facebook.com"); như dòng 14

            // Các lớp con kế thừa abstract class sẽ phải override hết các abstract method của lớp cha
            // Không thể tạo đối tượng từ abstract class mà phải tạo thông qua 1 lớp con kế thừa từ nó
            // khai báo sai,
            //PresentationObject b = new PresentationObject();

        }
    }
    //dunp: viết thêm  code về cách dùng abstract  class, method 
}