<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileSelector.aspx.cs" Inherits="ArmyTraining.FileSelector" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base target="_self" />
    <title>Upload File</title>
    <script src="js/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function onLoad() {
            <%=JsMethod %>
        }
    </script>
</head>
<body onload="onLoad();">
    <form id="form1" runat="server">
    <div>
        <input type="file" id="fileUploader" size="30" runat="server" />
    </div>
    <div>
        <asp:Button ID="btnOk" Text="OK" OnClick="UploadFile" runat="server" />
    </div>
    </form>
</body>
</html>
