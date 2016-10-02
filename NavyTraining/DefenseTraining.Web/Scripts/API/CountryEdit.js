function CountryEdit() {
    this.country = new Object();
}

CountryEdit.prototype.populateGroups = function () {
    var options = $("#cmbGroups");
    var groups = new Array();
    groups.push({ Id: 1, Name: "Group1" });
    groups.push({ Id: 2, Name: "Group2" });
    groups.push({ Id: 3, Name: "Group3" });
    options.append($("<option />").val(0).text("Please Select"));
    $.each(groups, function () {
        options.append($("<option />").val(this.Id).text(this.Name));
    });
}

CountryEdit.prototype.populateCountry = function () {
    $("#txtName").val(this.country.Name);
    $("#cmbGroups").val(parseInt(this.country.Group, 10));
}

CountryEdit.prototype.saveData = function () {
    this.country.Name = $.trim($("#txtName").val());
    this.country.Group = $("#cmbGroups").val();
    if (this.country.Name == "") {
        alert("Please enter name\n");
        $("#txtName").focus();
        return;
    }
    $.ajax({
        type: "POST",
        url: "CountryEdit.aspx/SaveCountry",
        data: JSON.stringify({ country: this.country }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d.IsSuccessful) {
                this.country = data.d.Data;
                window.parent.populateData();
            }
            else {
                alert(data.d.ErrorMessage);
            }
        },
        error: function (msg) {
            alert(msg);
        }
    });
}

CountryEdit.prototype.loadCountry = function (queryString) {
    var thisObj = this;
    var parms = queryString.split('&');
    var id = parms[0].substring(parms[0].indexOf("=") + 1);
    if (id == 0) return;
    $.ajax({
        type: "POST",
        url: "CountryEdit.aspx/GetCountry",
        data: JSON.stringify({ id: id }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d.IsSuccessful) {
                thisObj.country = data.d.Data;
                thisObj.populateCountry();
            }
            else {
                alert(data.d.ErrorMessage);
            }
        },
        error: function (msg) {
            alert(msg);
        }
    });
}