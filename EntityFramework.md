# What is Entity Framework?
- Entity framework  is the framework ORM (object-relational mapping) that Microsoft makes available as part of the .NET development.
- Its purpose is to abstract the ties to a relational database, in such a way that the developer can relate to the database entity as to a set of objects and then to classes in addition to their properties.
 
- EF is a cross-platform framework which can run on Windows, Linux and Mac.
- EF  creates an EDM (Entity Data Model) based on POCO (Plain Old CLR Object) entities with get/set properties of different data types. It uses this model when querying or saving entity data to the underlying database.
- EF executes INSERT, UPDATE, and DELETE commands to the database based on the changes occurred to your entities when you call the SaveChanges() method. EF also provides the asynchronous SaveChangesAsync() method.
- EF allows us to configure the EF model by using data annotation attributes or Fluent API to override default conventions.
 
 
