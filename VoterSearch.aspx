<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VoterSearch.aspx.cs" Inherits="Voter_VoterSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Voter Search</title>
    <link href="../Style/index.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <div class="container">
        <form id="districtAdminForm" onsubmit="validateDistrictAdminForm(event)">
            <h1>Verification Page</h1>
            <div class="radio-buttons">
                <label>
                    <input type="radio" name="ids" value="VoterID" id="rbVoterID" > Voter ID
                </label>
                <br>
                <label>
                    <input type="radio" name="ids" value="EnrollmentID" id="rbEnRoID"> Enrollment ID
                </label>
            </div>
            <div class="input-fields">
                <div id="voterId" >
                    <input type="text" id="txtVoterID"  /> <input type="button" id="btnVoterIDValidate" name="btnVoterIDValidate" value="Search"/>
                </div>
                
            </div>
            
            <table>
                <tr>
                  <th>Aadhar ID</th>
                  <th id="thName">Name</th>
                  <th>Status</th>
                  <th>Bio Metric</th>
                  <th>Update</th>
                </tr>
                <tr>
                    <td><span id="spnAadhar"></span></td>
                    <td><span id="spnName"></span></td>
                    <td>
                        <select name="VDstatus" id="VDstatus">
                            <option value="-1"> -- Select Status -- </option>
                            <option value="1">Yes</option>
                            <option value="0">No</option>
                        </select>
                    </td>
                    <td> </td>
                    <td><button type="button" id="uptButton">Update</button></td>
                </tr>
                
              </table>
        </form>
    </div>
        </div>
    </form>
    <script type="text/javascript">
        $("#ids").change(function () {
            alert($("#ids").val());
        });
        
        $("#rbVoterID").click(function () {
            $("#btnVoterIDValidate").val('Search Voter ID');
            $('#txtVoterID').val('');
            $('#txtVoterID').focus();
        });
         $("#rbEnRoID").click(function () {
             $("#btnVoterIDValidate").val('Search Enrollment ID');
             $('#txtVoterID').val('');
              $('#txtVoterID').focus();
        });
        $("#btnVoterIDValidate").click(function ()
        {
            alert('test : '+$('#txtVoterID').val());
        var v_VoterID;
        var v_EnRollID;
            var radioValue = $("input[name='ids']:checked").val();
           // alert('radioValue : ' + radioValue);
            if (radioValue == '' || radioValue == 'undefined')
            {
                alert('Please select radio value');
                $('#ids')[0].focus();
            }
            if ($('#txtVoterID').val() == 'undefined' || $('#txtVoterID').val() == '') {
                
               
                    if (radioValue == 'VoterID') {
                        alert('Please enter the Voter ID');
                        $('#txtVoterID').focus();
                        
                    }
                    else {
                        alert('Please enter the Enrollment ID');
                        $('#txtVoterID').focus();
                        
                    }
                
            }
            else
            {
                if (radioValue == 'VoterID') {
                    v_VoterID = $('#txtVoterID').val();
                    v_EnRollID = 0;
                }
                else {
                    v_EnRollID = $('#txtVoterID').val();
                    v_VoterID = 0;
                }
              //  alert('v_EnRollID' + v_EnRollID);
              //  alert('v_VoterID' + v_VoterID);

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "../WS_GetBPSDetails.asmx/GetVoterDetailsByID",
                    data: '{strVoterID:"' + v_VoterID + '",iEnrollment:"' + v_EnRollID + '" }',
                    dataType: "json",
                    success: function (result) {
                        if (result.d)
                        {
                            if (radioValue == 'VoterID') {
                               
                                $('#thName').html();
                                $('#thName').html("Voter Name");
                            }
                            else {
                               
                                $('#thName').html();
                                $('#thName').html("Enroll Name");
                            }
                           
                            $('#spnAadhar').html(result.d[0].AadharID); 
                            $('#spnName').html(result.d[0].VoterName);
                            if (result.d[0].Status)
                            {
                                $('VDstatus option').removeAttr('selected').filter('[value=1]').attr('selected', true);
                            }
                            else
                            {
                                $('VDstatus option').removeAttr('selected').filter('[value=2]').attr('selected', true)
                            }
                            
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
            }
    });
    </script>
</body>
</html>
