<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateLACDetails.aspx.cs" Inherits="Admin_I_U_BMDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Create LAC</title>
<script src="../Scripts/jquery-3.3.1.min.js" type="text/javascript"></script>
     <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
   <style type="text/css" src="../../styles.css" runat="server"></style>
    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
        }

        #form1 {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            flex-direction: column; 
            padding: 20px;
            border-radius: 10px;
            box-shadow: rgba(0, 0, 0, 0.1) 0px 0px 20px;
            background-color: powderblue;
        }

        #content {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        input[type="text"],
        input[type="button"],
        select {
            padding: 10px;
            margin-bottom: 10px;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            box-shadow: rgba(0, 0, 0, 0.1) 0px 0px 5px;
        }

        input[type="button"] {
            background-color: #007bff;
            color: #fff;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        input[type="button"]:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   
       
             <div>
<span>Add LAC Details</span>
               
   <br />

 <span>LAC Name: </span> <input type="text" id="txtLACName" />   
                 
  <br />
        
    
    
    
<span> States : </span>   <select id="ddlStates"> </select>   
              <br />
          <span> District : </span>   
        <select id="ddlDistrict"> </select>
               <br />
                  <span> Party List : </span>   
        <select id="ddlParty"> </select>
               <br />
        <br />
         
         </div>    
        <br/>
     <input type="button" id="btnLACCreate" name="btnLACCreate" value="Create"/>

    </form>
</body>
    
    <script type="text/javascript">
         $("#btnLACCreate").click(function () {

       
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../WS_GetBPSDetails.asmx/CreateLACDetails",
            data: '{strAadharID:"' + param + '"}',
           dataType: "json",
        success: function (result)
        {
               if (result.d)
               {
                  
                }
               else {
                   
                }
         },
            error: function (result) {
             $("#txtLACID").empty();
         alert('error : ' + result.d);
        }
    });

        });

        // Load States
       $(document).ready(function () {
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
 // Load Party
       $(document).ready(function () {
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
             $("#ddlParty").append($("<option></option>").val(result[i].StateID).
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
    
              var LACInfo = new Array();
              var  LACDetailsBO= new Object();
              LACDetailsBO["LACID"] = $('#txtLACID').val();
              LACDetailsBO["StateID"] = $('#ddlStates option:selected').val(); 
              LACDetailsBO["DistrictID"] = $('#ddlDistrict option:selected').val();
              LACInfo[0] = LACDetailsBO;
            var DTO = { 'LACDetailsBO': LACInfo };

               $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../WS_GetBPSDetails.asmx/CreateLACDetails",
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
