using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace bai1
{
     public class Ketnoi
    {
         public SqlConnection connect;
         public Ketnoi()
         {
             connect = new SqlConnection("Data Source=A209PC49;Initial Catalog=QLSINHVIEN;Integrated Security=True");
         }
         public Ketnoi(string strcn)
         {
             connect = new SqlConnection(strcn);
         }
    }
}
