function XoaSach(MaSach) {
    if (confirm("Bạn có muốn xóa sách?")) {
        $.ajax({
            type: 'POST',
            url: '/Admin/Sach/Delete',
            data: { 'MaSach':MaSach },
            success: function(data, status) {
                alert(status);
                $("#row_" + MaSach).slideUp();
            },
            error: function(data){
                alert(data);
        }
        })
    }
}