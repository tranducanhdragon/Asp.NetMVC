function XoaTacGia(MaTG) {
    if (confirm("Bạn có muốn xóa tác giả?")) {
        $.ajax({
            type: "POST",
            url: "/Admin/TacGia/Delete",
            data:{"MaTG":MaTG},
            success: function (data, status) {
                alert(status);
                $('#row_' + MaTG).slideUp();
            }
        })
    }
}