# MojoDoo Developer Assessment

This is a just a diagnoses, to show us your capabilities and create dissection subject for our interview.

## Before you begin

Relax and take you time, you have until our interview to complete the tasks.

Currently our projects are web-based, thereby the assignments are web app themed, however you are welcome to use what ever technologies that your are comfortable with.

## Content

I have setup a dynamodb & mongodb in the docker compose file. 
You can use them if you need them or not at all, however feel free to add any data storage layer that you need/like.


> Note: The port are exposed to localhost 

> known issues: 
> - dynamodb: if you getting this error `unable to open database file` use this `sudo chmod a+rw tmp/dynamodb` [ref](https://stackoverflow.com/questions/45850688/unable-to-open-local-dynamodb-database-file-after-power-outage)


## How to get started

Start by forking this repo, and the rest are up you.

When your done you can make a PR or send us the link to your repo.

## Epic
Our clients need a tasks management system, that allows them to create and find tasks _easily_. 

### User stories

1. As a user you need to be able to create tasks 
2. As a user you need to be able to complete tasks 
3. As a user you need to be able to delete tasks 
4. As a user you need to be able to change the oder of the tasks
5. As a user you need to be able to find you tasks easily (note a user may have hundreds of tasks.)

### TASK ONE - Create a todo list

Use a the framework of your chose to create simple a simple todo list where you can:

- Create tasks
- Complete tasks
- Delete tasks
- Update tasks

### TASK TWO - Change the order of tasks in the list

Make it so that you change change order of the tasks

> **Bonus:** use drag and drop to accomplish that.

### TASK THREE - allow for hierarchical tagging

In the project you can find `./data/tags`. The tags are grouped in subgroups and the need to keep their hierarchical structure.

- Create a tag picker that allows you to find these tags in an easy and structured way.
- Create a search function that allows you to find by the tag
- Create a refining function that allows to you to refining the search result by the tags


