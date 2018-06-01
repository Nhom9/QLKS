var nv = {
    init: function () {
        nv.ChangeEvents();
    },
    ChangeEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/NhanVien/Change",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.CHUCVU == 1) {
                        btn.text('Thăng chức')
                    }
                    else {
                        btn.text('Giáng chức')
                    }

                }
            });
        });
    }
}
nv.init();