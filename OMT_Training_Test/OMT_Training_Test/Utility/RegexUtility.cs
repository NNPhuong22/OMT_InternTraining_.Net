using System.Text.RegularExpressions;

namespace OMT_Training_Test.Utility
{
    public static class RegexUtility
    {
        public static readonly Regex nameRegex = new Regex(@"^[a-zA-Z0-9ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺ
ẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\-()/._# ]+$");
        public static string[] dateFormats = { "HH:mm dd/MM/yyyy", "dd/MM/yyyy HH:mm" };
    }
}
