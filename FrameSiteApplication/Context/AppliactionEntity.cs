using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using FrameSiteApplication.Models.BasicInformation;
namespace FrameSiteApplication.Context
{
    public class AppliactionEntity
    {
        
        public string AddApplicationInfromation(ApplicationName appName)
        {
            string config = ConfigurationManager.ConnectionStrings["dbConnectionStrings"].ConnectionString;
            SqlConnection connection = null;
            
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnectionStrings"].ConnectionString);
                SqlCommand cmd = new SqlCommand("sp_UpdateAppInfo", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ApplicationName", appName.applicationName);
                cmd.Parameters.AddWithValue("@ApplicationDisc", appName.applicationDiscription);
                cmd.Parameters.AddWithValue("@ApplicationLogo", appName.applicatinLogo);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}