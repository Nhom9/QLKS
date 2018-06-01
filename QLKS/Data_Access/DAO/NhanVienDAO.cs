using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access.DTO;

namespace Data_Access.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;


        public static NhanVienDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhanVienDAO();
                return NhanVienDAO.instance;
            }
            private set { NhanVienDAO.instance = value; }
        }


        private NhanVienDAO() { }

        /*public int Login(string username,string pass)
        {
            
            int data = (int)DataProvider.Instance.ExcuteScalar("pLogin @username , @pass ",new object[] { username, pass });
            return data;            
        }*/
        public NHANVIEN Login(string username, string pass)
        {
            NHANVIEN data = null;
            DataTable dt = DataProvider.Instance.ExcuteQuery("pLogin @username , @pass ", new object[] { username, pass });
            if(dt.Rows.Count == 1)
                data = new NHANVIEN(dt.Rows[0]);
            return data;
        }

        public List<NHANVIEN> LoadNhanVien()
        {
            List<NHANVIEN> result = new List<NHANVIEN>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("pLoadNhanVien");
            foreach(DataRow item in dt.Rows)
            {
                NHANVIEN tmp = new NHANVIEN(item);
                result.Add(tmp);
            }
            return result;

        }

    }
}
