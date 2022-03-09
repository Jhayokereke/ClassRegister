using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClassRegister
{
    public class Data
    {
        SqlConnection conn;
        SqlCommand com;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        DataTable table;
        private readonly string _connStr = @"Data Source = .;Initial Catalog = TheBulbDB; Integrated Security = True";

        public void AddNewFellow(string Id, string fname,
            string mname, string lname, Gender gender, int stateId)
        {
            string sql = $"insert into tblDotnetClass values ( '{Id}', '{fname}', '{mname}', '{lname}', {(int)gender}, {stateId})";
            using (conn = new SqlConnection(_connStr))
            {
                com = new SqlCommand(sql, conn);
                conn.Open();
                com.ExecuteNonQuery();
            }
        }

        public IEnumerable<Fellow> Search(string name)
        {
            List<Fellow> result = new List<Fellow>();
            string sqltxt = $"select Id, Firstname from tblDotnetClass where Firstname like @Key";
            using (conn = new SqlConnection(_connStr))
            {
                com = new SqlCommand(sqltxt, conn);
                com.Parameters.AddWithValue("@Key", "%" + name + "%");
                conn.Open();
                reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(new Fellow
                        {
                            Id = reader[0].ToString(),
                            Firstname = reader.GetString(1)
                        });
                    }
                }
            }
            return result;
        }


        //using DataReader
        public async Task GetAllFellows()
        {
            var result = new List<Fellow>();
            string sql = "select tblDotnetClass.Id, Firstname, Middlename, Lastname, GenderId, tblState.Id, [Name], Capital, Region " +
                "from tblDotnetClass" +
                " join tblState on StateId = tblState.Id";
            using (conn = new SqlConnection(_connStr))
            {
                com = new SqlCommand(sql, conn);
                conn.Open();
                reader = await com.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(new Fellow
                        {
                            Id = reader.GetString(0),
                            Firstname = reader.GetString(1),
                            Middlename = reader.GetString(2),
                            Lastname = reader.GetString(3),
                            Gender = (Gender)reader.GetInt32(4),
                            State = new State
                            {
                                Id = reader.GetInt32(5),
                                Name = reader.GetString(6),
                                Capital = reader.GetString(7),
                                Region = reader.GetString(8)
                            }
                        });
                    }
                }
            }
            Console.WriteLine(string.Join("\n\n", result.Select(r => r.ToString())));
        }

        //using DataAdapter and DataTable
        public void GetAllFellows2()
        {
            IEnumerable<Fellow> result = new List<Fellow>();
            string sql = "select tblDotnetClass.Id, Firstname, Middlename, Lastname, GenderId, tblState.Id, [Name], Capital, Region " +
                "from tblDotnetClass" +
                " join tblState on StateId = tblState.Id";
            using (conn = new SqlConnection(_connStr))
            {
                com = new SqlCommand(sql, conn);
                conn.Open();

                adapter = new SqlDataAdapter();
                table = new DataTable();
                adapter.SelectCommand = com;
                adapter.Fill(table);

                result = table.Select().Select(row =>
                new Fellow
                {
                    Id = row[0].ToString(),
                    Firstname = row["Firstname"].ToString(),
                    Middlename = row[2].ToString(),
                    Lastname = row["Lastname"].ToString(),
                    Gender = (Gender)row["GenderId"],
                    State = new State
                    {
                        Capital = row["Capital"].ToString(),
                        Name = row["Name"].ToString(),
                        Id = (int)row[5],
                        Region = row["Region"].ToString(),
                    }
                });

                //foreach (DataRow row in table.Select())
                //{
                //    result.Add(new Fellow
                //    {
                //        Id = row[0].ToString(),
                //        Firstname = row["Firstname"].ToString(),
                //        Middlename = row[2].ToString(),
                //        Lastname = row["Lastname"].ToString(),
                //        Gender = (Gender)row["GenderId"],
                //        State = new State
                //        {
                //            Capital = row["Capital"].ToString(),
                //            Name = row["Name"].ToString(),
                //            Id = (int)row[5],
                //            Region = row["Region"].ToString(),
                //        }
                //    });
                //}
            }
            Console.WriteLine(string.Join("\n\n", result.Select(r => r.ToString())));
        }

        public bool UpdateFellowState(string Id, int stateId)
        {
            string sql = $"update tblDotnetClass set StateId = @StateId where Id = @Id";
            try
            {
                using (conn = new SqlConnection(_connStr))
                {
                    com = new SqlCommand(sql, conn);
                    com.Parameters.AddWithValue("@StateId", stateId);
                    com.Parameters.AddWithValue("@Id", Id);
                    conn.Open();
                    com.ExecuteNonQuery();
                }
            } 
            catch
            {
                return false;
            }

            return true;
        }
    }
}

/*
 * ADO.NET - Active Data Objects
 * sql
 
 */
