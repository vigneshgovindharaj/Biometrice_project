<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DistrictAdmins.aspx.cs" Inherits="Admin_DistrictAdmins" %>

<%@ Register Src="~/Admin/UCDECAdmin.ascx" TagPrefix="uc1" TagName="UCDECAdmin" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:UCDECAdmin runat="server" ID="UCDECAdmin" />
            Center page
        </div>
    </form>
</body>
</html>
