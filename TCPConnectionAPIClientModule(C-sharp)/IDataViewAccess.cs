using DatabaseEntities;
using System.Collections.Generic;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    public interface IDataViewAccess
    {
        List<Vehicle> FindVehicleWithColour(string colour);
        List<Vehicle> FindVehicleWithDealer(string dealer);
        List<Vehicle> FindVehicleWithModel(string model);
        List<Vehicle> FindVehicleWithRegistrationNumber(string number);
        List<Vehicle> FindVehicleWithTotalRate(double rate);
        List<Vehicle> GetAllVehicles();
    }
}
