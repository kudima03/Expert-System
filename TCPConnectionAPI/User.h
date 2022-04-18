#pragma once
#include<string>
//������� ����� ��� ���� ������� �������
class User
{
protected:

	unsigned int id;
	std::string login;
	std::string password;

public:

	User();
	User(const std::string& login, const std::string& password);
	User(const User& other);
	virtual ~User();
	virtual void setId(unsigned int id);
	virtual unsigned int getId()const;
	virtual void setLogin(const std::string& login) {};
	virtual void setPassword(const std::string& password) {};
	virtual std::string getPasword()const;
	virtual std::string getLogin()const;

};

