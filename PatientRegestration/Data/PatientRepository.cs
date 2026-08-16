using PatientRegestration.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PatientRegestration.Data
{
    public class PatientRepository
    {
        private readonly string _connectionString;
        public PatientRepository()
        {
            _connectionString =
                ConfigurationManager
                .ConnectionStrings["HospitalDbConnection"]
                .ConnectionString;
        }

        public long RegisterPatient(Patient patient)
        {
            using (SqlConnection connection =
                new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction()) {
                    try
                    {
                        LockRegistration(connection, transaction);
                        long fileNum = GetNextFileNum(connection, transaction);

                        InsertPAtient(connection, transaction, patient, fileNum);

                        transaction.Commit();
                        return fileNum;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                 }
            }
        }

        private void LockRegistration(
           SqlConnection connection,
           SqlTransaction transaction)
        {
            using (SqlCommand command =
                new SqlCommand("sp_getapplock",
                connection,
                transaction))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(
                    "@Resource",
                    SqlDbType.NVarChar,
                    255).Value = "PatientFileNumber";

                command.Parameters.Add(
                    "@LockMode",
                    SqlDbType.VarChar, 32)
                    .Value = "Exclusive";

                command.Parameters.Add(
                    "@LockOwner",
                    SqlDbType.VarChar,
                    32
                    ).Value = "Transaction";

                command.Parameters.Add(
                   "@LockTimeout",
                   SqlDbType.Int).Value = 5000;

                int result = Convert.ToInt32(
                   command.ExecuteScalar());

                if (result < 0)
                {
                    throw new Exception(
                        "Could not lock patient registration.");
                }
            }
        }

        private long GetNextFileNum(
            SqlConnection connection,
            SqlTransaction transaction
            )
        {
            int currYear=DateTime.Now.Year;

            long startNumber =
                (long)currYear * 10000;

            long endNumber =
                (long)(currYear + 1) * 10000;

            string query = @"
                 
                select isnull(MAX(FileNumber), 0)
                FROM Patients
                where FileNumber >= @StartNumber
                and FileNumber < @EndNumber
            
                    ";

            using (SqlCommand command =
                new SqlCommand(query, connection, transaction)) 
            {
                command.Parameters.Add("@StartNumber", SqlDbType.BigInt).Value = startNumber;

                command.Parameters.Add(
                    "@EndNumber",
                    SqlDbType.BigInt).Value = endNumber;

                long lastFileNumber =
                   Convert.ToInt64(command.ExecuteScalar());

                if (lastFileNumber == 0)
                {
                    return startNumber + 1;
                }

                return lastFileNumber + 1;
            }

        }

        private void InsertPAtient(SqlConnection connection,
            SqlTransaction transaction,
            Patient patient,
            long fileNum)
        {
            string query = @"
                insert into Patients
                (
                    FileNumber,
                    FirstName,
                    LastName,
                    Phone,
                    DateOfBirth,
                    Gender
                    
                )
             VALUES
                (
                    @FileNumber,
                    @FirstName,
                    @LastName,
                    @Phone,
                    @DateOfBirth,
                    @Gender
)";

            using(SqlCommand command =
                new SqlCommand(query,connection,transaction))
            {
                command.Parameters.Add(
                    "@FileNumber",
                    SqlDbType.BigInt).Value = fileNum;

                command.Parameters.Add("@FirstName",
                    SqlDbType.NVarChar, 20).Value = patient.FirstName;

                command.Parameters.Add(
                   "@LastName",
                   SqlDbType.NVarChar,
                   20).Value = patient.LastName;

                command.Parameters.Add(
                    "@Phone",
                    SqlDbType.NVarChar,
                    20).Value =
                    (object)patient.Phone ;

                command.Parameters.Add(
                    "@DateOfBirth",
                    SqlDbType.Date).Value =
                    (object)patient.DateOfBirth ?? DBNull.Value;

                command.Parameters.Add(
                    "@Gender",
                    SqlDbType.NVarChar,
                    10).Value =
                    (object)patient.Gender ?? DBNull.Value;

                command.ExecuteNonQuery();
            }
        }




    }
}