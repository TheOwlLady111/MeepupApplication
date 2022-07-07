# MeetupApplication
Here is web application for management events. I will explain how to start and use it. During this steps I will also describe the endpoints of MeetupApp. Let’s start!

**1.** First of all you should download this repository to your machine. When you open the solution you will see several projects here. Let’s overview them.
		
**Data Layer**: This is layer for working with data. It means, that here we will do our requests to database for requirement information.
	
**Business Layer**: This layer is responsible for business logic. Here we will transform data from data layer to models, catch exceptions and etc.

**MeetupApp**: This is layer for our api. Here we will have requests, send responses.
		
**MeetupDatabase**: This is project for our database. And in our second step we will work with it.
    
**2.** For now you should go to MeetupDatabase project. Here you will see **MeetupDatabase.publish.xml file.** 
This is file for publishing database on **(localdb)\MSSQLLocalDB** server. Just click on this file and push button publish. 
After this you will have MeetupDatabase with data.

**3.** So we have database with some data and that means we can move forward for testing the abilities of this app.
here two roles in this app(User and Admin). They should be authorized. In step for we will talk about it. 
For now I will descried the abilities of authorized and not authorized persons. 

Same abilities of authorized and not authorized persons:
* Everyone can get the list of events;
* Everyone can get each of event using id;
* Everyone have ability to register to this app and become “User”;

Extra abilities of person with role “User”:
* User can change information about oneself;
* User can delete his account;
	
Extra abilities of person with role “Admin”:
* Admin can get list of users, get user by id, change information and delete concreate user;
* Admin can get list of speakers, get speaker by id, change information and delete concreate speaker;
* Admin can get list of events, get event by id, change information and delete concreate event;

**4.** In this app you can be authorized with role “User” or “Admin”. If you want to check abilities of app like admin, you can use the next credentials:
		
**Login: “adminKate”**
**Password: “123456qwe”**	

If you want to be authorized as user, you can register, then login or you can use the next credentials:
		
**Login: “userKate”**
**Password: “qwerty123+”**
		

**5.** After this you can check work of app. And now I will quickly describe endpoints of this app:
		
**Route api/Auth**
* POST/Register – for registration of user
* POST/Login – get token for authorization
		
**Route api/User**
* GET – get list of all users
* GET/{id} – get user by id
* PUT/{id} – change user by id
* DELETE/{id} – delete user by id
		
**Route api/Speaker**
* GET – get list of all speaker
* GET/{id} – get speaker by id
* PUT/{id} – change speaker by id
* DELETE/{id} – delete speaker by id
* POST – add new speaker to database

**Route api/Event**
* GET – get list of all events
* GET/{id} – get event by id
* PUT/{id} – change event by id
* DELETE/{id} – delete event by id
* POST – add new event to database
		
