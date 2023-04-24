# How to retrieve the list of schema objects with Oracle Data Provider for .NET (ODP.NET)

In this post, I am going to introduce you one of the sample schemas that Oracle provides as we learn Oracle database: The HR Schema. But before I introduce it specifically, we need to understand what is a schema.

I've found two definitions for the same term, a schema basically can be:

A logical container for data structures
A collection of objects associated with the database.
Oracle draws the distinction between logical and physical structures: structures that are visible at a disk level or operating system level such as data files, control files and redo log files are considered physical structures, on the contrary, objects like tablespaces, schemas, tables, views , and any database objects are considered logical structures. A container in this context means that a single schema name can contain many different objects, these logical objects are known as schema objects, and they are made up of structures such as:

Table: A table is the basic logical storage unit in the Oracle database; composed of rows and columns.
Cluster: A cluster is a set of tables physically stored together as one table.
Index: An index is a structure created to help retrieve data more quickly and efficiently.
View: Logically represents subsets of data from one or more tables.
Store procedure: Stored procedures are predefined SQL queries stored in the data dictionary designed to allow more efficient queries.
Sequence: Numeric value generator.
Package: Named PL/SQL modules that group related stored procedures, functions, and identifiers.
Synonyms: Gives alternative names to objects.
The HR schema sample
The HR schema is a sample schema that Oracle makes available for learning purposes. You can install sample schemas using DBCA (DataBase Configuration Assistant) or you can get it from the following link:

https://www.oracle.com/technetwork/developer-tools/datamodeler/sample-models-scripts-224531.html
Fig 1. Entity Relationship Diagram for HR Schema.


Schemas present a layer of abstraction for your data structure and it helps to avoid a problem called name collision. Let me show you an example: if we don't use schemas a user called Bob can create a table called Employees, and then another user called Alice cannot create a table called Employees on the same schema that Bob, but Alice can create a table in a different schema. Other users can access or execute objects within a user's schema once the schema owner grants privileges.

List schema objects using .NET
The following code example uses Oracle Developer Tools for Visual Studio (ODT) to retrieve the list of schema objects that are available and then displaying them. You can download the project source code for this link.

Fig 2. Retrieving the list of schema objects of hr user.

Fig 3. Retrieving the list of schema objects of system user.

Note 1: You will find in many Oracle's texts that some people using schema and user indistinctly.
Note 2: Oracle validates that the users have permissions to use the schema objects being accessed by theirs.
Download example source code.
