using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access.DAO;
using Data_Access.DTO;

namespace Data_Access
{
    namespace NhanVien
    {
        public class ConnectClass
        {
            public ConnectClass() { }
            public NHANVIEN Login(string name, string pass)
            {
                return NhanVienDAO.Instance.Login(name, pass);
            }

            public List<NHANVIEN> LoadNhanVien()
            {
                return  NhanVienDAO.Instance.LoadNhanVien();
            }

            public bool Create(NHANVIEN nhanvien)
            {
                return DataProvider.Instance.ExcuteNonQuery("pCreateNhanVien @username ", new object[] { nhanvien.USERNAME }) > 0;
            }
            public NHANVIEN Get(int id)
            {
                return new NHANVIEN(DataProvider.Instance.ExcuteQuery("pGetNhanVien @id", new object[] { id }).Rows[0]);
            }
            public bool Delete(int id)
            {
                return DataProvider.Instance.ExcuteNonQuery("pDeleteNhanVien @id", new object[] { id }) > 0;
            }

            public bool Reset(int id)
            {
                return DataProvider.Instance.ExcuteNonQuery("pResetNhanVien @id", new object[] { id }) > 0;
            }

            public int Change(int id)
            {
                return int.Parse(DataProvider.Instance.ExcuteScalar("pChangeNhanVien @id", new object[] { id }).ToString());
            }


        }
    }
    namespace DichVu
    {
        public class ConnectClass
        {
            public ConnectClass() { }

            public List<DICHVU> LoadDichVu()
            {
                return DichVuDAO.Instance.LoadDichVu();
            }
            public DICHVU GetDichVu(int? id)
            {
                DICHVU temp = null;

                if (id == null)
                    return temp;
                DataTable data = DataProvider.Instance.ExcuteQuery("pGetDichVu @id ", new object[] { id });

                if (data.Rows.Count > 0)
                    temp = new DICHVU(data.Rows[0]);
                return temp;

            }
            public bool Create(DICHVU dichvu)
            {
                return DichVuDAO.Instance.InsertDichVu(dichvu.TEN,(int)dichvu.GIA);
            }
            public bool Edit(DICHVU dichVu)
            {
                return DataProvider.Instance.ExcuteNonQuery("pEditDichVu @id , @ten , @gia ", new object[] { dichVu.ID, dichVu.TEN, dichVu.GIA }) > 0;
            }
            public bool Delete(int id)
            {
                return DataProvider.Instance.ExcuteNonQuery("pDeleteDichVu @id ", new object[] { id }) > 0;
            }
        }

    }
    namespace LoaiPhong
    {
        public class ConnectClass
        {
            public ConnectClass() { }

            public List<LOAIPHONG> LoadLOAIPHONG()
            {
                return LoaiPhongDAO.Instance.LoadLoaiPhong();
            }
            public LOAIPHONG GetLOAIPHONG(int? id)
            {
                return LoaiPhongDAO.Instance.GetLOAIPHONG(id);
            }
            public bool ThemLOAIPHONG(string ten, int gia, string anh, string mota, int soGiuong)
            {
                return LoaiPhongDAO.Instance.InsertLOAIPHONG(ten, gia, anh, mota, soGiuong);
            }
            public bool Create(LOAIPHONG LoaiPhong)
            {
                return DataProvider.Instance.ExcuteNonQuery("pInsertLoaiPhong @Ten , @Gia , @SoLuong , @Anh , @Mota", new object[] { LoaiPhong.TEN, LoaiPhong.DONGIA, LoaiPhong.SOGIUONG,LoaiPhong.ANH, LoaiPhong.MOTA }) > 0;
            }
            public bool Delete(int id)
            {
                return DataProvider.Instance.ExcuteNonQuery("pDeleteLoaiPhong @id", new object[] { id }) > 0;
            }
            public bool SuaLOAIPHONG(LOAIPHONG LOAIPHONG)
            {
                return LoaiPhongDAO.Instance.EditLOAIPHONG(LOAIPHONG);
            }
            public bool XoaLOAIPHONG(LOAIPHONG LOAIPHONG)
            {
                return LoaiPhongDAO.Instance.DeleteLOAIPHONG(LOAIPHONG);
            }
        }
    }
    namespace Phong
    {
        public class ConnectClass
        {
            public List<PHONG> LoadPhong(int? idLoai)
            { 
                return PhongDAO.Instance.LoadPhong(idLoai);
            }

