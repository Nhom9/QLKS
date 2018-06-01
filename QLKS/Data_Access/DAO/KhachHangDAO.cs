using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;


        internal static KhachHangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangDAO();
                return KhachHangDAO.instance;
            }
            private set { KhachHangDAO.instance = value; }
        }


        private KhachHangDAO() { }

    }
}
