function GetSachFromDM(idDM) {
    $.ajax({
        url: '/Admin/Home/SachFromDM/' + idDM,
        type: 'GET',
        contentType: 'html',
        success: function (result) {
            $("#SachFromDM").empty().append(result);
        }
    });
}