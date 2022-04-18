namespace ClassLibraryForTCPConnectionAPI_C_sharp_
{
    public enum CommandsToServer
    {
        Registration,
        Authorization,
        PreviousRoom,
        //Admin commands
        RegisterNewUser,
        BanClient,
        BanExpert,
        UnbanClient,
        UnbanExpert,
        DeleteClient,
        DeleteExpert,
        FindClientByLogin,
        GetAllClients,
        FindExpertByLogin,
        GetAllExperts,
        FindAdminByLogin,
        CreateVehicle,
        ModifyVehicle,
        DeleteVehicle,
        CreateReportAboutVehicles,
        //Expert commands
        RateVehicle, 
        //Client commands
        FindVehiclesByDealer,
        FindVehiclesByColour,
        FindVehiclesByModel,
        FindVehiclesByRegistrationNumber,
        FindVehiclesByRate,
        GetAllVehicles
    }
}
