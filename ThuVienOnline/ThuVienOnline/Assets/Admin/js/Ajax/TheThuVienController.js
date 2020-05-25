function XoaTheThuVien(IDThe) {
    if (confirm("Bạn có muốn xóa thẻ thư viện?")) {
        $.post("/Admin/TheThuVien/Delete",
                {
                    "IDThe": IDThe,
                },
                function (data, status) {
                    if (status == "success") {
                        alert(status);
                        $("#row_" + IDThe).slideUp();
                    }
                }
            )
    }
}

function GetMuonFromTheThuVien(idThe) {
    $.ajax({
        url: '/Admin/TheThuVien/MuonFromTheThuVien/' + idThe,
        type: 'GET',
        contentType: 'html',
        success: function (result) {
            $("#MuonFromThe").empty().append(result);
        }
    });
}