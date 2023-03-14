using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Runtime.Intrinsics.X86;
using ElderCareServerSide.Models;
using System.ComponentModel.Design;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json").Build();
        string cStr = configuration.GetConnectionString("myProjDB");
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }    

    //--------------------------------------------------------------------------------------------------
    // This method inserts an elder to the elders table 
    //--------------------------------------------------------------------------------------------------

    //public int InsertElder(Elder elder, HelpType type)
    //{

    //    SqlConnection con;
    //    SqlCommand cmd;

    //    try
    //    {
    //        con = connect("myProjDB"); // create the connection
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }

    //    //String cStr = BuildInsertCommand(user); // helper method to build the insert string

    //    cmd = CreateInsertElderCommandSP("spInsertElder", con, elder, type); // create the command

    //    try
    //    {
    //        int numEffected = cmd.ExecuteNonQuery(); // execute the command
    //        return numEffected;
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }

    //    finally
    //    {
    //        if (con != null)
    //        {
    //            // close the db connection
    //            con.Close();
    //        }
    //    }

    //}


    //---------------------------------------------------------------------------------
    // Create the insert user command using a stored procedure
    //---------------------------------------------------------------------------------

    //private SqlCommand CreateInsertElderCommandSP(String spInsertElder, SqlConnection con, Elder elder, HelpType type)
    //{

    //    SqlCommand cmd = new SqlCommand(); // create the command object

    //    cmd.Connection = con;              // assign the connection to the command object

    //    cmd.CommandText = spInsertElder;      // can be Select, Insert, Update, Delete 

    //    cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

    //    cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

    //    cmd.Parameters.AddWithValue("@name", elder.Name);
    //    cmd.Parameters.AddWithValue("@phoneNum", elder.PhoneNum);
    //    cmd.Parameters.AddWithValue("@city", elder.City);
    //    cmd.Parameters.AddWithValue("@relativeName", elder.RelativeName);
    //    cmd.Parameters.AddWithValue("@relativeNum", elder.RelativeNum);
    //    cmd.Parameters.AddWithValue("@helpType", type.type);

    //    return cmd;
    //}
}
