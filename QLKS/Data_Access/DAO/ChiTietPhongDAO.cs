using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DAO
{
    public class ChiTietPhongDAO
    {
        private static ChiTietPhongDAO instance;


        internal static ChiTietPhongDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietPhongDAO();
                return ChiTietPhongDAO.instance;
            }
            private set { ChiTietPhongDAO.instance = value; }
        }


        private ChiTietPhongDAO() { }
        public bool ChiTietPhong(int idCT, string hoten, string cmnd, byte truongphong = 0)
        {
            return DataProvider.Instance.ExcuteNonQuery("pInsertChiTietPhong @idCT , @hoTen , @CMND , @truongphong ", new object[] { idCT, hoten, cmnd, truongphong }) > 0;
        }
    }
}
