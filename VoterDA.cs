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

    public class VoterDA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString());

        
        public List<VoterBO> GetVoterDetailsByID(VoterBO ObjBO) // passing Bussiness object Here 
        {
            List<VoterBO> objLBMBO = new List<VoterBO>();
            try
            {
                con.Open();

                SqlCommand objSqlCommand = new SqlCommand("sp_GetVoterDetailsByID", con);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@strEnRollID", SqlDbType.BigInt).Value = ObjBO.EnrollmentID;
                objSqlCommand.Parameters.Add("@VoterID", SqlDbType.NVarChar).Value = ObjBO.Voter;
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);
                DataTable objDataTable = new DataTable();
                objSqlDataAdapter.Fill(objDataTable);
                objLBMBO = objDataTable.AsEnumerable().Select(r => new VoterBO()
                {
                    AadharID = r["AadharId"].ToString(),
                    VoterName = r["VoterName"].ToString(),
                    Status = (bool)r["VoterStatus"]
                }).ToList();

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            finally
            {
                con.Close();
            }
            return objLBMBO;
        }

        public int ValidateVetorDetails(VoterBO ObjBO) // passing Bussiness object Here 
        {
            int status = 0;
            try
            {
                con.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_ValidateVoterID", con);
                objSqlCommand.Parameters.Add("@strVoter", SqlDbType.VarChar).Value = ObjBO.Voter;
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