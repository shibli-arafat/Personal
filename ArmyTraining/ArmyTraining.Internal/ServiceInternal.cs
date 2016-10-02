using System;
using ArmyTraining.DataMapper;
using ArmyTraining.Model;

namespace ArmyTraining.Internal
{
    public class ServiceInternal
    {
        ServiceDataMapper _Data;
        public ServiceInternal()
        {
            _Data = new ServiceDataMapper();
        }
        public ServiceCollection GetServices()
        {
            return _Data.GetServices();
        }

        public Service GetServiceById(int Id)
        {
            return _Data.GetService(Id);
        }

        public void UpdateService(Service service)
        {
            if (_Data.IsDuplicate(service.Id, service.Name))
                throw new ArgumentException(string.Format("The service {0} alaready exists.", service.Name));
            _Data.UpdateService(service);
        }

        public void AddService(Service service)
        {
            if (_Data.IsDuplicate(service.Id, service.Name))
                throw new ArgumentException(string.Format("The service {0} alaready exists.", service.Name));
            _Data.AddService(service);
        }

        public void DeleteService(int id)
        {
            _Data.DeleteService(id);
        }

    }
}
