using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BPS.App_Code.BO;
using BPS.App_Code.DA;
namespace BPS.App_Code.BL
{
    /// <summary>
    /// Summary description for StateBL
    /// </summary>
    public class CommonBL
    {
        CommonDA objCommonDA = new CommonDA();
        public CommonBL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public List<StateBO> GetAllStates()
        {
           return objCommonDA.GetAllStates();
        }

        public List<DistrictBO> GetDistrictBySID(string stateID)
        {
            return objCommonDA.GetDistrictBySID(stateID);
        }
        public List<TalukBO> GetTaulkByDID(string DistrictId)
        {
            return objCommonDA.GetTaulkByDID(DistrictId);
        }
        public List<VillageBO> GetVillageByDID(string VillageId)
        {
            return objCommonDA.GetVillageByDID(VillageId);
        }
        public bool ValidateDACID(string strDACID)
        {
            return objCommonDA.ValidateDACID(strDACID);
        }

        public int VerifyDALoginDetails(List<DECBO> objDECBO)
        {
            return objCommonDA.VerifyDALoginDetails(objDECBO);
        }
    }
}