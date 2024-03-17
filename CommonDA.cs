using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BPS.App_Code.BO;
namespace BPS.App_Code.DA
{

    /// <summary>
    /// Summary description for StateDA
    /// </summary>
    public class CommonDA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString());

        public CommonDA()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public List<StateBO> GetAllStates()
        {
            var objStateBO = new List<StateBO>();
            try
            {
                con.Open();

                SqlCommand objSqlCommand = new SqlCommand("sp_GetAllStates", con);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);
                DataTable objDataTable = new DataTable();
                objSqlDataAdapter.Fill(objDataTable);
                objStateBO = objDataTable.AsEnumerable().Select(r => new StateBO()
                {
                    StateID = (int)r["ID"],
                    StateName = (string)r["NAME"]
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
            return  objStateBO;
        }

        public int VerifyDALoginDetails(List<DECBO> objDECBO)
        {
            int iDACID = 0;
            try
            {
                con.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_VerifyDALoginDetails", con);
                objSqlCommand.Parameters.Add("@DecID", SqlDbType.VarChar).Value = objDECBO[0].DecID;
                objSqlCommand.Parameters.Add("@stateid", SqlDbType.Int).Value = objDECBO[0].StateID;
                objSqlCommand.Parameters.Add("@districtid", SqlDbType.Int).Value = objDECBO[0].DistrictID;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.ExecuteScalar();
                iDACID = (int)objSqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            finally
            {
                con.Close();
            }
            return iDACID;
        }

        public bool ValidateDACID(string strDACID)
        {
            bool status = false;
            try
            {
                con.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_ValidateDECID", con);
                objSqlCommand.Parameters.Add("@strDecIdID", SqlDbType.VarChar).Value = strDACID;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                status = ((int)objSqlCommand.ExecuteScalar() > 0) ? true : false;
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

        public List<DistrictBO> GetDistrictBySID(string stateID)
        {
            var objDistrictBO = new List<DistrictBO>();
            try
            {
                con.Open();

                SqlCommand objSqlCommand = new SqlCommand("sp_GetDistrictBySID", con);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@StateID", SqlDbType.Int).Value = stateID;
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);
                DataTable objDataTable = new DataTable();
                objSqlDataAdapter.Fill(objDataTable);
                objDistrictBO = objDataTable.AsEnumerable().Select(r => new DistrictBO()
                {
                    DistrictID = (int)r["DistrictId"],
                    DistrictName = (string)r["DistrictName"]
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
            return objDistrictBO;
        }
        public List<TalukBO> GetTaulkByDID(string DistrictId)
        {
            var talukList = new List<TalukBO>();
            try
            {
                con.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_GetTaulkByDID", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@DistrictID", SqlDbType.Int).Value = DistrictId;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                talukList = dataTable.AsEnumerable().Select(row => new TalukBO()
                {
                    TalukID = (int)row["TalukID"],
                    TalukName = (string)row["TalukName"]
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
            return talukList;
        }

        public List<VillageBO> GetVillageByDID(string TalukId)
        {
            var villageList = new List<VillageBO>();
            try
            {
                con.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_GetVillageByTID", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@TalukID", SqlDbType.Int).Value = TalukId;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                villageList = dataTable.AsEnumerable().Select( row => new VillageBO()
                {
                    VillageID = (int)row["VillageId"],
                    VillageName = (string)row["VillageName"]
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
            return villageList;
        }
    }
    
}