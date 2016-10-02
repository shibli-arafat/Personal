<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountryEdit.aspx.cs" Inherits="DefenseTraining.Web.CountryEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" href="Styles/Site.css" type="text/css" />
    <style type="text/css">
        input[type=text], select, textarea
        {
            width: 275px;
            margin-top: 2px;
            margin-bottom: 5px;
        }
        select
        {
            width: 279px;
        }
    </style>
    <script src="Scripts/json2.js" type="text/javascript"></script>
    <script src="scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/API/CountryEdit.js" type="text/javascript"></script>
    <script type="text/javascript">
        var _country = new CountryEdit();

        $(document).ready(function () {
            var queryString = decodeURI(window.location.search.substring(1));
            _country.populateGroups();
            _country.loadCountry(queryString);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 10px 20px;">
        <div>
            Name <span style="color: Red">*</span>
        </div>
        <div>
            <input type="text" id="txtName" maxlength="128" />
        </div>
        <div>
            Group <span style="color: Red">*</span>
        </div>
        <div>
            <select class="combobox" id="cmbGroups">
            </select>
        </div>
        <div style="text-align: center; margin-top: 10px;">
            <input type="button" id="btnSave" value="Save" onclick="_country.saveData();" />
        </div>
    </div>
    </form>
</body>
</html>
