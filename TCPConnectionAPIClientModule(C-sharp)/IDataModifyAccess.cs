using ClassLibraryForTCPConnectionAPI_C_sharp_;
using DatabaseEntities;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    public interface IDataModifyAccess : IDataViewAccess   
    {
        AnswerFromServer CreateVehicle(Vehicle newVehicle);
        AnswerFromServer ModifyVehicle(Vehicle newVersion);
        AnswerFromServer DeleteVehicle(int id);
    }
}
