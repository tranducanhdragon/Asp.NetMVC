function XoaTheLoai(MaTheLoai) {
    if (confirm("Bạn có muốn xóa thể loại?")) {
        $.post("/Admin/TheLoai/Delete",
                {
                    "MaTheLoai": MaTheLoai,
                    "ThaoTac": "XoaTheLoai"
                },
                function (data, status) {
                    if (status == "success") {
                        alert(status);
                        $("#row_" + MaTheLoai).slideUp();
                    }
                }
            )
    }
}