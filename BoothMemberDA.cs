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
    public class BoothMemberDA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString());
        public List<BoothMemberBO> GetBoothMemberDetails(BoothMemberBO ObjBO) // passing Bussiness object Here 
        {
            List<BoothMemberBO> objLBMBO = new List<BoothMemberBO>();
            try
            {
                con.Open();

                SqlCommand objSqlCommand = new SqlCommand("sp_GetBoothMemberByID", con);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@strBoothMemberID", SqlDbType.NVarChar).Value = ObjBO.BoothMemberID; 
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);
                DataTable objDataTable = new DataTable();
                objSqlDataAdapter.Fill(objDataTable);
                objLBMBO = objDataTable.AsEnumerable().Select(r => new BoothMemberBO()
                {
                    BoothMemberID = r["BoothMemberId"].ToString(),
                    BMName = r["BoothMemberName"].ToString(),
                    Status = (bool)r["BMstatus"]
                }).ToList();

            }
            catch ( SqlException ex)
            {
                throw ex.InnerException;
            }
            finally
            {
                con.Close();
            }
            return objLBMBO;
        }

        public int VerifyBMLoginDetails(List<BoothMemberBO> bMBO)
        {
            int iBMID = 0;
            try
            {
                con.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_VerifyBMLoginDetails", con);
                objSqlCommand.Parameters.Add("@BMID", SqlDbType.VarChar).Value = bMBO[0].BoothMemberID;
                objSqlCommand.Parameters.Add("@AAID", SqlDbType.VarChar).Value = bMBO[0].AadharID;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.ExecuteScalar();
                iBMID = (int)objSqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            finally
            {
                con.Close();
            }
            return iBMID;
        }

        public string CreateBoothMemberDetails(List<BoothMemberBO> boothMemberBO)
        {
            List<BoothMemberBO> objLBMBO = new List<BoothMemberBO>();
            string strBMID = string.Empty;
            try
            {
                con.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_CreateBoothMember", con);

                objSqlCommand.Parameters.Add("@AadharId", SqlDbType.BigInt).Value = boothMemberBO[0].AadharID;
                objSqlCommand.Parameters.Add("@StateId", SqlDbType.Int).Value = boothMemberBO[0].StateID;
                objSqlCommand.Parameters.Add("@AlternateMobileNumber", SqlDbType.BigInt).Value = boothMemberBO[0].AlternateMobileNumber;
                objSqlCommand.Parameters.Add("@DistrictId", SqlDbType.Int).Value = boothMemberBO[0].DistrictID;
                objSqlCommand.Parameters.Add("@VillageId", SqlDbType.Int).Value = boothMemberBO[0].VillageID;
                objSqlCommand.Parameters.Add("@TalukId", SqlDbType.Int).Value = boothMemberBO[0].TalukID;
                objSqlCommand.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = 1;
                objSqlCommand.Parameters.Add("@status", SqlDbType.Bit).Value = 1;
               
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                strBMID = (string)objSqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            finally
            {
                con.Close();
            }
            return strBMID;
        }

        public int ValidateBMID(BoothMemberBO objBO)
        {
            int status = 0;
            try
            {
                con.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_ValidateBoothMemberByID", con);
                objSqlCommand.Parameters.Add("@strBoothMemberID", SqlDbType.VarChar).Value = objBO.BoothMemberID;
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