            public List<LoadPhong> LoadPhongTam()
            {
                List<LoadPhong> rs = new List<LoadPhong>();
                DataTable data = DataProvider.Instance.ExcuteQuery("pLoadPhong @status", new object[] { -1 });
                foreach (DataRow item in data.Rows)
                {
                    LoadPhong tam = new LoadPhong(item);
                    rs.Add(tam);
                }
                return rs;
                
            }
        }
    }
    namespace ThuePhong
    {
        public class ConnectClass
        {
            public ConnectClass() { }
            public bool Test(int idPhong, int IDnhanVien, int CMND, string ten, string diaChi, string SDT , string TenCongTy)
            {
                return DataProvider.Instance.ExcuteNonQuery("pCreateThuePhong @idPhong , @idNhanVien , @CMND , @ten , @diaChi , @dienThoai , @tenCongTy ", 
                    new object[] {idPhong,1,CMND,ten,diaChi,SDT,TenCongTy}) > 0;
            }
            public List<LOAIPHONG> LoadLoaiPhong()
            {
                return LoaiPhongDAO.Instance.LoadLoaiPhong();
            }
            public bool Create(SDDV sddv)
            {
                return DataProvider.Instance.ExcuteNonQuery("exec pCreateSDDV @idDV , @idCT , @SoLuong ", new object[] { sddv.IDDV, sddv.IDCT, sddv.SOLUONG }) > 0;
            }
            public bool Create(CHITIETPHONGLOAD ctphong)
            {
                return DataProvider.Instance.ExcuteNonQuery("exec pInsertKhach @idCT , @CMND , @ten , @soDienThoai , @truongphong ", new object[] {
                    ctphong.IDCT, ctphong.CMND, ctphong.HOTEN, ctphong.SoDienThoai, ctphong.TRUONGPHONG}) > 0;
            }
            public List<PHONG> LoadPhong(int? idLoai = null)
            {
                return PhongDAO.Instance.LoadPhong(idLoai);
            }
            public PHONG PGetPhong(int id)
            {
                return new PHONG(DataProvider.Instance.ExcuteQuery("pGetPhong @id", new object[] { id }).Rows[0]);
            }
            public List<NHANVIEN> LoadNhanVien()
            {   
                return NhanVienDAO.Instance.LoadNhanVien();
            }
            public List<THUEPHONGLOAD> LoadThuePhong(int CMND = -1)
            {
                DataTable data = DataProvider.Instance.ExcuteQuery("exec pLoadThuePhong @CMND", new object[] { CMND });
                List<THUEPHONGLOAD> result = new List<THUEPHONGLOAD>();
                foreach (DataRow row in data.Rows)
                {
                    THUEPHONGLOAD temp = new THUEPHONGLOAD(row);
                    result.Add(temp);
                }
                return result;
            }
            public List<SDDVLOAD>  LoadSDDV(int idCT = 0)
            {
                DataTable data = DataProvider.Instance.ExcuteQuery("exec pLoadSDDV @idCT ", new object[] { idCT });
                List<SDDVLOAD> result = new List<SDDVLOAD>();
                foreach (DataRow row in data.Rows)
                {
                    SDDVLOAD temp = new SDDVLOAD(row);
                    result.Add(temp);
                }
                return result;
            }
            public List<CHITIETPHONGLOAD> LoadChiTietPhong(int id = 0)
            {
                DataTable data = DataProvider.Instance.ExcuteQuery("pLoadChiTietPhong @id ", new object[] { id });
                List<CHITIETPHONGLOAD> result = new List<CHITIETPHONGLOAD>();
                foreach (DataRow item in data.Rows)
                {
                    CHITIETPHONGLOAD tamp = new CHITIETPHONGLOAD(item);
                    result.Add(tamp);
                }
                return result;
            }
            public List<SDDVLOAD> LoadDV(int id)
            {
                DataTable data = DataProvider.Instance.ExcuteQuery("pThanhToanDichVu @id ", new object[] { id });
                List<SDDVLOAD> dv = new List<SDDVLOAD>();
                foreach (DataRow item in data.Rows)
                {
                    SDDVLOAD temp = new SDDVLOAD(item);
                    dv.Add(temp);
                }
                return dv;
            }
            public KHACHHANG GetKHACHHANG(int CMND)
            {
                KHACHHANG result = new KHACHHANG(DataProvider.Instance.ExcuteQuery("pGetKhachHang @CMND", new object[] { CMND }).Rows[0]);
                return result;
            }
            public List<DICHVU> LoadDichVu()
            {
                return DichVuDAO.Instance.LoadDichVu();
            }
            public ThanhToanPhong HoaDon(int id,int detail = 0)
            {
                ThanhToanPhong tam = new ThanhToanPhong(DataProvider.Instance.ExcuteQuery("pTongTienKhachSan @id , @detail", new object[] { id, detail }).Rows[0]);
                tam.Sddv = LoadSDDV(id);
                tam.TTKH = GetKHACHHANG(tam.CMND);
                tam.Chitietphong = LoadChiTietPhong(tam.ID);
                tam.phong = PGetPhong(tam.IDPHONG);
                int t = 0;
                object c = DataProvider.Instance.ExcuteScalar("pTongTienDichVu @id ", new object[] { id });
                int.TryParse(c.ToString(), out t);
                tam.TongTienDichVu = t;
                return tam;
            }
            public bool ThanhToan(ThanhToanPhong thanhtoan)
            {
                return DataProvider.Instance.ExcuteNonQuery("pThanhToan @idCt , @TongTien ", new object[] { thanhtoan.ID, thanhtoan.TongTien + thanhtoan.TongTienDichVu }) > 0;
            }
            public int GetID()
            {
                return (int)DataProvider.Instance.ExcuteScalar("select max(ID) from dbo.THUEPHONG");
            }
            //public ThanhToanPhong GetPhieuThue(int id)
            //{
            //    ThanhToanPhong result = new ThanhToanPhong(DataProvider.Instance.ExcuteQuery("exec pGetThuePhong @id", new object[] { id }).Rows[0]);

