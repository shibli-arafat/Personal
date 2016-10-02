var detailUrl;
var detailHeight;
var detailWidth;
function OpenDetail(idVale) {
    if (detailWidth == null) {
        detailWidth = 420;
    }
    var url = detailUrl + '?ID=' + idVale;
    url += "&rnd=" + Math.random();
    var result = window.showModalDialog(url, window, "dialogWidth:" + detailWidth + "px;dialogHeight:" + detailHeight + "px;status:no;resizable:no;scroll:no;");
    if (result == 1)//SUCCESS
    {
        return true;
    }
    return false;
}

function isNumeric(input) {
    return (input - 0) == input && input.length > 0;
}

function isDate(input) {
    var format = /^\d{2}\/\d{2}\/\d{4}$/;
    return format.test(input);
}
