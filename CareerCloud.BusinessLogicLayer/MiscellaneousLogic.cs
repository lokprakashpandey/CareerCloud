using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class MiscellaneousLogic
    {
        public static bool Authenticate(string e, string p)
        {
            using (SqlConnection _connection = new 
                SqlConnection(@"Data Source=LAPTOP-6JLD6U9U\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = @"select * from Security_Logins" +
                    " where Email_Address = @email And " +
                    "Password = @pass";

                cmd.Parameters.AddWithValue("@email", e);
                cmd.Parameters.AddWithValue("@pass", p);


                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                //_connection.Close();

                if (reader.HasRows)
                    {
                    return true;
                    }
                else
                    return false;

            }

        }

        public static string [] GetJobsApplied(string e)
        {
            using (SqlConnection _connection = new
                SqlConnection(@"Data Source=LAPTOP-6JLD6U9U\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = @"select Id from Security_Logins " +
                    " where Email_Address = @email";

                cmd.Parameters.AddWithValue("@email", e);

                _connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                Guid temp = new Guid(); 

                if(reader.Read())
                {
                    temp = reader.GetGuid(0);
                }

                _connection.Close();


                SqlConnection _connection1 = new
                SqlConnection(@"Data Source=LAPTOP-6JLD6U9U\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True");

                SqlCommand cmd1 = new SqlCommand();

                cmd1.Connection = _connection1;
                
                cmd1.CommandText = @"select 
                                Company_Descriptions.Company_Name, 
                                Company_Jobs_Descriptions.Job_Name, 
                                Company_Jobs_Descriptions.Job_Descriptions
                                from Security_Logins, 
                                Applicant_Profiles, 
                                Applicant_Job_Applications, 
                                Company_Jobs, Company_Profiles, 
                                Company_Descriptions, 
                                Company_Jobs_Descriptions 
                                where 
                                Applicant_Profiles.Login = @x 
                                and Applicant_Profiles.Id = 
                                    Applicant_Job_Applications.Applicant
                                and Applicant_Job_Applications.Job = 
                                    Company_Jobs.Id
                                and Company_Jobs.Company = 
                                    Company_Profiles.Id
                                and Company_Descriptions.Company = 
                                    Company_Profiles.Id
                                and Company_Jobs_Descriptions.Job = 
                                    Company_Jobs.Id
                                group by 
                                    Company_Descriptions.Company_Name, 
                                    Company_Jobs_Descriptions.Job_Name, 
                                    Company_Jobs_Descriptions.Job_Descriptions";

                cmd1.Parameters.AddWithValue("@x", temp);

                _connection1.Open();

                SqlDataReader other_reader = cmd1.ExecuteReader();

                string []tempString = new string[100];
                int position = 0;

                while(other_reader.Read())
                {
                    tempString[position++] = (string)other_reader[0];
                    tempString[position++] = (string)other_reader[1];
                    tempString[position++] = (string)other_reader[2];
                }
                _connection1.Close();
                return tempString;
            }
        }
    }
}