            //    result.sddv = LoadSDDV(id);
            //    return result;
            //}
        }
    }
    namespace Sddv
    {
        public class ConnectClass
        {
            public ConnectClass() { }
            public List<SDDVLOAD>  LoadSDDV(int idCT = 0)
            {
                DataTable data = DataProvider.Instance.ExcuteQuery("exec pLoadSDDV @idCT ", new object[] { idCT });
                List<SDDVLOAD> result = new List<SDDVLOAD>();
                foreach (DataRow row in data.Rows)
                {
                    SDDVLOAD temp = new SDDVLOAD(row);
                    result.Add(temp);
                }
                return result;
            }

            public bool Create(SDDV sddv)
            {
                return DataProvider.Instance.ExcuteNonQuery("exec pCreateSDDV @idDV , @idCT , @SoLuong ", new object[] { sddv.IDDV, sddv.IDCT, sddv.SOLUONG }) > 0;
            }
            public List<THUEPHONGLOAD> LoadThuePhong(int CMND = 0)
            {
                DataTable data = DataProvider.Instance.ExcuteQuery("exec pLoadThuePhong @CMND", new object[] { CMND });
                List<THUEPHONGLOAD> result = new List<THUEPHONGLOAD>();
                foreach (DataRow row in data.Rows)
                {
                    THUEPHONGLOAD temp = new THUEPHONGLOAD(row);
                    result.Add(temp);
                }
                return result;
            }
            /// <summary>
            /// Mốt xong tui Thiết kế lại thư viện gọi hàm
            /// </summary>
            /// <returns></returns>
            public List<DICHVU> LoadDichVu()
            {
                return DichVuDAO.Instance.LoadDichVu();
            }
            public bool Delete(int id)
            {
                return DataProvider.Instance.ExcuteNonQuery("exec pDeleteSDDV @id ", new object[] { id }) > 0;
            }
        }
    }
    namespace ChiTietPhong
    {
        public class ConnectClass
        {
            public ConnectClass() { }

