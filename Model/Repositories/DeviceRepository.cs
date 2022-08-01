﻿using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Model
{
    public class DeviceRepository : IDeviceRepository
    {
        RentalDBContext db;
        public DeviceRepository(RentalDBContext _db)
        {
            this.db = _db;
        }
        public IList<Device> GetAll()
        {
            return db.Devices.ToArray();
        }
        public Device Get(int id)
        {
            return db.Devices.FirstOrDefault(t => t.Id == id);
        }

        public void Post(Device obj)
        {
            db.Devices.Add(obj);
            db.SaveChanges();
        }

        public void Put(int key, Device obj)
        {
            var entity = db.Devices.Find(key);
            if (entity == null)
            {
                throw new Exception("Not found");
            }
            db.SaveChangesAsync();
        }
        public void Patch(int key,Delta<Device> obj)
        {
            var entity = db.Devices.Find(key);
            if (entity == null)
            {
                throw new Exception("Not found");
            }
            obj.Patch(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Get(id));
            db.SaveChanges();
        }



    }
}
