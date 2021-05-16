# Generate Data Layer
Generates a clean data layer using T4 Templates from an existing database

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

