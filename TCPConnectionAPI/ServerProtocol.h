#pragma once

#include<WinSock2.h>
#pragma comment (lib, "ws2_32.lib")
#include"CommandsBetweenServerAndClient.h"
#include"BinaryFormatter.h"
#include<iostream>

class ServerProtocol
{
protected:

	SOCKADDR_IN serverAddress; //������� ����� �������

	SOCKET listenSocket; //����� �������������

	//�������� ������
	SOCKET createSocket()
	{
		SOCKET l_socket = socket(AF_INET, SOCK_STREAM, NULL);
		if (l_socket == INVALID_SOCKET)
		{
			WSACleanup();
			throw "Listen socket error!";
		}
		bindSocket(l_socket, serverAddress);
		modifySocketToListen(l_socket);
		return l_socket;
	}

	//���������� ������ � ������� �������
	void bindSocket(SOCKET& socket, SOCKADDR_IN address)
	{
		int size = sizeof(address);
		const sockaddr* buf = (sockaddr*)&address;
		if (bind(socket, buf, size) == SOCKET_ERROR)
		{
			throw "Binding failed";
		}
	}

	//����������� ������ �� �������������
	void modifySocketToListen(SOCKET& socket)
	{
		if (listen(socket, SOMAXCONN) == SOCKET_ERROR)
		{
			closesocket(socket);
			WSACleanup();
			throw "Listening failed!";
		}
	}

	//�������� ��������� �������
	void sendServiceCommand(SOCKET destination, ServiceCommands command)
	{
		string commandBuf = to_string((int)command);
		send(destination, commandBuf.c_str(), commandBuf.size(), NULL);
	}

	//��������� ��������� �������
	ServiceCommands receiveServiceCommand(SOCKET from)
	{
		char commandBuf[3];
		memset(commandBuf, '\0', sizeof(commandBuf));
		recv(from, commandBuf, sizeof(commandBuf), NULL);
		return (ServiceCommands)atoi(commandBuf);
	}

public:

	//�������� ������� � ������
	ServerProtocol(unsigned int port)
	{
		WSADATA wsaData;
		WORD dllVersion = MAKEWORD(2, 2);
		if (WSAStartup(dllVersion, &wsaData) == WSAVERNOTSUPPORTED)
		{
			throw "WSAStartup version failure!";
		}
		serverAddress.sin_addr.s_addr = INADDR_ANY;
		serverAddress.sin_port = htons(port);
		serverAddress.sin_family = AF_INET;
		listenSocket = createSocket();
	}

	//��������� ������ �� ������������
	string receiveLogin(SOCKET from)
	{
		char sizeBuf[50];
		memset(sizeBuf, '\0', sizeof(sizeBuf));
		sendServiceCommand(from, ServiceCommands::READY_TO_RECEIVE);
		recv(from, sizeBuf, sizeof(sizeBuf), NULL);
		int loginSize = atoi(sizeBuf);
		char* loginBuf = new char[loginSize];
		sendServiceCommand(from, ServiceCommands::READY_TO_RECEIVE);
		recv(from, loginBuf, loginSize, NULL);
		string login(loginBuf, loginSize);
		delete[] loginBuf;
		sendServiceCommand(from, ServiceCommands::READY_TO_RECEIVE);
		return login;
	}

	//��������� ������ �� ������������
	string receivePassword(SOCKET from)
	{
		char sizeBuf[50];
		memset(sizeBuf, '\0', sizeof(sizeBuf));
		sendServiceCommand(from, ServiceCommands::READY_TO_RECEIVE);
		recv(from, sizeBuf, sizeof(sizeBuf), NULL);
		int passwordSize = atoi(sizeBuf);
		char* passwordBuf = new char[passwordSize];
		sendServiceCommand(from, ServiceCommands::READY_TO_RECEIVE);
		recv(from, passwordBuf, passwordSize, NULL);
		string login(passwordBuf, passwordSize);
		delete[] passwordBuf;
		sendServiceCommand(from, ServiceCommands::READY_TO_RECEIVE);
		return login;
	}

