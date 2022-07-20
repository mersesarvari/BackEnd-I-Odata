﻿using Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DeviceRepository : IDeviceRepository
    {
        public IList<Device> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var devices = session
                    .CreateCriteria(typeof(Device))
                    .List<Device>();
                return devices;
            }
        }
        public Device Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<Device>(id);
        }


        public void Post(Device obj)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(obj);
                transaction.Commit();
            }
        }

        public void Put(Device obj)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(obj);
                transaction.Commit();
            }
        }

        public void Delete(int id)
        {
            var obj = Get(id);
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(obj);
                transaction.Commit();
            }
        }



    }
}
