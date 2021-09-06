using BS.Lab.AdoWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BS.Lab.AdoWebApi.Domain.Repositories
{
    public class Repository : SqlRepository
    {
        public Repository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<EmployeeModel> GetEmployees()
        {
            var sqlQuery = @"
SELECT e.Id, e.Name, e.Surname, e.DismissalDate, e.[Function], e.HireDate, r.Id as roomId, r.Name as roomName
FROM employees e
LEFT JOIN rooms r ON e.RoomId = r.Id";

            var result = new List<EmployeeModel>();

            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var newEmployee = new EmployeeModel
                        {
                            Id = GetFieldInt(reader, "Id"),
                            Name = GetFieldString(reader, "Name"),
                            Surname = GetFieldString(reader, "Surname"),
                            DismissalDate = GetFieldDateTimeNullable(reader, "DismissalDate"),
                            Function = GetFieldString(reader, "Function"),
                            HireDate = GetFieldDateTime(reader, "HireDate"),
                            Room = IsDbNull(reader, "roomId") ? null : new RoomModel(GetFieldInt(reader, "roomId"), GetFieldString(reader, "roomName"))
                        };
                        result.Add(newEmployee);
                    }
                }
            }

            return result;
        }

        public IEnumerable<EmployeeModel> GetEmployeesByRoomId(int roomId)
        {
            var sqlQuery = @"
SELECT e.Id, e.Name, e.Surname, e.DismissalDate, e.Function, e.HireDate
FROM employees e
WHERE e.RoomId = @roomId";

            var result = new List<EmployeeModel>();

            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.Add("roomId", System.Data.SqlDbType.Int).Value = roomId;

                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var newEmployee = new EmployeeModel
                        {
                            Id = GetFieldInt(reader, "e.Id"),
                            Name = GetFieldString(reader, "e.Name"),
                            Surname = GetFieldString(reader, "e.Surname"),
                            DismissalDate = GetFieldDateTimeNullable(reader, "e.DismissalDate"),
                            Function = GetFieldString(reader, "e.Function"),
                            HireDate = GetFieldDateTime(reader, "e.HireDate"),
                        };
                        result.Add(newEmployee);
                    }
                }
            }

            return result;
        }

        public IEnumerable<EmployeeModel> GetEmployeesBySurname(string surname)
        {
            //TODO: Da completare...deve restituire tutti gli impiegati che hanno il cognome specificato (usando SQL)
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeModel> GetEmployeesCurrentlyEmployed()
        {
            //TODO: Da completare...deve restituire tutti gli impiegati che hanno il cognome specificato (sando LINQ)
            throw new NotImplementedException();
        }

    }
}
