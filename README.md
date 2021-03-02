# Weapon-store
A simple visual c# application that uses sql

# Before Start : 
Before launching the application, go to Login.cs formular, scroll down to the  "Important" class, and change the SqlConnection string.
To do this, you have to Create a database mdf file, than navigate twards Database folder, copy all the sql code from "Querry for Database.sql" file and paste it in the new database, after you will run this query, get the connection string and inser into SqlConnection class constructor, from "Important" class. If you do this, the application will work.

# Log In : 
You have 2 options to log in (as User and as Admin);
The default login data for user is : 

Login : u 

Password : a

And the default login data for admin is : 

Login : a 

Password : a

# Register
But you may register as a new user if you want to have a new account.
In order to register, on the login page you c=may enter your personal data.
Once you have registered, by default you'l become a user, but not an admin.
To become an admin, you have to log as an admin, and give the access from users management!

# Bugs
1. cannot refresh the products in browse product menu.
2. Will trow an exception.
3. Not all of the exceptions are checked!

# Language
The language of the application is Romanian
