using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BPS.App_Code.BO;
using BPS.App_Code.DA;
namespace BPS.App_Code.BL
{
    public class BoothMemberBL
    {
        BoothMemberDA objBoothMemberDA = new BoothMemberDA(); // Creating object of Dataccess
        public List<BoothMemberBO> GetBoothMemberDetails(BoothMemberBO ObjBO) // passing Bussiness object Here 
        {
            List<BoothMemberBO> objLBMBO = new List<BoothMemberBO>();
            try
            {
                objLBMBO = objBoothMemberDA.GetBoothMemberDetails(ObjBO);// calling Method of DataAccess 

            }
            catch (Exception ex)
            {

            }
            return objLBMBO;
        }

        public int ValidateBMID(BoothMemberBO objboothMemberBO)
        {
            int retStatus = 0;
            try
            {
                retStatus = objBoothMemberDA.ValidateBMID(objboothMemberBO);// calling Method of DataAccess 

            }
            catch (Exception ex)
            {

            }
            return retStatus;
        }

        public string CreateBoothMemberDetails(List<BoothMemberBO> boothMemberBO)
        {
            string objLBMBO = string.Empty;
            try
            {
                objLBMBO = objBoothMemberDA.CreateBoothMemberDetails(boothMemberBO);// calling Method of DataAccess 

            }
            catch (Exception ex)
            {

            }
            return objLBMBO;
        }

        public int VerifyBMLoginDetails(List<BoothMemberBO> bMBO)
        {
            return objBoothMemberDA.VerifyBMLoginDetails(bMBO);
        }
    }
}
