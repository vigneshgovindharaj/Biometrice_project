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
    public class LACDetailsDA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString());
        VillageBO ObjBO = new VillageBO();

        public VillageBO GetLACDetails(VillageBO objBO)
        {
            throw new NotImplementedException();
        }

        public List<LACDetailsBO> GetAllLACDetails()
        {
            var LACList = new List<LACDetailsBO>();
            try
            {
                con.Open();

                SqlCommand objSqlCommand = new SqlCommand("sp_LacIdList", con);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);
                DataTable objDataTable = new DataTable();
                objSqlDataAdapter.Fill(objDataTable);
                LACList = objDataTable.AsEnumerable().Select(r => new LACDetailsBO()
                {
                    LACID = (string)r["ID"],

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
            return LACList;
        }

    }
}
