using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DAO
{
    public class TaiSanDAO
    {
        private static TaiSanDAO instance;


        internal static TaiSanDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TaiSanDAO();
                return TaiSanDAO.instance;
            }
            private set { TaiSanDAO.instance = value; }
        }


        private TaiSanDAO() { }
    }
}
