<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Login</title>
    <link rel="stylesheet" href="style/styles.css"/>
    <script src="Scripts/jquery-3.3.1.min.js" type="text/javascript"></script>
</head>
<body>
    <div class="container">
        <div class="leftBox">
            <h2>Booth Member Login</h2>
            <form id="loginForm">
                <label >Booth Member ID:</label>
                <input type="text" id="txtBMID" title="Booth Memeber ID Format : BMIXXXXXX" maxlength="10"  />
                <div class="input-group">
                    <label >Aadhar ID:</label>
                    <input type="text" id="txtAAdharID" title="AadharID Format : XXXXXXXXXXXX" maxlength="12" />
                </div>
                 <input type="button" id="btnValidateBioMetric" value="Click for Biometric"/>
                <br />
                 <br />
                 <br />
                <button type="button" id="submitButton">Verify</button>
            </form>
        </div>
        <div class="rightBox">
            <h2>District Admin Page</h2>
           
                <label >Admin ID:</label>
                <input type="text" id="txtadminId" name="txtadminId" placeholder="Enter Admin ID"/>

                <label >State:</label>
            <div class="custom-select">
                <select id="ddlStates"> </select> 
             </div>   
                
                <label >District:</label>
            <div class="custom-select">
                <select id="ddlDistrict"> </select>
                </div>
            <br />
                 <input type="button" id="btnValidateBioMetric" value="Click for Biometric"/>
                <br />
             <br />
             <br />
                <button type="button" value="Verify Details" id="btnDACVerify">Verify Details</button> 
             <br />
                 <div class="biometric">Biometric</div>
            
        </div>
    </div>
    <div class="biometric">Biometric</div>
    <div id="date"></div>
    <div id="time"></div>
 
    
   <%-- <script src="Scripts/login.js"></script>--%>
    <script type="text/javascript">
        $("#txtBMID").mouseout(function () {
           
                var param = $('#txtBMID').val();
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "WS_GetBPSDetails.asmx/ValidateBMID",
                    data: '{strBoothMemberID:"' + param + '"}',
                    dataType: "json",
                    success: function (result) {
                        if (!result.d) {
                            alert('Invalid Booth Number');
                            $("#txtBMID").val('');
                            $("#txtBMID").focus();
                        }
                    },
                    error: function (result) {
                        $("#txtBMID").empty();

                        alert('error : ' + result.d);
                    }
                });
        });

        $("#txtAAdharID").mouseout(function ()
        {
            if ($('#txtBMID').val() == 'undefined' || $('#txtBMID').val() == '')
            {
                $("#txtBMID").val('');
                $("#txtBMID").focus();
            }
            else if ($('#txtAAdharID').val() == 'undefined' || $('#txtAAdharID').val() == '')
            {
                alert('Invalid Aadhar ID');
                $("#txtAAdharID").val('');
                $("#txtAAdharID").focus();
            }
            else
            {
                var param = $('#txtAAdharID').val();
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "WS_GetBPSDetails.asmx/ValidateAadharID",
                    data: '{strAadharID:"' + param + '"}',
                    dataType: "json",
                    success: function (result) {
                        if (!result.d) {
                            alert('Invalid Aadhar ID');
                            $("#txtAAdharID").val('');
                            $("#txtAAdharID").focus();
                        }
                    },
                    error: function (result) {
                        $("#txtAAdharID").empty();
                        alert('error : ' + result.d);
                    }
                });
            }
        });

         $("#txtadminId").mouseout(function () {
           
                var param = $('#txtadminId').val();
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "WS_GetBPSDetails.asmx/ValidateDACID",
                    data: '{strDACID:"' + param + '"}',
                    dataType: "json",
                    success: function (result) {
                        if (!result.d) {
                            alert('Invalid District Admin Number');
                            $("#txtadminId").val('');
                            $("#txtadminId").focus();
                        }
                    },
                    error: function (result) {
                        $("#txtadminId").empty();

                        alert('error : ' + result.d);
                    }
                });
        });

 // Load States
         $(document).ready(function () {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WS_GetBPSDetails.asmx/GetStates",
        data: "{}",
        dataType: "json",
        success: function (result)
        {
             $("#ddlStates").append($("<option selected></option>").val(0).
               text('-- Select State Name --'));
             result=result.d;
             for (var i in result) {
             $("#ddlStates").append($("<option></option>").val(result[i].StateID).
               text(result[i].StateName));
              }

        },
        error: function (result) {
            alert(result.d);
        }
    });
        });

        // District load by State ID
         $("#ddlStates").change(function () {
             var param = $('#ddlStates option:selected').val();
             $("#ddlDistrict").empty();
             $("#ddlDistrict").append($("<option selected></option>").val(0).
               text('-- Select District Name --'));
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "WS_GetBPSDetails.asmx/GetDistrictBySID",
            data: '{stateid:"' + param + '"}',
           dataType: "json",
        success: function (result)
        {
            if (result.d.length > 0) {
                result = result.d;
               for (var i in result) {
                   $("#ddlDistrict").append($("<option></option>").val(result[i].DistrictID).
                       text(result[i].DistrictName));
               }
            }
            else
            {
                $("#ddlDistrict").empty();
            }
        },
            error: function (result) {
             $("#ddlDistrict").empty();
         alert(result.d);
        }
    });
        });
        $("#btnValidateBioMetric").click(function () {
            alert('Biometric Validated');
        });
        $("#btnDACVerify").click(function ()
        {
            
            if ($('#ddlStates option:selected').val() == 0) {
                alert('Please choose States to login');
                $('#ddlStates').focus();
            }
            else if ($('#ddlDistrict option:selected').val() == 0) {
                alert('Please choose District to login');
                 $('#ddlDistrict').focus();
            }
            else 
            {
                 var DACInfo = new Array();
              var  DACBO= new Object();
              DACBO["DecID"] = $('#txtadminId').val();
              DACBO["StateID"] = $('#ddlStates option:selected').val();
              DACBO["DistrictID"] = $('#ddlDistrict option:selected').val();
              DACInfo[0] = DACBO;
            var DTO = { 'DECBO': DACInfo };
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "WS_GetBPSDetails.asmx/VerifyDALoginDetails",
                     data: JSON.stringify(DTO),
                    dataType: "json",
                    success: function (result)
                    {
                       window.open("Admin/DistrictAdmins.aspx", "_self");
                    },
                    error: function (result)
                    {
                        alert(result.d);
                    }
                });
            }
        });
 $("#submitButton").click(function ()
        {
              var BoothMemberInfo = new Array();
              var  BoothMemberBO= new Object();
              BoothMemberBO["BoothMemberID"] = $('#txtBMID').val();
              BoothMemberBO["AadharID"] = $('#txtAAdharID').val();
             
              BoothMemberInfo[0] = BoothMemberBO;
            var DTO = { 'BMBO': BoothMemberInfo };
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "WS_GetBPSDetails.asmx/VerifyBMLoginDetails",
                     data: JSON.stringify(DTO),
                    dataType: "json",
                    success: function (result)
                    {
                       window.open("Voter/VoterSearch.aspx", "_self");
                    },
                    error: function (result)
                    {
                        alert(result.d);
                    }
                });
      });
    </script>
</body>
</html>
