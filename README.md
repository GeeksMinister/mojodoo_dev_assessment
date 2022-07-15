## Introduction

A solution for MojoDoo Developer Assessment - Tasks Management System  by Nael Sharabi https://github.com/GeeksMinister

## Used technology
* ASP.NET MVC with .NET 6
* Dapper ORM
* SQLite Database

### How to run
The app is a cross-platform app since it was developed on .NET 6. Simply run the executable-file after publishing the app and open the browser to the app URL.

## About the application
I had generated 100 tasks as test data and inserted them in TasksManagementSystem.sqlite. These tasks are meant to simulate how the application functions while having some tasks in it. <br />
![image](https://user-images.githubusercontent.com/98697297/179245762-1570e513-6238-4174-8c46-bcc24f8094a4.png) <br />
The used ORM is Dapper, since it's very fast and uses way less resources compared to Entity Framework. <br />
Having Dapper working with a SQLite database, made the application responsive and load data very fast . <br />
I used the SQLite database for the sake of flexibility and simplicity, which also allows the app to work as a local app for the client. <br />
The Model / class Todo represent the tasks in the app, and each one must contain a name, they also can contain **Description, Priority, Status, Tag** <br />
Searching for a task can simply be performed by typing in a search phrase, or by specifying any other value. Giving in the search more properties, will make it wore work more accurately. <br />
![image](https://user-images.githubusercontent.com/98697297/179245825-559ee664-9533-4413-9bda-2245c1db18ce.png)
