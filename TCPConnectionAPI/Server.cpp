#include "Server.h"
#include"BinaryFormatter.h"

void Server::clientHandler(ClientInfo* client)
{
	//TODO: Всю логику взаимодействию с клиентом писать здесь
	//с помощью наборов команд (CommandToServer и AnswerFromServer)
	//команды добавлять в уже созданные enum class "CommandsBetweenServerAndClient.h"
	//Пользоваться receiveCommand и SendCommand, определенные в классе
}

unsigned int Server::authorization(SOCKET socket)
{
	const string login = protocol.receiveLogin(socket);
	const string password = protocol.receivePassword(socket);
	unsigned int id = 0;
	id = DatabaseContext::findAdmin(login, password).getId();
	if (id > 0) { protocol.sendTypeOfUser(TypeOfUser::ADMIN, socket); return id; }
	id = DatabaseContext::findClient(login, password).getId();
	if (id > 0) { protocol.sendTypeOfUser(TypeOfUser::CLIENT, socket); return id; }
	id = DatabaseContext::findExpert(login, password).getId();
	if (id > 0) { protocol.sendTypeOfUser(TypeOfUser::EXPERT, socket); return id; }
	protocol.sendTypeOfUser(TypeOfUser::UNDEFINED, socket);
	return 0;
}

unsigned int Server::registration(SOCKET socket)
{
	const TypeOfUser typeofUser = protocol.receiveTypeOfUser(socket);
	const string login = protocol.receiveLogin(socket);
	const string password = protocol.receivePassword(socket);
	switch (typeofUser)
	{
	case TypeOfUser::ADMIN:
	{
		unsigned int id = DatabaseContext::registerAdmin(login, password);
		if (id > 0) { protocol.sendAnswer(AnswerFromServer::SUCCESSFULLY, socket); return id; };
	}
	case TypeOfUser::CLIENT:
	{
		unsigned int id = DatabaseContext::registerClient(login, password);
		if (id > 0) { protocol.sendAnswer(AnswerFromServer::SUCCESSFULLY, socket); return id; };
	}
	case TypeOfUser::EXPERT:
	{
		unsigned int id = DatabaseContext::registerExpert(login, password);
		if (id > 0) { protocol.sendAnswer(AnswerFromServer::SUCCESSFULLY, socket); return id; };
	}
	default:
		return 0;
	}
	protocol.sendAnswer(AnswerFromServer::REGISTRATION_ERROR, socket);
	return 0;
}

unsigned int Server::userValidation(SOCKET socket)
{
	while (true)
	{
		switch (protocol.receiveCommand(socket))
		{
		case CommandToServer::AUTHORIZATION:
		{
			unsigned int id = authorization(socket);
			if (id == 0) { continue; }
			else { return id; }
		}
		case CommandToServer::REGISTRATION:
		{
			unsigned int id = registration(socket);
			if (id == 0) { continue; }
			else { return id; }
		}
		case CommandToServer::CLOSE_CONNECTION:
			return 0;
		default:
			break;
		}
	}
}

Server::Server()
	: protocol(1111)
{
}

Server::Server(unsigned int port)
	: protocol(port)
{

}

Server::~Server()
{
	for (auto& i : clientsInfo)
	{
		i->clientThread->join();
		delete i->clientThread;
		delete i;
	}
}

void Server::openConnection()
{
	for (size_t i = 0; i < maxAmountOfConnections; i++)
	{
		string newClientIp;
		//Копирование сокета нового клиета 
		SOCKET newClientSocket = protocol.acceptConnectionRequests(newClientIp);
		//Вывод IP нового клиета
		std::cout << "Client connected with IP: " << newClientIp << std::endl;
		//Создание объекта клиента
		ClientInfo* newClient = new ClientInfo(newClientSocket, newClientIp);
		thread* newClientThread = new thread([&]()
		{
			unsigned int id = userValidation(newClientSocket);
			if (id > 0)
			{
				newClient->setClientId(id);
				clientHandler(newClient);
			}
			else
			{
				std::cout << "Client disconnected" << endl;
			}
		});
		newClient->clientThread = newClientThread;
		clientsInfo.push_back(newClient);
	}
}
