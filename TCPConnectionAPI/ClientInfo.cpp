#include "ClientInfo.h"

ClientInfo::ClientInfo()
{
	connectionSocket = 0;
	lastIp = "";
	clientId = 0;
}

ClientInfo::ClientInfo(SOCKET connectionSocket, const string& lastIp) : ClientInfo()
{
	this->connectionSocket = connectionSocket;
	this->lastIp = lastIp;
}

void ClientInfo::setClientId(unsigned int clientId)
{
	if (clientId>0)
	{
		this->clientId = clientId;
	}
}

unsigned int ClientInfo::getClientId() const
{
	return clientId;
}

SOCKET ClientInfo::getConnectionSocket() const
{
	return connectionSocket;
}

string ClientInfo::getLastIp() const
{
	return lastIp;
}

bool ClientInfo::operator==(const ClientInfo& other) const
{
	return connectionSocket == other.connectionSocket && lastIp == other.lastIp;
}

bool ClientInfo::operator!=(const ClientInfo& other) const
{
	return !this->operator==(other);
}