            public List<PHONG> Loadphong()
            {
                List<PHONG> rs = new List<PHONG>();
                DataTable data = DataProvider.Instance.ExcuteQuery("pLoadPhong");
                foreach (DataRow item in data.Rows)
                {
                    PHONG tam = new PHONG(item);
                    rs.Add(tam);
                }
                return rs;
            }
            public List<THUEPHONGLOAD> LoadThuePhong(int CMND = -1)
            {
                DataTable data = DataProvider.Instance.ExcuteQuery("exec pLoadThuePhong @CMND", new object[] { CMND });
                List<THUEPHONGLOAD> result = new List<THUEPHONGLOAD>();
                foreach (DataRow row in data.Rows)
                {
                    THUEPHONGLOAD temp = new THUEPHONGLOAD(row);
                    result.Add(temp);
                }
                return result;
            }

            public bool Create(CHITIETPHONG ctphong)
            {
                return DataProvider.Instance.ExcuteNonQuery("exec pInsertKhach @idCT , @CMND , @ten , @soDienThoai , @truongphong ", new object[] {
                    ctphong.IDCT, ctphong.CMND, ctphong.HOTEN, ctphong.SDT, ctphong.TRUONGPHONG}) > 0;
            }
            public List<CHITIETPHONGLOAD> LoadChiTietPhong(int id = 0)
            {
                DataTable data = DataProvider.Instance.ExcuteQuery("pLoadCTPhong @id", new object[] { id });
                List<CHITIETPHONGLOAD> result = new List<CHITIETPHONGLOAD>();
                foreach(DataRow item in data.Rows)
                {
                    CHITIETPHONGLOAD tamp = new CHITIETPHONGLOAD(item);
                    result.Add(tamp);
                }
                return result;
            }
        }
    }
    namespace TaiSan
    {
       
        public class ConnectClass
        {
            public List<PHONG> LoadPhong(int? idLoai = null)
            {
                return PhongDAO.Instance.LoadPhong(idLoai);
            }
            
            public List<TAISANLOAD> Load(int id = 1)
            {
                List<TAISANLOAD> item = new List<TAISANLOAD>();

                DataTable data = DataProvider.Instance.ExcuteQuery("pLoadTaiSan @id ", new object[] { id });
                foreach (DataRow row in data.Rows)
                {
                    TAISANLOAD temp = new TAISANLOAD(row);
                    item.Add(temp);
                }
                return item;
            }
            public TAISAN Get(int id)
            {
                return new TAISAN(DataProvider.Instance.ExcuteQuery("pGetTaiSan @id ", new object[] { id }).Rows[0]);
            }
            public bool CreateKHO(TAISAN Taisan)
            {
                return DataProvider.Instance.ExcuteNonQuery("pCreateTaiSanKho @Ten , @loai , @gia , @soLuong , @status ", new object[] { Taisan.TEN, Taisan.LOAI, Taisan.GIA, Taisan.SOLUONG, Taisan.STATUS }) > 0;
            }
            public bool CreatePhong(TAISAN Taisan)
            {
                return DataProvider.Instance.ExcuteNonQuery("pCreateTaiSanPhong @idLoai , @idPhong , @SoLuong", new object[] { Taisan.ID, Taisan.IDPHONG, Taisan.SOLUONG }) > 0;
            }
            public bool EditKHO(TAISAN Taisan)
            {
                return DataProvider.Instance.ExcuteNonQuery("pEditTaiSanKho @id , @Ten , @loai , @gia , @soLuong , @status ", new object[] { Taisan.ID, Taisan.TEN, Taisan.LOAI, Taisan.GIA, Taisan.SOLUONG, Taisan.STATUS }) > 0;
            }
            public bool Delete(int id)
            {
                return DataProvider.Instance.ExcuteNonQuery("pDeleteTaiSan @id ", new object[] { id }) > 0;
            }
        }
    }
}
