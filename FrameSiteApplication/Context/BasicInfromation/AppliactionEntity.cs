using FrameSiteApplication.Models.BasicInformation;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
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
                connection = new SqlConnection(config);
                SqlCommand cmd = new SqlCommand("sp_UpdateAppInfo", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ApplicationName", appName.applicationName);
                cmd.Parameters.AddWithValue("@ApplicationDisc", appName.applicationDiscription);
                cmd.Parameters.AddWithValue("@ApplicationLogo", System.Data.SqlDbType.VarBinary).Value = appName.applicatinLogo;
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

        public string GetApplicationInfromation()
        {
            string config = ConfigurationManager.ConnectionStrings["dbConnectionStrings"].ConnectionString;
            SqlConnection connection = null;
            try
            {
                string Query = "select ApplicationLogo from tbl_ApplicationName";
                connection = new SqlConnection(config);
                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return Query;
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
        public string ConvertToBytes(HttpPostedFileBase image)
        {
            //string binaryImage = string.Empty;
            //using (var binary = new BinaryReader(image.InputStream))
            //{
            //    //byte[] imageBytes = Convert.FromBase64String(image);
            //    //BinaryReader reader = new BinaryReader(image.InputStream);
            //    byte[] imageBytes = binary.ReadBytes((int)image.ContentLength);
            //    imageBytes = System.Text.Encoding.UTF8.GetString(imageBytes);
            //    return imageBytes;
            //}

            BinaryReader reader = new BinaryReader(image.InputStream);
            Byte[] bytes = reader.ReadBytes(image.ContentLength);
            string imageByteData = Convert.ToBase64String(bytes);
            return imageByteData;

        }
    }
}