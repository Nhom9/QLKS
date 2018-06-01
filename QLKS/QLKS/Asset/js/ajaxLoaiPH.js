  <script>
            function myFunction() {
                // ajax là dùng để load bất đồng bộ// nghe khó hiểu đúng không ? là vậy nè: khi chọn loại phòng thì nó gọi tới hàm myFunction
                // hàm này gọi ajax nó truyền vào url lấy phòng theo id
                $.ajax({
                    url: '/ThuePhongs/GetDropDownTenPhong/' + $('#loaiphong :selected').val(),
                    type: 'POST',
                    dataType: 'json',

                    success: function (data) {
                        // khi load thành công thì nó vào chỗ này

                        $(".tenphong").html('<option value="">Vui lòng chọn phòng</option>');// dùng để thêm option vào dropdownlist
                        $.each(data, function () {
                            //this.id là để lấy id tương tự this.name là lấy name // vd this.status thì em lấy cột đó :)
                            // ủa a, h e thêm ddkien chỉ load những phòng còn trống thôi. thì e thêm ở đâu, nó dính thêm cột status :'(
                            $(".tenphong").append('<option value="' + this.id + '">' + this.tenPhong + '</option>');
                        });// này là code jquery em có thể tìm hiểu trên mạng
                    },
                    //e còn chưa hình dung đc cái khúc tính tiền sẽ ntn. thấy lấy dữ lieuj nó tùm lum qá :((/sua database truoc di... lam code truoc sua database lai la met lam :)))
                    //
                    error: function (err) {
                        // khi load không được thì nó vào hàm này,
                        alert("Có lỗi, vui lòng load lại !");//báo lỗi trên màn hình
                    }
                })
            }
    </script>
