using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DAO
{
    public class ChiTietThuePhongDAO
    {
        private static ChiTietThuePhongDAO instance;


        internal static ChiTietThuePhongDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietThuePhongDAO();
                return ChiTietThuePhongDAO.instance;
            }
            private set { ChiTietThuePhongDAO.instance = value; }
        }


        private ChiTietThuePhongDAO() { }
        
    }
}
