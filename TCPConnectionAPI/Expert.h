#pragma once
#include "User.h"
class Expert :
    public User
{
protected:



public:

    // ������������ ����� User
    virtual void setLogin(const std::string& login) override;
    virtual void setPassword(const std::string& login) override;
};

