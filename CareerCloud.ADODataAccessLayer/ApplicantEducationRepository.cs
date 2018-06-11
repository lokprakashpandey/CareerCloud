using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
   public class ApplicantEducationRepository : BaseADO, IDataRepository<ApplicantEducationPoco>
    {
        public void Add(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                int rowsEffected = 0;
                foreach (ApplicantEducationPoco poco in items)
                {
                    cmd.CommandText = @"INSERT INTO APPLICANT_EDUCATIONS 
                         (Id,Applicant,Major,Certificate_Diploma,Start_Date,
                          Completion_Date,Completion_Percent)
                         VALUES
                         (@Id,@Applicant,@Major,@Certificate_Diploma,@Start_Date,
                          @Completion_Date,@Completion_Percent)";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                    cmd.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);

                    _connection.Open();
                    rowsEffected += cmd.ExecuteNonQuery();
                    _connection.Close();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[1000];

            using (SqlConnection _connection = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from Applicant_Educations";

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                
                int position = 0;
                while (reader.Read())
                {
                    ApplicantEducationPoco poco = new ApplicantEducationPoco();

                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Major = reader.GetString(2);
                    poco.CertificateDiploma = reader.GetString(3);
                    poco.StartDate = (DateTime?)reader[4];
                    poco.CompletionDate = (DateTime?)reader[5];
                    poco.CompletionPercent = (byte?)reader["Completion_Percent"];
                    //reader.GetByte(6)
                    poco.TimeStamp = (byte[])reader[7];
                    //(byte[])reader["Time_Stamp"]
                    pocos[position] = poco;
                    position++;

                }
                _connection.Close();
            }

            return pocos.Where(p => p != null).ToList();
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                foreach(ApplicantEducationPoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM Applicant_Educations
                                WHERE ID = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    _connection.Open();
                    cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                foreach(ApplicantEducationPoco poco in items)
                {
                    cmd.CommandText = @"UPDATE Applicant_Educations
                            SET Applicant = @Applicant,
                                Major = @Major,
                                Certificate_Diploma = @Certificate_Diploma,
                                Start_Date = @Start_Date,
                                Completion_Date = @Completion_Date,
                                Completion_Percent = @Completion_Percent
                                WHERE ID = @Id";

                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                    cmd.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    _connection.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    _connection.Close();

                }
            }
        }
    }
}
