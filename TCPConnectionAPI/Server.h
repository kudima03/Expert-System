#pragma once
#include <string>
#include<thread>
#include<list>
#include"ClientInfo.h"
#include"ServerProtocol.h"
#include"DatabaseContext.h"


class Server
{
protected:

	list<ClientInfo*> clientsInfo; //Содержит сведения о подключенных клиентах
	ServerProtocol protocol; //Отвечает за посылку/прием сущностей
	const unsigned int maxAmountOfConnections = 10;

	//В этом методе происходит взаимодействие с клиентом
	void clientHandler(ClientInfo* client);

	//Авторизация уже существующих пользователей
	unsigned int authorization(SOCKET socket);

	unsigned int registration(SOCKET socket);

	unsigned int userValidation(SOCKET socket);

	//Инициализация сервера по стандартному порту
	Server();

public:

	//Инициализация сервера по заданному порту(лучше использовать этот конструктор)
	Server(unsigned int port);

	//Ожидание завершения потоков клиентов и удаление динамических данных
	~Server();

	//Открытие соединения после инициализации 
	void openConnection();

};
