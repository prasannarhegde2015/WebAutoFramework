using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for DataAccessLayer
/// </summary>
public static class DataAccessLayer
{
    //public static string ConnectionString =@"data source=BUGNET-VM1\BUGNET;database=WebAutomation;User id=sa;pwd=test@123;Connect Timeout=120";
    public static string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["con"];

    public static DataTable GetReturnDataTable(string storeProcName, List<SqlParameter> parameters)
    {
        SqlConnection con = null;
        try
        {

            string connectionString = ConnectionString;
            con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storeProcName;


            foreach (SqlParameter param in parameters)
            {
                command.Parameters.AddWithValue(param.ParameterName, param.Value);
            }

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;


            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        catch (SqlException ex)
        {
            throw ex;

        }

        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
            }
        }
    }

  
    public static DataSet GetReturnDataSet(string storeProcName, List<SqlParameter> parameters)
    {
        SqlConnection con = null;
        try
        {

            string connectionString = ConnectionString;
            con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storeProcName;


            foreach (SqlParameter param in parameters)
            {
                command.Parameters.AddWithValue(param.ParameterName, param.Value);
            }

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;


            DataSet dt = new DataSet();
            adapter.Fill(dt);
            return dt;
        }
        catch (SqlException ex)
        {
            throw ex;

        }

        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
            }
        }
    }

    public static object InsertData(string storeProcName, List<SqlParameter> parameters)
    {
        object _returnValue = null;

        SqlConnection con = null;
        SqlTransaction _trans = null;
        try
        {

            string connectionString = ConnectionString;
            con = new SqlConnection(connectionString);
            con.Open();
            _trans = con.BeginTransaction();

            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.Transaction = _trans;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storeProcName;


            foreach (SqlParameter param in parameters)
            {
                if (param.Direction == ParameterDirection.Input)
                {
                    command.Parameters.AddWithValue(param.ParameterName, param.Value);
                }
                else if (param.Direction == ParameterDirection.ReturnValue)
                {
                    command.Parameters.Add(param);
                }
                else if (param.Direction == ParameterDirection.Output)
                {
                    command.Parameters.Add(param);
                }
            }
            command.ExecuteNonQuery();
            _trans.Commit();
            foreach (SqlParameter param in parameters)
            {

                if (param.Direction == ParameterDirection.ReturnValue)
                {
                    _returnValue = param.Value;
                }
                else if (param.Direction == ParameterDirection.Output)
                {
                    _returnValue = param.Value;
                }
            }

            return _returnValue;

        }
        catch (SqlException ex)
        {
            _trans.Rollback();
            throw ex;

        }

        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
            }
        }
    }
    public static object InsertData(SqlConnection con, SqlTransaction trans, string storeProcName, List<SqlParameter> parameters)
    {
        object _returnValue = null;


        try
        {


            SqlCommand command = new SqlCommand();
            command.Connection = con;

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storeProcName;
            command.Transaction = trans;

            foreach (SqlParameter param in parameters)
            {
                if (param.Direction == ParameterDirection.Input)
                {
                    command.Parameters.AddWithValue(param.ParameterName, param.Value);
                }
                else if (param.Direction == ParameterDirection.ReturnValue)
                {
                    command.Parameters.Add(param);
                }
            }
            command.ExecuteNonQuery();

            foreach (SqlParameter param in parameters)
            {

                if (param.Direction == ParameterDirection.ReturnValue)
                {
                    _returnValue = param.Value;
                }
            }

            return _returnValue;

        }
        catch (SqlException ex)
        {

            throw ex;
        }

    }


}
