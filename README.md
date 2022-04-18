Expert system is designed for making decisions in car markets field.
System designed in client-server architecture (3 layers: client app(WPF), server, MSSql database).
Connection implemented with the help of custom protocol based on TCP interaction (supplies commands, objects, collections transfer using binary serialization)
Connected client is running in separate thread (Multithreading realization)
3 possible type of users: Client(only viewing), Expert(viewing, rating entities), Admin(entities CRUD, users CRUD)
User's abilities are separeted by ISP, most of classes support SRP, DIP.
