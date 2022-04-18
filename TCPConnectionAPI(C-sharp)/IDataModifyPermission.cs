using System;
using DatabaseEntities;
namespace TCPConnectionAPI_C_sharp_
{
    public interface IDataModifyPermission : IDataViewPermision
    {
        int CreateVehicle(Vehicle newVehicle);
        bool DeleteVehiclesWhere(Func<Vehicle, bool> comparer);
        bool UpdateVehicle(Vehicle newVersion);
    }
}
