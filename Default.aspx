<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> District Admin Page</title>
<script src="../Scripts/jquery-3.3.1.min.js" type="text/javascript"></script>
     <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
   <style type="text/css" src="../../styles.css" runat="server"></style>
  <%--  <link rel="stylesheet" href="//code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
       
    <script src= 
"https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js" > 
    </script> --%>
     


<%--  <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>--%>
</head>
<body>
    
        <div>
<span>Get Booth Member By ID</span>
            <span>BoothMemberID : </span> <input type="text" id="txtBMID" value="BMI000010"  />  <input type="button" id="btnBMValidate" name="btnBMValidate" value="BMValidate"/>
  <br />
        <span>Booth Memeber ID Format : BMI000000</span>
            <br />
            <span>Display Booth Member</span>
         
            <br />
    <div id="DisplayBMDetails">

    </div>        
        </div>
        <br />
         <div id="AddEditBMDetails">
             <span>BoothMemberID : </span> <input type="text" id="txtUBMID"  />
              <br />
            
             <br />
    <span>AadharID : </span> <input type="text" id="txtAAdharID"  />  <input type="button" id="btnAadharIDValidate" name="btnAadharIDValidate" value="AadharIDValidate"/>
  <br />
        <span>AadharID Format : XXXXXXXXXXXX</span>
    
    <br />
    <br />
     <span>VoterID : </span> <input type="text" id="txtVoterID"  />  <input type="button" id="btnVoterIDValidate" name="btnVoterIDValidate" value="VoterIDValidate"/>
  <br />
        <span>VoterID Format : XXXX</span>
             <span> BoothName Name : </span> <span>Test</span>
             <br />
            <span> States : </span>   <select id="ddlStates"> </select> <input type="button" id="btnStateLoad" name="LoadState" value="LoadState"/>
              <br />
          <span> District : </span>   
        <select id="ddlDistrict"> </select>
               <br />
        <br />
          <span> Taluk : </span>   
        <select id="ddlTaluk"> </select>
        <br />
        <br />
           <span> Village : </span>   
        <select id="ddlVillage"> </select>
        <br />
        <br />
          <span > Polling Date : </span>   
        <input type="text" id="my_date_picker"  />
         </div>        
       
   
