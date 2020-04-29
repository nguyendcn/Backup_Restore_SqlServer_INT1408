using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT1408.Shared.ErrorHandler
{
    public static class ErrorCode
    {
        public static  String Ox0001 = "Trường dữ liệu không được bỏ trống";
        public static  String Ox0002 = "Trường dữ liệu không hợp lệ";

        public static  String OxDB01 = "Không thể liên kết đến SqlServer";
        public static  String OxDB02 = "Tên server không đúng";
        public static  String OxDB03 = "Tên tài khoản hoặc mật khẩu không đúng";




        public static String GetPropertyValue(String propName)
        {
            Type type = typeof(ErrorCode);

            foreach (var field in type.GetFields())
            {
                if (field.Name.Equals(propName))
                    return field.GetValue(null).ToString();
            }
            return String.Empty;
        }
    }
}
