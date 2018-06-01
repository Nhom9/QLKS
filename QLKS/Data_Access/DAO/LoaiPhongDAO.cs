using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access.DTO;

namespace Data_Access.DAO
{
    public class LoaiPhongDAO
    {
        private static LoaiPhongDAO instance;


        internal static LoaiPhongDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiPhongDAO();
                return LoaiPhongDAO.instance;
            }
            private set { LoaiPhongDAO.instance = value; }
        }


        private LoaiPhongDAO() { }

        public List<LOAIPHONG> LoadLoaiPhong()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("pLoadLOAIPHONG");
            List<LOAIPHONG> res = new List<LOAIPHONG>();
            foreach (DataRow item in data.Rows)
            {
                LOAIPHONG temp = new LOAIPHONG(item);
                res.Add(temp);
            }
            return res;
        }

        public LOAIPHONG GetLOAIPHONG(int? id)
        {
            LOAIPHONG temp = null;

            if (id == null)
                return temp;
            DataTable data = DataProvider.Instance.ExcuteQuery("pGetLOAIPHONG @id ", new object[] { id });

            if (data.Rows.Count > 0)
                temp = new LOAIPHONG(data.Rows[0]);
            return temp;
        }
        public bool InsertLOAIPHONG(string ten, int gia,string anh, string mota,int soGiuong)
        {
            return DataProvider.Instance.ExcuteNonQuery("pInsertLOAIPHONG @ten , @gia , @soGiuong , @anh , @mota ", new object[] { ten, gia, soGiuong, anh, mota }) > 0;
        }
        public bool EditLOAIPHONG(LOAIPHONG LOAIPHONG)
        {
            return DataProvider.Instance.ExcuteNonQuery("pEditLOAIPHONG @id , @ten , @gia , @soGiuong , @anh , @mota ", new object[] { LOAIPHONG.ID, LOAIPHONG.TEN, LOAIPHONG.DONGIA,LOAIPHONG.SOGIUONG,LOAIPHONG.ANH,LOAIPHONG.MOTA }) > 0;
        }
        public bool DeleteLOAIPHONG(LOAIPHONG LOAIPHONG)
        {
            return DataProvider.Instance.ExcuteNonQuery("pDeleteLOAIPHONG @id ", new object[] { LOAIPHONG.ID }) > 0;
        }
    }
}
