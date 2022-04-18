#pragma once
#include<winsock2.h>
#pragma comment (lib, "ws2_32.lib")
#include<thread>
#include<string>

using namespace std;
class ClientInfo
{
protected:

	SOCKET connectionSocket; //—окет соединени€ с клиентом
	string lastIp; //ѕоследний IP клиента
	unsigned int clientId; //Id клиента в базе данных


public:

	// ласс не выполн€ет никакого контрол€ над этим полем
	thread* clientThread;

	ClientInfo();

	ClientInfo(SOCKET connectionSocket, const string& lastIp);

	void setClientId(unsigned int clientId);

	unsigned int getClientId()const;

	SOCKET getConnectionSocket() const;

	string getLastIp()const;

	bool operator == (const ClientInfo& other) const;

	bool operator != (const ClientInfo& other) const;

};

