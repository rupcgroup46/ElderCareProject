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
using System.Runtime.ConstrainedExecution;

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

    public int InsertElder(Elder elder)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        //String cStr = BuildInsertCommand(user); // helper method to build the insert string

        cmd = CreateInsertElderCommandSP("spInsertElder", con, elder); // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //--------------------------------------------------------------------------------------------------
    // This method reads all the cars
    //--------------------------------------------------------------------------------------------------
    public List<Elder> ReadElders()
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        //String cStr = BuildUpdateCommand(student); // helper method to build the insert string

        cmd = CreateReadEldersCommandSP("spReadElders", con); // create the command

        try
        {
            List<Elder> EldersList = new List<Elder>();

            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Elder elder = new Elder();
                elder.ID = Convert.ToInt32(dataReader["ID"]);
                elder.Name = dataReader["Name"].ToString();
                elder.PhoneNum = dataReader["PhoneNum"].ToString();
                elder.City = dataReader["City"].ToString();
                elder.RelativeName = dataReader["RelativeName"].ToString();
                elder.RelativeNum = dataReader["RelativeNum"].ToString();
                elder.HelpTypes = dataReader["HelpTypes"].ToString();

                EldersList.Add(elder);
            }

            return EldersList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }


    //--------------------------------------------------------------------------------------------------
    // This method reads 5 associations
    //--------------------------------------------------------------------------------------------------
    public List<Association> ReadAssociationsByParameters(string helpType, string city)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        //String cStr = BuildUpdateCommand(student); // helper method to build the insert string

        cmd = CreateReadAssociationsByParametersSP("spReadAssociationsByParameters", con, helpType, city); // create the command

        try
        {
            List<Association> associationsList = new List<Association>();

            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Association a = new Association();
                a.ID = Convert.ToInt32(dataReader["Association_ID"]);
                a.Name = dataReader["Association_Name"].ToString();
                a.Email = dataReader["Association_Email"].ToString();
                a.Password = dataReader["Association_Password"].ToString();
                a.HelpType = dataReader["Asso_Help_Type"].ToString();
                a.City = dataReader["Asso_City"].ToString();
                a.TotalApps = Convert.ToInt32(dataReader["Association_Total_Apps"]);
                a.HelpedApps = Convert.ToInt32(dataReader["Association_Helped_Apps"]);
                a.HelpingRatio = float.Parse(dataReader["Association_Helping_Ratio"].ToString());

                associationsList.Add(a);
            }

            return associationsList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }


    //--------------------------------------------------------------------------------------------------
    // This method inserts an application to the application table 
    //--------------------------------------------------------------------------------------------------

    public int InsertApplication(Application application)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        //String cStr = BuildInsertCommand(user); // helper method to build the insert string

        cmd = CreateInsertApplicationCommandSP("spInsertApplication", con, application); // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //---------------------------------------------------------------------------------
    // Create the insert elder command using a stored procedure
    //---------------------------------------------------------------------------------

    private SqlCommand CreateInsertElderCommandSP(String spInsertElder, SqlConnection con, Elder elder)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spInsertElder;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

        cmd.Parameters.AddWithValue("@name", elder.Name);
        cmd.Parameters.AddWithValue("@phoneNum", elder.PhoneNum);
        cmd.Parameters.AddWithValue("@city", elder.City);
        cmd.Parameters.AddWithValue("@helpTypes", elder.HelpTypes);
        cmd.Parameters.AddWithValue("@relativeName", elder.RelativeName);
        cmd.Parameters.AddWithValue("@relativeNum", elder.RelativeNum);

        return cmd;
    }


    //---------------------------------------------------------------------------------
    // Create the insert elder command using a stored procedure
    //---------------------------------------------------------------------------------

    private SqlCommand CreateReadEldersCommandSP(String spReadElders, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spReadElders;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

        return cmd;
    }


    //---------------------------------------------------------------------------------
    // Create the read associations command using a stored procedure
    //---------------------------------------------------------------------------------

    private SqlCommand CreateReadAssociationsByParametersSP(String spReadAssociationsByParameters, SqlConnection con, string helpType, string city)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spReadAssociationsByParameters;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

        cmd.Parameters.AddWithValue("@helpType", helpType);
        cmd.Parameters.AddWithValue("@city", city);

        return cmd;
    }

    //---------------------------------------------------------------------------------
    // Create the insert application command using a stored procedure
    //---------------------------------------------------------------------------------

    private SqlCommand CreateInsertApplicationCommandSP(String spInsertApplication, SqlConnection con, Application application)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spInsertApplication;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

        cmd.Parameters.AddWithValue("@status", application.Status);
        cmd.Parameters.AddWithValue("@helpType", application.HelpType);
        cmd.Parameters.AddWithValue("@city", application.City);
        cmd.Parameters.AddWithValue("@startDate", application.StartDate);
        cmd.Parameters.AddWithValue("@updateDate", application.UpdateDate);
        cmd.Parameters.AddWithValue("@endDate", application.EndDate);
        cmd.Parameters.AddWithValue("@elderID", application.ElderID);
        cmd.Parameters.AddWithValue("@handlingAssociationID", application.HandlingAssociationID);
        cmd.Parameters.AddWithValue("@sentAssociationsID", application.SentAssociationsID);

        return cmd;
    }
}
