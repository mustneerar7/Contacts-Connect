using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Windows.ApplicationModel.Resources;

namespace Contacts_Connect
{
    public class DataAccess
    {
        private ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView();

        public List<Person> getPeopleByLastName(String lastName)
        {
            // gets connection string from resources using resource loader class
            String connectionString = resourceLoader.GetString("connectionString");

            // opens a new connection and closes off imeediately
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                if(lastName == "")
                {
                    return connection.Query<Person>($"SELECT * FROM people")
                        .ToList();
                }
                else
                {
                    // sends a query and recives it in the form of
                    // a holder class from where entries are turned
                    // into a list
                    var output = connection.Query<Person>(
                        $"SELECT * FROM people WHERE lastname='{lastName}'")
                        .ToList();

                    // list of persons is returned
                    return output;
                }
            }   
        }

        // gets the record of all people in the table
        public List<Person> getAllPeople()
        {
            String connectionString = resourceLoader.GetString("connectionString");

            using (IDbConnection connection1 = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = connection1.Query<Person>("SELECT * FROM people")
                    .ToList();
                return output;
            }
        }

        // creates a new entry in table on database server
        public void insertContact(string firstName, string lastName, string phoneNumber)
        {
            String connectionString = resourceLoader.GetString("connectionString");

            using (IDbConnection connection2 = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                if (firstName != "")
                { 
                    connection2.Execute(
                        $"insert into people(firstname, lastname, phoneNumber)values(" +
                        $"'{firstName}','{lastName}','{phoneNumber}')"
                    );
                }
            }
        }
    }
}
