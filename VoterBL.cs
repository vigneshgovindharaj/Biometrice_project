using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BPS.App_Code.BO;
using BPS.App_Code.DA;
namespace BPS.App_Code.BL
{
    public class VoterBL
    {
        VoterDA objDA = new VoterDA(); // Creating object of Dataccess
        public int ValidateVoterDetails(VoterBO ObjBO) // passing Bussiness object Here 
        {
            int status = 0;
            try
            {
                status = objDA.ValidateVetorDetails(ObjBO);// calling Method of DataAccess 

            }
            catch (Exception ex)
            {

            }
            return status;
        }

        public List<VoterBO> GetVoterDetailsByID(VoterBO ObjBO) // passing Bussiness object Here 
        {
            List<VoterBO> objBO = new List<VoterBO>();

            try
            {
                objBO = objDA.GetVoterDetailsByID(ObjBO);// calling Method of DataAccess 

            }
            catch (Exception ex)
            {

            }
            return objBO;
        }
        
    }

}
