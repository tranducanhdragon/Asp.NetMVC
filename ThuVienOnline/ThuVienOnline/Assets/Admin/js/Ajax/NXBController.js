function XoaNXB(MaNXB) {
    if (confirm("Bạn có muốn xóa NXB?")) {
        $.post("/Admin/NXB/Delete",
                {
                    "MaNXB": MaNXB,
                    "ThaoTac": "XoaNXB"
                },
                function (data, status) {
                    if (status == "success") {
                        alert(status);
                        $("#row_" + MaNXB).slideUp();
                    }
                }
            )
    }
}