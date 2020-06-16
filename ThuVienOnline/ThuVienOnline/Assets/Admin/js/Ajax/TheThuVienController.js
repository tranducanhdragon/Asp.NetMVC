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

function ChangeTrangThai(idThe) {
    $.ajax({
        url: '/Admin/TheThuVien/ChangeTrangThai',
        type: 'POST',
        data: { 'IDThe': idThe },
        dataType: 'json',
        success: function (response) {
            console.log(response);
            if (response.status == true) {
                $('#tt_' + idThe).text("Hoạt động");
            }
            else {
                $('#tt_' + idThe).text("Hết hạn");
            }
        }
    });
}
function MuonSachView(idThe) {
    $.ajax({
        url: '/Admin/TheThuVien/MuonSachView/'+idThe,
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            $("#MuonSachView").empty().append(result);
        }
    });
}
function Tra(idThe, idSach) {
    $.ajax({
        url: '/Admin/TheThuVien/Tra',
        type: 'POST',
        data: { 'IDSach': idSach, 'IDThe': idThe},
        dataType: 'html',
        success: function (result) {
            $("#MuonFromThe").empty().append(result);
        }
    });
}
function Muon(idSach, idThe) {
    var soluong = parseInt(prompt("Bạn muốn mượn bao nhiêu sách", '1'));
    $.ajax({
        url: '/Admin/TheThuVien/Muon',
        type: 'POST',
        data: { 'IDSach': idSach, 'IDThe': idThe, 'SoLuongSach':soluong},
        dataType: 'html',
        success: function (result) {
            $("#MuonFromThe").empty().append(result);
        }
    })
}