using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access.DTO;

namespace Data_Access.DAO
{
    public class DichVuDAO
    {
        private static DichVuDAO instance;


        internal static DichVuDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DichVuDAO();
                return DichVuDAO.instance;
            }
            private set { DichVuDAO.instance = value; }
        }


        private DichVuDAO() { }

        public List<DICHVU> LoadDichVu()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("pLoadDichVu");
            List<DICHVU> res = new List<DICHVU>();
            foreach(DataRow item in data.Rows)
            {
                DICHVU temp = new DICHVU(item);
                res.Add(temp);
            }
            return res;
        }

        public DICHVU GetDichVu(int ?id)
        {
            DICHVU temp = null ;

            if (id == null)
                return temp;
            DataTable data = DataProvider.Instance.ExcuteQuery("pGetDichVu @id ", new object[] { id });

            if (data.Rows.Count > 0)
                temp = new DICHVU(data.Rows[0]);
            return temp;
        }
        public bool InsertDichVu(string ten, int gia)
        {
            return DataProvider.Instance.ExcuteNonQuery("pInsertDichVu @ten , @gia ", new object[] { ten,gia }) > 0;
        }
        public bool EditDichVu(DICHVU dichVu)
        {
            return DataProvider.Instance.ExcuteNonQuery("pEditDichVu @id , @ten , @gia ", new object[] { dichVu.ID, dichVu.TEN, dichVu.GIA}) > 0;
        }
        public bool DeleteDichVu(DICHVU dichVu)
        {
            return DataProvider.Instance.ExcuteNonQuery("pDeleteDichVu @id ", new object[] { dichVu.ID}) > 0;
        }
    }
}
