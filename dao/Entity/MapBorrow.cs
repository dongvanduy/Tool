using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dao.Entity
{
    public class MapBorrow
    {
        public string alreadyBorrowedSerials;
        dataBaseTestEntities db = new dataBaseTestEntities();
        public void BorrowPCBs(string serialNumber, string borrower, string approver, DateTime borrowDate)
        {
            alreadyBorrowedSerials = string.Empty;

            using (var conn = db.Database.Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    // Gọi đến stored procedure UpdateBorrowNe
                    cmd.CommandText = "UpdateBorrowNe";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Truyền tham số cho stored procedure
                    cmd.Parameters.Add(new SqlParameter("@SerialNumbers", serialNumber));  // Danh sách serial numbers ngăn cách bằng dấu phẩy
                    cmd.Parameters.Add(new SqlParameter("@Borrower", borrower));           // Người mượn
                    cmd.Parameters.Add(new SqlParameter("@Approver_Br", approver));        // Người phê duyệt
                    cmd.Parameters.Add(new SqlParameter("@Br_date", borrowDate));          // Ngày cho mượn

                    // Thêm tham số đầu ra để lưu danh sách các serial đã được mượn trước đó
                    var alreadyBorrowedParam = new SqlParameter("@AlreadyBorrowedSerialNumbers", System.Data.SqlDbType.NVarChar, -1)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(alreadyBorrowedParam);

                    // Thực thi stored procedure
                    cmd.ExecuteNonQuery();

                    // Lấy kết quả từ tham số đầu ra và kiểm tra nếu không phải là DBNull
                    if (alreadyBorrowedParam.Value != DBNull.Value)
                    {
                        alreadyBorrowedSerials = (string)alreadyBorrowedParam.Value;
                    }
                    else
                    {
                        alreadyBorrowedSerials = string.Empty; // Thay thế bằng chuỗi rỗng nếu NULL
                    }
                }
            }
            // Hiển thị thông báo cho các serial đã được mượn trước đó
            if (!string.IsNullOrEmpty(alreadyBorrowedSerials))
            {
                Console.WriteLine("Các serial đã được mượn trước đó: " + alreadyBorrowedSerials);
            }
            else
            {
                Console.WriteLine("Cập nhật thành công!");
            }
        }

        public void ReturnPCBRepo(string serialNumbers, string repo, string sheft, string tray, DateTime returnDate, string approver)
        {
            using (var conn = db.Database.Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    // Gọi đến stored procedure ReturnPCBToWarehouse
                    cmd.CommandText = "ReturnPCBToWarehouse";
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Truyền các tham số cho stored procedure
                    cmd.Parameters.Add(new SqlParameter("@SerialNumbers", serialNumbers)); // Danh sách serial numbers
                    cmd.Parameters.Add(new SqlParameter("@Repo", repo));                  // Kho
                    cmd.Parameters.Add(new SqlParameter("@Sheft", sheft));                // Kệ
                    cmd.Parameters.Add(new SqlParameter("@Tray", tray));                  // Khay
                    cmd.Parameters.Add(new SqlParameter("@ReturnDate", returnDate));      // Ngày trả về kho
                    cmd.Parameters.Add(new SqlParameter("@Approver", approver));

                    // Thực thi stored procedure
                    cmd.ExecuteNonQuery();
                }
            }

            Console.WriteLine("PCB đã được trả về kho thành công!");
        }
    }
}
