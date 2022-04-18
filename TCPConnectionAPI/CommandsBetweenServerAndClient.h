#pragma once

/// <summary>
/// ��� ������� ������� � ������ �� ������� ��������� � ��� ��������� enum class (��������� �� 999 ������)
/// Service Commands �� �������, ������������ � ���������� ������ ������� � �������
/// </summary>

enum class CommandToServer
{
	AUTHORIZATION,
	REGISTRATION,
	CLOSE_CONNECTION
};

enum class AnswerFromServer
{
	SUCCESSFULLY,
	VALIDATION_ERROR,
	REGISTRATION_ERROR
};

enum class TypeOfUser
{
	UNDEFINED,
	ADMIN,
	CLIENT, 
	EXPERT
};

enum class ServiceCommands
{
	READY_TO_RECEIVE,
};