</body>
     <script type = "text/javascript">

         $(function() { 
            $( "#my_date_picker" ).datepicker({ 
                defaultDate:"09/22/2019" 
            }); 
        }); 

  $('#btnStateLoad').click(function () {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WS_GetBPSDetails.asmx/GetStates",
        data: "{}",
        dataType: "json",
        success: function (result)
        {
             result=result.d;
             for (var i in result) {
             $("#ddlStates").append($("<option></option>").val(result[i].StateID).
               text(result[i].StateName));
              }

        },
        error: function (result) {
            debugger
           alert(result.d);
        }
    });
  });
    
    $("#btnBMValidate").click(function () {
     // alert($('#txtBMID').val());
        var param =  $('#txtBMID').val();
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../WS_GetBPSDetails.asmx/GetBMByID",
            data: '{strBMID:"' + param + '"}',
           dataType: "json",
        success: function (result)
        {
               if (result.d)
                {
                 //  alert('Valid Booth Member ID');
                   GenerateBMDetails(result.d);
                   // $('#txtBMID').enabled = false;
                }
                else {
                    alert('Invalid Booth Member ID');
                    $('#txtBMID').val() = "";
                }
         },
            error: function (result) {
             $("#txtBMID").empty();
         alert('error : ' + result.d);
         }
        });
         });

    $("#ddlStates").change(function () {
     //   alert($('#ddlStates option:selected').val());
        var param =  $('#ddlStates option:selected').val();
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../WS_GetBPSDetails.asmx/GetDistrictBySID",
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
         
    $("#ddlDistrict").change(function () {
        alert( $('#ddlDistrict option:selected').val());
        var param =  $('#ddlDistrict option:selected').val();
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../WS_GetBPSDetails.asmx/GetTaulkByDID",
            data: '{DistrictId:"' + param + '"}',
           dataType: "json",
        success: function (result)
        {
            if (result.d.length > 0) {
                result = result.d;
               for (var i in result) {
                   $("#ddlTaluk").append($("<option></option>").val(result[i].TalukID).
                       text(result[i].TalukName));
               }
            }
            else
            {
                $("#ddlTaluk").empty();
               
            }

        },
            error: function (result) {
             $("#ddlTaluk").empty();
         alert(result.d);
        }
        });

    });
        

                 
    $("#ddlTaluk").change(function () {
        alert( $('#ddlTaluk option:selected').val());
        var param =  $('#ddlTaluk option:selected').val();
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../WS_GetBPSDetails.asmx/GetVillageByDID",
            data: '{VillageId:"' + param + '"}',
           dataType: "json",
        success: function (result)
        {
            if (result.d.length > 0) {
                result = result.d;
               for (var i in result) {
                   $("#ddlVillage").append($("<option></option>").val(result[i].VillageID).
                       text(result[i].VillageName));
               }
            }
            else
            {
                $("#ddlVillage").empty();
               
            }

        },
            error: function (result) {
             $("#ddlVillage").empty();
         alert(result.d);
         }
        });

    });

    $("#btnBMValidate").click(function () {
      alert($('#txtBMID').val());
        var param =  $('#txtBMID').val();
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../WS_GetBPSDetails.asmx/ValidateBMID",
            data: '{strBoothMemberID:"' + param + '"}',
           dataType: "json",
        success: function (result)
        {
               if (result.d)
                {
                   alert('Valid Booth Member ID');
                   $('#txtBMID').enabled = false;
                }
                else {
                    alert('Invalid Booth Member ID');
                    $('#txtBMID').val() = "";
                }
         },
            error: function (result) {
             $("#txtBMID").empty();
         alert('error : ' + result.d);
        }
        });

    });
        

      
    $("#btnAadharIDValidate").click(function () {
      alert($('#txtAAdharID').val());
        var param =  $('#txtAAdharID').val();
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../WS_GetBPSDetails.asmx/ValidateAadharID",
            data: '{strAadharID:"' + param + '"}',
           dataType: "json",
        success: function (result)
        {
               if (result.d)
                {
                   alert('Valid Aadhar ID');
                   $('#txtAAdharID').enabled = false;
                }
                else {
                    alert('Invalid Aadhar ID');
                    $('#txtAAdharID').val() = "";
                }
         },
            error: function (result) {
             $("#txtAAdharID").empty();
         alert('error : ' + result.d);
        }
    });

    });
        

        
    $("#btnVoterIDValidate").click(function () {
      alert($('#txtVoterID').val());
        var param =  $('#txtVoterID').val();
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../WS_GetBPSDetails.asmx/ValidateVoterID",
            data: '{strVoter:"' + param + '"}',
           dataType: "json",
        success: function (result)
        {
               if (result.d)
                {
                   alert('Valid Voter ID');
                   $('#txtVoterID').enabled = false;
                }
                else {
                    alert('Invalid Voter ID');
                    $('#txtVoterID').val() = "";
                }
         },
            error: function (result) {
             $("#txtVoterID").empty();
         alert('error : ' + result.d);
        }
    });

    });


       //  });
         function GenerateBMDetails(output)
         {
             
             $("#DisplayBMDetails").append("<table style='font-family: Arial, Helvetica, sans-serif;border-collapse: collapse;width: 100%;'>");
             $("#DisplayBMDetails").append("<caption>Booth Member Details</caption>");
             $("#DisplayBMDetails").append("<thead>");
             $("#DisplayBMDetails").append("<tr>");
             $("#DisplayBMDetails").append("<th style='border: 1px solid #ddd;padding:8px;padding-top:12px;padding-bottom: 12px;text-align: left;background-color:#04AA6D;color: white;'>Booth Member ID</th>");
             $("#DisplayBMDetails").append("<th style='border: 1px solid #ddd;padding:8px;padding-top:12px;padding-bottom: 12px;text-align: left;background-color:#04AA6D;color: white;'>Name</th>");
             $("#DisplayBMDetails").append("<th style='border: 1px solid #ddd;padding:8px;padding-top:12px;padding-bottom: 12px;text-align: left;background-color:#04AA6D;color: white;'>Status</th>");
             $("#DisplayBMDetails").append("<th style='border: 1px solid #ddd;padding:8px;padding-top:12px;padding-bottom: 12px;text-align: left;background-color:#04AA6D;color: white;'>Edit</th>");
             $("#DisplayBMDetails").append("</tr>");
             $("#DisplayBMDetails").append("</thead>");
             $("#DisplayBMDetails").append("<tbody>");
             $("#DisplayBMDetails").append("<tr style='background-color:red;' onmouseover=\"this.style.backgroundColor='yellow'\"; onmouseout=\"this.style.backgroundColor=''\">");
             $("#DisplayBMDetails").append("<td id='txtDPBMID' style='border: 1px solid #ddd;padding:8px;' >" + output[0].BoothMemberID + "</td>");
             $("#DisplayBMDetails").append("<td style='border: 1px solid #ddd;padding:8px;'>" + output[0].BMName + "</td>");
             $("#DisplayBMDetails").append("<td style='border: 1px solid #ddd;padding:8px;'>" + output[0].Status + "</td>");
             $("#DisplayBMDetails").append("<td style='border: 1px solid #ddd;padding:8px;'><a href='#' id='lnkBMEdit'>Edit</a></td>");
             $("#DisplayBMDetails").append("</tr>");
             $("#DisplayBMDetails").append("</tbody>");
             $("#DisplayBMDetails").append("</table>");
         }
         

        dialog = $( "#AddEditBMDetails" ).dialog({
      autoOpen: false,
      height: 400,
      width: 350,
      modal: true,
      buttons: {
        "Update": UpdateBMDetails,
        Cancel: function() {
          dialog.dialog( "close" );
        }
      },
      close: function() {
         dialog.dialog( "close" );
      }
    });
 
   
    $( "#lnkBMEdit" ).button().on( "click", function() {
      dialog.dialog( "open" );
    });

        function UpdateBMDetails() {
             alert('tset');
             //alert($('#txtBMID').val());
             //var param = $('#txtBMID').val();
             //$.ajax({
             //    type: "POST",
             //    contentType: "application/json; charset=utf-8",
             //    url: "WS_GetBPSDetails.asmx/GetBMDetailsByID",
             //    data: '{strBoothMemberID:"' + param + '"}',
             //    dataType: "json",
             //    success: function (result) {
             //        if (result.d) {
             //            alert('Valid Booth Member ID');
             //            EditBMDetails(result.d);
             //            // $('#txtBMID').enabled = false;
             //        }
             //        else {
             //            alert('Invalid Booth Member ID');
             //            $('#txtBMID').val() = "";
             //        }
             //    },
             //    error: function (result) {
             //        $("#txtBMID").empty();
             //        alert('error : ' + result.d);
             //    }
             //});

         }

 $( function() {
    $( "#datepicker" ).datepicker();
  } );

     </script>
</html>
