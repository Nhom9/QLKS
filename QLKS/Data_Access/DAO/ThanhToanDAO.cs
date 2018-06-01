using Data_Access.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DAO
{
    class ThanhToanDAO
    {
        private static ThanhToanDAO instance;


        internal static ThanhToanDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThanhToanDAO();
                return ThanhToanDAO.instance;
            }
            private set { ThanhToanDAO.instance = value; }
        }


        private ThanhToanDAO() { }

        public List<SDDVLOAD> LoadDV(int id)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("pThanhToanDichVu @id ", new object[] { id });
            List<SDDVLOAD> dv = new List<SDDVLOAD>();
            foreach(DataRow item in data.Rows)
            {
                SDDVLOAD temp = new SDDVLOAD(item);
                dv.Add(temp);
            }
            return dv;
        }
        public KHACHHANG GetKHACHHANG(int CMND)
        {
            KHACHHANG result = new KHACHHANG(DataProvider.Instance.ExcuteQuery("pGetKhachHang @CMND",new object[] { CMND }).Rows[0]);
            return result;
        }
        public ThanhToanPhong HoaDon(int id)
        {
            ThanhToanPhong tam = new ThanhToanPhong(DataProvider.Instance.ExcuteQuery("pTongTienKhachSan @id", new object[] { id }).Rows[0]);
            tam.Sddv = LoadDV(id);
            tam.TTKH = GetKHACHHANG(tam.CMND);
            return tam;
        }
    }
}
