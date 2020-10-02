# RepositoryExample
######## Example what patterns can be used in Repository service layer. ########

**Hi all !**

My name is Alexander Zolotov - and this is a simple example of my code. Any questions, suggestions, or comments will be very appreciated ...

In this example I show how to follow **SOLID** principles and use some patterns.

## Decorator pattern: ##
 In **RepositoryServiceDaoLogger** I decorate repository classes for add functionalty, in current case - logging.

So - I follow 
> **S**OLID  - ***Single Responsibility Principle***—classes should have a single responsibility.

And I follow other too:
> S**O**LID - ***Open-Closed principle (OCP)*** - a class should be open for extension, but closed for modification.

As we can see: 
>  **RepositoryServiceDaoLogger** have responsible for ***logging***, **RepositoryServiceDao** and childs of them - for ***data access***. And we can change logging or data access in different classes without any dependencies.

## Repository and Unit of Work patterns: ##

In abstract **RepositoryServiceDao** have been implemented all necessary data access logic. That is possible because Entity Framework has a DbSet class that has Add and Remove method and therefore looks like a ***Repository***. 

The DbContext class has the method SaveChanges and so looks like the ***Unit of Work***. 
And inside **RepositoryServices** folder we can see implementation repositories for all table classes.




