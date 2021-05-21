# Generate Data Layer using Dapper
This project shows how to generates a clean data layer using T4 Templates from an existing database, and keep it up to date with changes to the data structure.
It uses dapper and dapper.SimpleCrud to access the data and to keep the codebase as simple and as performant as possible

The generated code is placed into seperate folders designed to be overwritten by the next run, while custom code is placed in partial classes and is safe from being overwritten

# To get the sample working
Setup a database by following the following steps

Run the sample

Modify the following properties in the .tt files to suit your development environment

Run the .tt files

Uncomment methods

Run the sample again

# To use in your projects

Setup the structure

Installthe Microsoft.SqlServer.SqlManagementObjects nuget package into all projects which will run the .tt templates (ie, your POCO project(s) and your repo project(s))

Install the System.ComponentModel.Annotations nuget package into any projects which will contain your POCOs/Entities

Install the Dapper.SimpleCRUD nuget package into any projects which will contain your data repositories

Copy the tt files
Copy the RepositoryBase file

