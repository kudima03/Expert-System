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

	list<ClientInfo*> clientsInfo; //�������� �������� � ������������ ��������
	ServerProtocol protocol; //�������� �� �������/����� ���������
	const unsigned int maxAmountOfConnections = 10;

	//� ���� ������ ���������� �������������� � ��������
	void clientHandler(ClientInfo* client);

	//����������� ��� ������������ �������������
	unsigned int authorization(SOCKET socket);

	unsigned int registration(SOCKET socket);

	unsigned int userValidation(SOCKET socket);

	//������������� ������� �� ������������ �����
	Server();

public:

	//������������� ������� �� ��������� �����(����� ������������ ���� �����������)
	Server(unsigned int port);

	//�������� ���������� ������� �������� � �������� ������������ ������
	~Server();

	//�������� ���������� ����� ������������� 
	void openConnection();

};
