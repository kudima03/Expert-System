#pragma once
#include"Admin.h"
#include"Client.h"
#include"Expert.h"
//ћодуль взаимодействи€ с базой данных
class DatabaseContext
{
public:

	static Client findClient(const std::string& login, const std::string& password);

	static Admin findAdmin(const std::string& login, const std::string& password);

	static Expert findExpert(const std::string& login, const std::string& password);

	static Admin findAdmin(unsigned int id);

	static Client findClient(unsigned int id);

	static Expert findExpert(unsigned int id);

	static unsigned int registerAdmin(const std::string& login, const std::string& password);

	static unsigned int registerClient(const std::string& login, const std::string& password);

	static unsigned int registerExpert(const std::string& login, const std::string& password);

};

