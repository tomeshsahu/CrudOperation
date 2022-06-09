using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOConnection
{
    public class ADO
    {
        public string sc = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADODatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void Insertion()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sc))
                {
                    Console.WriteLine("Enter Name");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter Age");
                    string age = Console.ReadLine();

                    Console.WriteLine("Enter Gender");
                    string gender = Console.ReadLine();

                    Console.WriteLine("Enter Salary");
                    string Salary = Console.ReadLine();

                    Console.WriteLine("Enter City");
                    string City = Console.ReadLine();

                    con.Open();

                    string query = "insert into employee values(@name,@age,@gender,@Salary,@City)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@Salary", Salary);
                    cmd.Parameters.AddWithValue("@City", City);


                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        Console.WriteLine("Data Inserted Successfully");
                        Console.WriteLine("--------------");
                        Console.WriteLine(" ");

                    }
                    else
                    {
                        Console.WriteLine("Data Failed...");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Display()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sc))
                {
                    con.Open();
                    string query = "spGet";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine("Id = "+dr["id"]+" Name = "+dr["name"] + " Age = "+dr["age"]+ " Gender = " + dr["gender"]+ " Salary = " +dr["Salary"]+" City = "+dr["City"]);
                    }
                    Console.WriteLine("--------------");
                    Console.WriteLine(" ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sc))
                {
                    Console.WriteLine("Enter Id");
                    String id = Console.ReadLine();

                    Console.WriteLine("Enter Name");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter Age");
                    string age = Console.ReadLine();

                    Console.WriteLine("Enter Gender");
                    string gender = Console.ReadLine();

                    Console.WriteLine("Enter Salary");
                    string Salary = Console.ReadLine();

                    Console.WriteLine("Enter City");
                    string City = Console.ReadLine();
                    con.Open();
                    string query = "Update employee set name=@name,age=@age,gender=@gender,Salary=@Salary,City=@City where id=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@Salary", Salary);
                    cmd.Parameters.AddWithValue("@City", City);

                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        Console.WriteLine("Data Update Successfully!...");
                        Console.WriteLine("--------------");
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        Console.WriteLine("Data update Failed");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void Delete()
        {
            try
            {
                using(SqlConnection con=new SqlConnection(sc))
                {
                    Console.WriteLine("Enter Id");
                    string id = Console.ReadLine();
                    con.Open();
                    string query = "delete from employee where id=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    int a = cmd.ExecuteNonQuery();
                    if(a>0)
                    {
                        Console.WriteLine("Delete Successfully!...");
                        Console.WriteLine("--------------");
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        Console.WriteLine("Delete Failed...!");
                    }
                }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

      
    }
}

