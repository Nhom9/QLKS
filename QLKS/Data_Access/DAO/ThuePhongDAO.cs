using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access.DTO;

namespace Data_Access.DAO
{
    public class ThuePhongDAO
    {
        private static ThuePhongDAO instance;


        internal static ThuePhongDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThuePhongDAO();
                return ThuePhongDAO.instance;
            }
            private set { ThuePhongDAO.instance = value; }
        }


        private ThuePhongDAO() { }
        public List<int> ThuePhong(string CMND,string ten,string diaChi  ,string dienthoai ,string tenCongty , List<PHONG> dsPhong)
        {
            List<int> id = new List<int>();
            /// Tạo mới phiếu thuê
            int x = (int)DataProvider.Instance.ExcuteScalar("pInsertThuePhong @CMND , @Ten , @DiaChi , @DienThoai , @TenCongTy ", new object[] { CMND, ten , diaChi , dienthoai , tenCongty});
            
            /// Tạo danh sách các phòng chọn thuê
            foreach(PHONG item in dsPhong)
            {
                int tam = (int)DataProvider.Instance.ExcuteScalar("pInsertChiTietThuePhong @IDMaThue , @IDPhong ", new object[] { x, item.ID });
                id.Add(tam);
            }

            return null;
        }
        public bool Test(string CMND, string ten, string diaChi, string dienthoai, string tenCongty = "", List<PHONG> dsPhong = null)
        {
            ///List<int> id = new List<int>();
            /// Tạo mới phiếu thuê
            ///int x = (int)DataProvider.Instance.ExcuteScalar("pInsertThuePhong @CMND , @Ten , @DiaChi , @DienThoai , @TenCongTy ", new object[] { CMND, ten, diaChi, dienthoai, tenCongty });

            /// Tạo danh sách các phòng chọn thuê
            /*foreach (PHONG item in dsPhong)
            {
                int tam = (int)DataProvider.Instance.ExcuteScalar("pInsertChiTietThuePhong @IDMaThue , @IDPhong ", new object[] { x, item.ID });
                id.Add(tam);
            }

            return id;*/
            ///return (int)DataProvider.Instance.ExcuteScalar("pInsertThuePhong @CMND , @Ten , @DiaChi , @DienThoai , @TenCongTy ", new object[] { CMND, ten, diaChi, dienthoai, "" }) > 0;
            return false;
        }

        public List<THUEPHONG> LoadDSPhieu()
        {
            List < THUEPHONG > tam = new List<THUEPHONG>();
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from dbo.THUEPHONG");
            foreach(DataRow row in data.Rows)
            {
                THUEPHONG temp = new THUEPHONG(row);
                tam.Add(temp);
            }
            return null;
        }
        public THUEPHONG LoadPhieu(int ?id)
        {
            if (id == null)
                return null;
            DataTable data = DataProvider.Instance.ExcuteQuery("pSearchThuePhong @id ",new object[] { id });
            THUEPHONG tam = new THUEPHONG(data.Rows[0]);
            return null;
        }
    }
}
