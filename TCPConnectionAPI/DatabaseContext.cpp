#include "DatabaseContext.h"

Client DatabaseContext::findClient(const std::string& login, const std::string& password)
{
    return Client();
}

Admin DatabaseContext::findAdmin(const std::string& login, const std::string& password)
{
    return Admin();
}

Expert DatabaseContext::findExpert(const std::string& login, const std::string& password)
{
    return Expert();
}

Admin DatabaseContext::findAdmin(unsigned int id)
{
    return Admin();
}

Client DatabaseContext::findClient(unsigned int id)
{
    return Client();
}

Expert DatabaseContext::findExpert(unsigned int id)
{
    return Expert();
}

unsigned int DatabaseContext::registerAdmin(const std::string& login, const std::string& password)
{
    return 0;
}

unsigned int DatabaseContext::registerClient(const std::string& login, const std::string& password)
{
    return 0;
}

unsigned int DatabaseContext::registerExpert(const std::string& login, const std::string& password)
{
    return 0;
}
