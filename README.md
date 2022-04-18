Expert system is designed for making decisions in car markets field.
System designed in client-server architecture (3 layers: client app(WPF), server, MSSql database).
Connection implemented with the help of custom protocol based on TCP interaction (supplies commands, objects, collections transfer using binary serialization)
Connected client is running in separate thread (Multithreading realization)
3 possible type of users: Client(only viewing), Expert(viewing, rating entities), Admin(entities CRUD, users CRUD)
User's abilities are separeted by ISP, most of classes support SRP, DIP.



Some screen shots



![image](https://user-images.githubusercontent.com/93078951/163868351-2bf2a62f-3b3c-4722-beba-85687a73312f.png)
![image](https://user-images.githubusercontent.com/93078951/163868483-8d2302de-790f-4cfb-a178-317152f43d33.png)
![image](https://user-images.githubusercontent.com/93078951/163868550-720b068d-735d-49cd-8566-9ee2a9e5375e.png)
