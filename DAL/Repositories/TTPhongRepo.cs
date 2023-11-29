﻿using A_DAL.IRepositories;
using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DAL.Repositories
{
    public class TTPhongRepo : ITTPhongRepo
    {
        MyDbContext _context = new MyDbContext();

        public TTPhongRepo()
        {
            
        }

        public TTPhongRepo(MyDbContext context)
        {
            _context = context;
        }

        public bool AddTTPhong(TrangThaiPhong trangThaiPhong)
        {
            try
            {
                _context.TrangThaiPhongs.Add(trangThaiPhong);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TrangThaiPhong FindTTPhong(int id)
        {
            return _context.TrangThaiPhongs.Find(id);
        }

        public List<TrangThaiPhong> GetTTPhong()
        {
            return _context.TrangThaiPhongs.ToList();
        }

        public bool UpdateTTPhong(TrangThaiPhong trangThaiPhong)
        {
            try
            {
                var updateTTPhong = FindTTPhong(trangThaiPhong.IdNgay);
                updateTTPhong.TrangThai = trangThaiPhong.TrangThai;
                updateTTPhong.Ngay = trangThaiPhong.Ngay;
                updateTTPhong.IdPhong = trangThaiPhong.IdPhong;
                updateTTPhong.IdCaKham = trangThaiPhong.IdCaKham;
                updateTTPhong.Phong = trangThaiPhong.Phong;
                updateTTPhong.CaKham = trangThaiPhong.CaKham;
                _context.TrangThaiPhongs.Update(updateTTPhong);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
