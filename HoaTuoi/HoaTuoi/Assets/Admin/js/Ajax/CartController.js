function XoaMua(IDHoa) {
    if (confirm("Bạn có muốn xóa loại hoa này?")) {
        $.post("/CartHoa/DeleteMua",
                {
                    "IDHoa": IDHoa,
                },
                function (data, status) {
                    alert(status);
                    $("#row_" + IDHoa).slideUp();
                }
            )
    }
}