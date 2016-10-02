using System;
using System.Collections.Generic;
using DefenseTraining.Dal;
using DefenseTraining.Model;

namespace DefenseTraining.Bol
{
    public class ServiceBol
    {
        private ServiceDal _Dal;

        public ServiceBol()
        {
            _Dal = new ServiceDal();
        }

        public List<Service> GetServices()
        {
            return _Dal.GetServices();
        }

        public void DeleteService(int id)
        {
            _Dal.DeleteService(id);
        }

        public Service SaveService(Service service)
        {
            if (_Dal.ServiceExists(service.Id, service.Name))
                throw new Exception("Service with the same name already exists. Please enter unique service name.");
            service.Id = _Dal.SaveService(service);
            return service;
        }
    }
}
