# Window Blazor
The main purpose of it is to record Orders in database and have basic CRUD funtionalities on it.

## Projects Structure
The App is divided into 7 different projects.
1. Server project
2. Client project
3. Api project
4. DataAccess project
5. Bussiness Project
6. Models project
7. Common project

This structure is supposed to be self describing, and each one of them encapsulates an integral part of the entire solution.

## How to run the solution

First: Clone the repo from github
Second: Change the Connection strings in the appsettings.json files
Third: Choose three projects as startup projects in following order (make sure they all run on IIS Express)
       1. Api
       2. Client
       3. Server
Make sure the database server is also running.
Start the project.

## What the user experiences

1. On the server side, if logged as addming , you can create Window objects, configure it's SubElements and save them in the database (all Crud functionalities applicable)
2. on the client side you can place Orders , containing Window objects

# Progress OnGoing:

There is some functionality left to develop, the order management system is not fully functional!




