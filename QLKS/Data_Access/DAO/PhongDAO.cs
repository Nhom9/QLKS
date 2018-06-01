using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access.DTO;

namespace Data_Access.DAO
{
    public class PhongDAO
    {
        private static PhongDAO instance;


        internal static PhongDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhongDAO();
                return PhongDAO.instance;
            }
            private set { PhongDAO.instance = value; }
        }


        private PhongDAO() { }
        public List<PHONG> LoadPhong(int? id)
        {
            if (id == null)
                return null;
            List<PHONG> rs = new List<PHONG>();
            DataTable data = DataProvider.Instance.ExcuteQuery("pLoadDSPhong @idLoai", new object[] { id });
            foreach(DataRow item in data.Rows)
            {
                PHONG tam = new PHONG(item);
                rs.Add(tam);
            }
            return rs;
        }

    }
}
