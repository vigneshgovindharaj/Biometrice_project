<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateVillageDetails.aspx.cs" Inherits="Admin_I_U_BMDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Create Booth Member</title>
<script src="../Scripts/jquery-3.3.1.min.js" type="text/javascript"></script>
     <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
   <style type="text/css" src="../../styles.css" runat="server"></style>
</head>
<body>
    <form id="form1" runat="server">
   
       
             <div>
<span>Add Booth Member Details</span>
               
   <br />
  <span>AadharID Format : XXXXXXXXXXXX</span>
                 <br />
 <span>AadharID : </span> <input type="text" id="txtAAdharID" value="123456789101"  />  <input type="button" id="btnAadharIDValidate" name="btnAadharIDValidate" value="AadharIDValidate"/> 
                 <span id="aadharvalmessage"></span>
  <br />
        
    
    <br />
    <br />
                <span>Alternate Mobile Number</span> <input type="text" id="txtAMB"  />
        <br />
<span> States : </span>   <select id="ddlStates"> </select>   <input type="button" id="btnStateLoad" name="LoadState" value="LoadState"/>
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
        <br/>
     <input type="button" id="btnBMCreate" name="btnBMCreate" value="Create"/>

    </form>
</body>
    <script type="text/javascript">
         $("#btnAadharIDValidate").click(function () {
    //  alert($('#txtAAdharID').val());
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
                   $('#aadharvalmessage').html("<span style='color:green'>Valid Aadhar Number</span>");
                  alert('Valid Aadhar ID');
                  // $('#txtAAdharID').enabled = false;
                }
               else {
                    $('#aadharvalmessage').html("<span style='color:red'>Invalid Aadhar Number</span>");
                   // alert('Invalid Aadhar ID');
                  //  $('#txtAAdharID').val() = "";
                }
         },
            error: function (result) {
             $("#txtAAdharID").empty();
         alert('error : ' + result.d);
        }
    });

        });

        // Load States
        $('#btnStateLoad').click(function () {
             $('#aadharvalmessage').html("");
        // $('#ddlStates').onready(function () {
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

        // District load by State ID
         $("#ddlStates").change(function () {
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
     // Taluk load by District ID    
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
        
// Village load by Taluk ID 
                 
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

          $("#btnBMCreate").click(function () {
    
              var BoothMemberInfo = new Array();
              var  BoothMemberBO= new Object();
              BoothMemberBO["AadharID"] = $('#txtAAdharID').val();
              BoothMemberBO["StateID"] = $('#ddlStates option:selected').val();
              BoothMemberBO["AlternateMobileNumber"] = $('#txtAMB').val();
              BoothMemberBO["DistrictID"] = $('#ddlDistrict option:selected').val();
              BoothMemberBO["TalukID"] = $('#ddlTaluk option:selected').val();
              BoothMemberBO["VillageID"] = $('#ddlVillage option:selected').val();
              BoothMemberBO["PollingDate"] = $('#my_date_picker').val();
              BoothMemberInfo[0] = BoothMemberBO;
            var DTO = { 'BoothMemberBO': BoothMemberInfo };

               $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../WS_GetBPSDetails.asmx/CreateBoothMember",
           data: JSON.stringify(DTO),
           dataType: "json",
        success: function (result)
        {
            if (result.d.length > 0) {
                result = result.d;
               //  $('#aadharvalmessage').html("<span style='color:Green'> BoothMember ID"+result+"</span>");
              // for (var i in result) {
                 //  $("#ddlVillage").append($("<option></option>").val(result[i].VillageID).
                   //    text(result[i].VillageName));
              // }
            }
            else
            {
               // $("#ddlVillage").empty();
               
            }

        },
            error: function (result) {
           //  $("#ddlVillage").empty();
         alert(result.d);
         }
  });

    });

    </script>
</html>
