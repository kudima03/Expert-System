#pragma once
#include<winsock2.h>
#pragma comment (lib, "ws2_32.lib")
#include<thread>
#include<string>

using namespace std;
class ClientInfo
{
protected:

	SOCKET connectionSocket; //����� ���������� � ��������
	string lastIp; //��������� IP �������
	unsigned int clientId; //Id ������� � ���� ������


public:

	//����� �� ��������� �������� �������� ��� ���� �����
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

