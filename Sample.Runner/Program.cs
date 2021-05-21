using Sample.DataLayer;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Sample.Entities;

namespace Sample.Runner
{
    class Program
    {
        private static SqlConnection connection = new SqlConnection("Server=DESKTOP-M73TD1A\\SQLEXPRESS;Database=master;Trusted_Connection=True;");

        static void Main(string[] args)
        {
            connection.Open();
            
            // Step 1. Run this to create a clean db with the first setp of tables.
            SetupDatabase();

            //Step 2. Run this to get everything thats currently in the single table in the database and also to insert and retrieve a record
            TestCurrentCodeSetup();

            //Step 3. When ready, uncomment this to add another table to the database and create a relationship between the two tables
            //AddAnotherTable();

            //Step 4. Run the .tt files again to generate new repos and entities, note that the foreign key queries are automatically created as well as the primary key queries

            //Step 5. Uncomment the method below to test the new queries
            //Test new entities and queries

            // To start again, just delete the db and start again from Step 1.

            connection.Close();
        }

        private static void SetupDatabase()
        {
            var command = new SqlCommand(@"
                                USE [master]

                                IF DB_ID('SampleDb') IS NULL
                                BEGIN
	                                CREATE DATABASE [SampleDb];

	                                USE [SampleDb]
	                                
	                                CREATE TABLE [dbo].[TableA](
		                                [Id] [int] IDENTITY(1,1) NOT NULL,
		                                [StringColumn] [varchar](100) NOT NULL,
	                                 CONSTRAINT [PK_TableA] PRIMARY KEY CLUSTERED 
	                                (
		                                [Id] ASC
	                                )
	                                ) ON [PRIMARY]


	                                INSERT INTO TableA VALUES ('Some value')
	                                INSERT INTO TableA VALUES ('Some other value')
                                END

                                USE [SampleDb]

                                ", connection);

            command.ExecuteNonQuery();
        }

        private static void TestCurrentCodeSetup()
        {
            var tableARepo = new TableARepository();
            var getAllResults = tableARepo.GetAll(connection);
            Debug.Assert(getAllResults.Count() > 1);

            var savedTable = tableARepo.SaveTableA(new TableA { StringColumn = "Test" }, connection);
            var retrievedTable = tableARepo.GetTableA(savedTable.Id, connection);
            Debug.Assert(savedTable.Id == retrievedTable.Id);

            var customQueryResult = tableARepo.GetTableAByStringColumnA("Test", connection);
            Debug.Assert(customQueryResult != null);
            Debug.Assert(customQueryResult.StringColumn == "Test");
        }

        private static void AddAnotherTable()
        {
            throw new System.NotImplementedException();
        }
    }
}
