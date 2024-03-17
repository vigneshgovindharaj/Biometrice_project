using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; // Required for using Dataset , Datatable and Sql
using System.Data.SqlClient; // Required for Using Sql 
using System.Configuration; // for Using Connection From Web.config
using BPS.App_Code.BO;

namespace BPS.App_Code.DA
{
    public class AadharDA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString());
        public int ValidateAadharDetails(AadharBO ObjBO) // passing Bussiness object Here 
        {
            int status = 0;
            try
            {
                con.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_ValidateAadharID", con);
                objSqlCommand.Parameters.Add("@strAadharID", SqlDbType.VarChar).Value = ObjBO.AadharID;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                status = (int)objSqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            finally
            {
                con.Close();
            }
            return status;
        }
    }
}