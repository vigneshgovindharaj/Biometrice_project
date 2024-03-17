using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BPS.App_Code.BO;
using BPS.App_Code.DA;
namespace BPS.App_Code.BL
{
    public class AadharBL
    {
        AadharDA objUserda = new AadharDA(); // Creating object of Dataccess
        public int ValidateAadharDetails(AadharBO ObjBO) // passing Bussiness object Here 
        {
            int status = 0;
            try
            {
                status = objUserda.ValidateAadharDetails(ObjBO);// calling Method of DataAccess 

            }
            catch (Exception ex)
            {

            }
            return status;
        }
    }
}
