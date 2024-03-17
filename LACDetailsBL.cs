using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BPS.App_Code.BO;
using BPS.App_Code.DA;

namespace BPS.App_Code.BL
{
   public class LACDetailsBL
    {
        LACDetailsDA objUserda = new LACDetailsDA();
        public VillageBO GetLACDetails(VillageBO ObjBO) // passing Bussiness object Here 
        {
            try
            {


            }
            catch (Exception ex)
            {

            }
            return objUserda.GetLACDetails(ObjBO);// calling Method of DataAccess 
        }
    }
}
