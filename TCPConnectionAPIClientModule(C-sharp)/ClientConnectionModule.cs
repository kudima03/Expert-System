using ClassLibraryForTCPConnectionAPI_C_sharp_;
using DatabaseEntities;
using System.Collections.Generic;
using System.Linq;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    public class ClientConnectionModule : IAdminAccess, IExpertAccess, IClientAccess
    {
        protected IUserProtocol protocol;

        protected static int amountOfObjects;

        public bool Connected { get; }

        public ClientConnectionModule()
        {
            protocol = new TCPClientProtocol();
            if (amountOfObjects == 0)
            {
                Connected = protocol.Connect();
            }
            amountOfObjects++;
        }

        public TypeOfUser Authorization(string login, string password)
        {
            protocol.SendCommand(CommandsToServer.Authorization);
            protocol.SendLogin(login);
            protocol.SendPassword(password);
            return protocol.ReceiveTypeOfUser();
        }

        public AnswerFromServer Registration<T>(TypeOfUser type, T user) where T : class
        {
            protocol.SendCommand(CommandsToServer.Registration);
            protocol.SendTypeOfUser(type);
            protocol.SendObject<T>(user);
            return protocol.ReceiveAnswerFromServer();
        }

        public AnswerFromServer Rate(int entityId, float Rate)
        {
            protocol.SendCommand(CommandsToServer.RateVehicle);
            protocol.SendString(entityId.ToString());
            protocol.SendString(Rate.ToString());
            return protocol.ReceiveAnswerFromServer();
        }

        public void PreviousRoom()
        {
            protocol.GoToPreviousRoom();
        }

        public Client FindClientByLogin(string login)
        {
            protocol.SendCommand(CommandsToServer.FindClientByLogin);
            protocol.SendLogin(login);
            var received = protocol.ReceiveCollection<Client>();
            if (received.Count == 0 || received.Count > 1)
            {
                return new Client();
            }
            else
            {
                return received.First();
            }
        }

        public Expert FindExpertByLogin(string login)
        {
            protocol.SendCommand(CommandsToServer.FindExpertByLogin);
            protocol.SendLogin(login);
            var received = protocol.ReceiveCollection<Expert>();
            if (received.Count == 0 || received.Count > 1)
            {
                return new Expert();
            }
            else
            {
                return received.First();
            }
        }

        public Admin FindAdminByLogin(string login)
        {
            protocol.SendCommand(CommandsToServer.FindAdminByLogin);
            protocol.SendLogin(login);
            var received = protocol.ReceiveCollection<Admin>();
            if (received.Count == 0 || received.Count > 1)
            {
                return new Admin();
            }
            else
            {
                return received.First();
            }
        }

        public AnswerFromServer RegisterNewAdmin(Admin admin)
        {
            protocol.SendCommand(CommandsToServer.RegisterNewUser);
            protocol.SendTypeOfUser(TypeOfUser.Admin);
            protocol.SendObject(admin);
            return protocol.ReceiveAnswerFromServer();
        }

        public AnswerFromServer RegisterNewClient(Client client)
        {
            protocol.SendCommand(CommandsToServer.RegisterNewUser);
            protocol.SendTypeOfUser(TypeOfUser.Client);
            protocol.SendObject(client);
            return protocol.ReceiveAnswerFromServer();
        }

        public AnswerFromServer RegisterNewExpert(Expert expert)
        {
            protocol.SendCommand(CommandsToServer.RegisterNewUser);
            protocol.SendTypeOfUser(TypeOfUser.Expert);
            protocol.SendObject(expert);
            return protocol.ReceiveAnswerFromServer();
        }

        public AnswerFromServer BanClientWith(string login)
        {
            protocol.SendCommand(CommandsToServer.BanClient);
            protocol.SendLogin(login);
            return protocol.ReceiveAnswerFromServer();
        }

        public AnswerFromServer BanExpertWith(string login)
        {
            protocol.SendCommand(CommandsToServer.BanExpert);
            protocol.SendLogin(login);
            return protocol.ReceiveAnswerFromServer();
        }

        public AnswerFromServer UnbanExpertWith(string login)
        {
            protocol.SendCommand(CommandsToServer.UnbanExpert);
            protocol.SendLogin(login);
            return protocol.ReceiveAnswerFromServer();
        }

        public AnswerFromServer UnbanClientWith(string login)
        {
            protocol.SendCommand(CommandsToServer.UnbanExpert);
            protocol.SendLogin(login);
            return protocol.ReceiveAnswerFromServer();
        }

        public AnswerFromServer DeleteExpertWith(string login)
        {
            protocol.SendCommand(CommandsToServer.DeleteExpert);
            protocol.SendLogin(login);
            return protocol.ReceiveAnswerFromServer();
        }

        public AnswerFromServer DeleteClientWith(string login)
        {
            protocol.SendCommand(CommandsToServer.DeleteClient);
            protocol.SendLogin(login);
            return protocol.ReceiveAnswerFromServer();
        }

        public List<Vehicle> FindVehicleWithColour(string colour)
        {
            protocol.SendCommand(CommandsToServer.FindVehiclesByColour);
            protocol.SendString(colour);
            return protocol.ReceiveCollection<Vehicle>();
        }

        public List<Vehicle> FindVehicleWithDealer(string dealer)
        {
            protocol.SendCommand(CommandsToServer.FindVehiclesByDealer);
            protocol.SendString(dealer);
            return protocol.ReceiveCollection<Vehicle>();
        }

        public List<Vehicle> FindVehicleWithModel(string model)
        {
            protocol.SendCommand(CommandsToServer.FindVehiclesByModel);
            protocol.SendString(model);
            return protocol.ReceiveCollection<Vehicle>();
        }

        public List<Vehicle> FindVehicleWithRegistrationNumber(string number)
        {
            protocol.SendCommand(CommandsToServer.FindVehiclesByRegistrationNumber);
            protocol.SendString(number);
            return protocol.ReceiveCollection<Vehicle>();
        }

        public List<Vehicle> FindVehicleWithTotalRate(double rate)
        {
            protocol.SendCommand(CommandsToServer.FindVehiclesByRate);
            protocol.SendString(rate.ToString());
            return protocol.ReceiveCollection<Vehicle>();
        }

        public AnswerFromServer CreateVehicle(Vehicle newVehicle)
        {
            protocol.SendCommand(CommandsToServer.CreateVehicle);
            protocol.SendObject(newVehicle);
            return protocol.ReceiveAnswerFromServer();
        }

        public AnswerFromServer ModifyVehicle(Vehicle newVersion)
        {
            protocol.SendCommand(CommandsToServer.ModifyVehicle);
            protocol.SendObject(newVersion);
            return protocol.ReceiveAnswerFromServer();
        }

        public AnswerFromServer DeleteVehicle(int id)
        {
            protocol.SendCommand(CommandsToServer.DeleteVehicle);
            protocol.SendString(id.ToString());
            return protocol.ReceiveAnswerFromServer();
        }

        public string GetReportAboutVehicle()
        {
            protocol.SendCommand(CommandsToServer.CreateReportAboutVehicles);
            return protocol.ReceiveString();
        }

        public List<Client> GetAllClients()
        {
            protocol.SendCommand(CommandsToServer.GetAllClients);
            return protocol.ReceiveCollection<Client>();
        }

        public List<Expert> GetAllExperts()
        {
            protocol.SendCommand(CommandsToServer.GetAllExperts);
            return protocol.ReceiveCollection<Expert>();
        }

        public List<Vehicle> GetAllVehicles()
        {
            protocol.SendCommand(CommandsToServer.GetAllVehicles);
            return protocol.ReceiveCollection<Vehicle>();
        }

        public AnswerFromServer ModifyClient(Client client)
        {
            protocol.SendCommand(CommandsToServer.ModifyClient);
            protocol.SendObject(client);
            return protocol.ReceiveAnswerFromServer();
        }

        public AnswerFromServer ModifyExpert(Expert expert)
        {
            protocol.SendCommand(CommandsToServer.ModifyExpert);
            protocol.SendObject(expert);
            return protocol.ReceiveAnswerFromServer();
        }

        public AnswerFromServer RateVehicle(int vehicleId, float expertRate)
        {
            protocol.SendCommand(CommandsToServer.RateVehicle);
            protocol.SendString(vehicleId.ToString());
            protocol.SendString(expertRate.ToString());
            return protocol.ReceiveAnswerFromServer();
        }
    }
}