	//���� ������� �� ����������
	SOCKET acceptConnectionRequests(string& clientIpMutable)
	{
		SOCKADDR_IN clientAdress;
		int size = sizeof(clientAdress);
		//�������� ������� �� ����������
		SOCKET newClientSocket = accept(listenSocket, (sockaddr*)&clientAdress, &size);
		clientIpMutable = inet_ntoa(clientAdress.sin_addr);
		return newClientSocket;
	}

	//����������� ��������� ������ �� ������
	template<class SerializableType>
	void sendList(const list<SerializableType>& listToSend, SOCKET destination)
	{
		//������������ ������ � ������
		string serializedString = BinaryFormatter::serialize(listToSend);
		//����������� ������� ��������������� ������ � ������ ��� ��������
		string bufStringSize = to_string(serializedString.size());
		//������� ������� � ���������� � ����� �� �������
		receiveServiceCommand(destination);
		//�������� ������� ��������������� ������
		send(destination, bufStringSize.c_str(), bufStringSize.size(), NULL);
		receiveServiceCommand(destination);
		//�������� ����� ��������������� ������
		send(destination, serializedString.c_str(), serializedString.size(), NULL);
		receiveServiceCommand(destination);
	}

	//���� ��������� ������ �� ������
	template<typename ReceivingType>
	list<ReceivingType> receiveList(SOCKET from)
	{
		char sizeBuf[100];
		//"��������� ������"
		memset(sizeBuf, '\0', sizeof(sizeBuf));
		//�������� ������� � ���������� � �����
		sendServiceCommand(from, ServiceCommands::READY_TO_RECEIVE);
		//�������� ������� ��������������� ������
		recv(from, sizeBuf, sizeof(sizeBuf), NULL);
		//����������� ������� �� ������ � �����
		int size = atoi(sizeBuf);
		//������������ ��������� ������ ��� ����������� ������
		char* buffer = new char[size];
		sendServiceCommand(from, ServiceCommands::READY_TO_RECEIVE);
		//���� ������ 
		recv(from, buffer, size, NULL);
		sendServiceCommand(from, ServiceCommands::READY_TO_RECEIVE);
		//����������� char ������ � string
		string serilizedString(buffer, size);
		//������� ������������� ������
		delete[] buffer;
		return BinaryFormatter::deserialize<ReceivingType>(serilizedString);
	}

	//�������� ������ �������
	void sendAnswer(AnswerFromServer answer, SOCKET destination)
	{
		//����������� ������(�����) � ������
		string buf = to_string((int)answer);
		//�������� ������
		send(destination, buf.c_str(), buf.size(), NULL);
		receiveServiceCommand(destination);
	}

	//���� ������� �� �������
	CommandToServer receiveCommand(SOCKET from)
	{
		//����� ������(�� 999 ������)
		char serverCommandBuf[3];
		//"���������"
		memset(serverCommandBuf, '\0', sizeof(serverCommandBuf));
		//���� � �����
		recv(from, serverCommandBuf, sizeof(serverCommandBuf), NULL);
		sendServiceCommand(from, ServiceCommands::READY_TO_RECEIVE);
		//��������������� � ��� �������
		return (CommandToServer)atoi(serverCommandBuf);
	}

	//�������� ���� ������������(���. ��� ���������)
	void sendTypeOfUser(TypeOfUser type, SOCKET destination)
	{
		//����������� ������� � ������
		string commandBuf = to_string((int)type);
		//��������
		send(destination, commandBuf.c_str(), commandBuf.size(), NULL);
	}

	//���� ���� ������������(���. ��� ���������)
	TypeOfUser receiveTypeOfUser(SOCKET from)
	{
		char commandBuf[3];
		memset(commandBuf, '\0', sizeof(commandBuf));
		recv(from, commandBuf, sizeof(commandBuf), NULL);
		return (TypeOfUser)atoi(commandBuf);
	}

};
