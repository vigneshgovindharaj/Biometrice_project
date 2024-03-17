using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using BPS.App_Code.BO;
using BPS.App_Code.BL;
using System.Collections.Generic;
using BPS.App_Code.DA;
/// <summary>
/// Summary description for GetBPSDetails
/// </summary>
[WebService(Namespace = "http://microsoft.com/webservices/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WS_GetBPSDetails : System.Web.Services.WebService
{
    CommonBL objCommonBL = new CommonBL();
    public WS_GetBPSDetails()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool ValidateBMID(string strBoothMemberID)
    {
        BoothMemberBO objboothMemberBO = new BoothMemberBO();
        if (string.IsNullOrEmpty(strBoothMemberID))
        {
            return false;
        }
        else
        {
            BoothMemberBL objBoothMemberBL = new BoothMemberBL();
            objboothMemberBO.BoothMemberID = strBoothMemberID;

            objboothMemberBO.Status = objBoothMemberBL.ValidateBMID(objboothMemberBO) == 1 ? true : false;
            return objboothMemberBO.Status;
        }

        // return "Hello World";
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetUserVoterDetails()
    {
        UserPollingDetailsBO detailsBO = new UserPollingDetailsBO();
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(detailsBO));
    }

    [WebMethod]

    public List<StateBO> GetStates()
    {

        return objCommonBL.GetAllStates();

    }
    [WebMethod]
    public List<DistrictBO> GetDistrictBySID(string stateid)
    {

        return objCommonBL.GetDistrictBySID(stateid);

    }
    [WebMethod]
    public List<BoothMemberBO> GetBMByID(string strBMID)
    {
        BoothMemberBO objboothMemberBO = new BoothMemberBO();
        List<BoothMemberBO> objLBMBO = new List<BoothMemberBO>();
        if (string.IsNullOrEmpty(strBMID))
        {
            return objLBMBO;
        }
        else
        {
            BoothMemberBL objBoothMemberBL = new BoothMemberBL();
            objboothMemberBO.BoothMemberID = strBMID;

            objLBMBO = objBoothMemberBL.GetBoothMemberDetails(objboothMemberBO);
            return objLBMBO;
        }
    }
    [WebMethod]
    public List<TalukBO> GetTaulkByDID(string DistrictId)
    {
        return objCommonBL.GetTaulkByDID(DistrictId);

    }
    [WebMethod]
    public List<VillageBO> GetVillageByDID(string VillageId)
    {
        return objCommonBL.GetVillageByDID(VillageId);
    }

    [WebMethod]
    public bool ValidateAadharID(string strAadharID)
    {
        AadharBO objAadharIDBO = new AadharBO();

        if (string.IsNullOrEmpty(strAadharID))
        {
            return false;
        }
        else
        {
            AadharBL objAadharIDBL = new AadharBL();
            objAadharIDBO.AadharID = strAadharID;

            objAadharIDBO.Status = objAadharIDBL.ValidateAadharDetails(objAadharIDBO) == 1 ? true : false;
            return objAadharIDBO.Status;
        }

        // return "Hello World";
    }
    [WebMethod]
    public bool ValidateVoterID(string strVoter)
    {
        VoterBO objVoterIDBO = new VoterBO();
        //VoterBL objVoterIDBL = new VoterBL();
        VoterDA objVoterIDDA = new VoterDA();

        if (string.IsNullOrEmpty(strVoter))
        {
            return false;
        }
        else
        {

            objVoterIDBO.Voter = strVoter;
            objVoterIDBO.Status = objVoterIDDA.ValidateVetorDetails(objVoterIDBO) == 1 ? true : false;  //objVoterIDBL.ValidateVoterDetails(objVoterIDBO) == 1 ? true : false;

        }

        return objVoterIDBO.Status;
    }

    [WebMethod]
    
    public string CreateBoothMember(List<BoothMemberBO> BoothMemberBO)
    {
        BoothMemberBO objLBMBO = new BoothMemberBO();
        BoothMemberBL objBoothMemberBL = new BoothMemberBL();
        if (Session["DAID"] != null)
        {
            BoothMemberBO[0].ModifiedBy = (int)Session["DAID"];
        }
        objLBMBO.BoothMemberID = objBoothMemberBL.CreateBoothMemberDetails(BoothMemberBO);
        return objLBMBO.BoothMemberID;
    }


    [WebMethod]
    public List<BoothMemberBO> CreateLACMember(List<BoothMemberBO> BoothMemberBO)
    {
        List<BoothMemberBO> objLBMBO = new List<BoothMemberBO>();
        //  BoothMemberBL objBoothMemberBL = new BoothMemberBL();
        if (Session["DAID"] != null)
        {
            BoothMemberBO[0].ModifiedBy = (int)Session["DAID"];
        }
        // objLBMBO = objBoothMemberBL.CreateBoothMemberDetails(BoothMemberBO);

        return objLBMBO;
    }
    [WebMethod]
    public List<VoterBO> GetVoterDetailsByID(string strVoterID, int iEnrollment)
    {
        VoterBO objVoterBO = new VoterBO();
        List<VoterBO> objVDBO = new List<VoterBO>();
        if (string.IsNullOrEmpty(strVoterID))
        {
            return objVDBO;
        }
        else
        {
            VoterBL objVoterBL = new VoterBL();
            objVoterBO.Voter = (strVoterID == "0") ? string.Empty : strVoterID;
            objVoterBO.EnrollmentID = iEnrollment;
            objVDBO = objVoterBL.GetVoterDetailsByID(objVoterBO);
            return objVDBO;
        }
    }

    [WebMethod]
    public bool ValidateDACID(string strDACID)
    {
        if (string.IsNullOrEmpty(strDACID))
        {
            return false;
        }
        else
        {
            return objCommonBL.ValidateDACID(strDACID);
        }
    }
    [WebMethod(EnableSession = true)]
    public bool VerifyDALoginDetails(List<DECBO> DECBO)
    {
        int iDACID = 0;
        iDACID = objCommonBL.VerifyDALoginDetails(DECBO);
        if (iDACID > 0)
        {
            Session["DAID"] = iDACID.ToString();
        }
        return (iDACID > 0) ? true : false;
    }
    [WebMethod(EnableSession = true)]
    public bool VerifyBMLoginDetails(List<BoothMemberBO> BMBO)
    {
        int iBMID = 0;
        BoothMemberBL objBoothMemberBL = new BoothMemberBL();
        
        iBMID = objBoothMemberBL.VerifyBMLoginDetails(BMBO);
        if (iBMID > 0)
        {
            Session["BMID"] = iBMID.ToString();
        }
        return (iBMID > 0) ? true : false;
    }
    public bool UpdateVoterDetails(List<VoterBO> votersBO)
    {
        if(Session["BMID"]!=null)
        {
            votersBO[0].ModifiedBy = (int)Session["BMID"];
        }
        return true;
    }
    
}
