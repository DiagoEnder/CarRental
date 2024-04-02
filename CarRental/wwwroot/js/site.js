// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function FillLoais(lstHangCtrl, lstLoaiId) {

    var lstLoais = $("#" + lstLoaiId);
    lstLoais.empty();


    var selectedHang = lstHangCtrl.options[lstHangCtrl.selectedIndex].value;

    if (selectedHang != null && selectedHang != '') {
        $.getJSON("/Admin/InfoXes/GetLoaiByHang", { hangId: selectedHang }, function (loais) {
            if (loais != null && !jQuery.isEmptyObject(loais)) {
                $.each(loais, function (index, loai) {
                    lstLoais.append($('<option/>',
                        {
                            value: loai.value,
                            text: loai.text
                        }));
                });
            };
        });
    }
    return;
}


//-----------------------------  XỬ LÍ TRANG PROFILE DÙNG CHUNG DUNCTION -----------------

function getdataDuyetXe() {

    $.ajax({
        type: "Get",
        url: "/Profiles/StateXe",
        success: function (data) {
            $("#content").html(data);
            console.log("da log trang state");
        },
        error: function () {
            alert("error API");
        }
    });
}

function validateInput(input) {
    
    var regex = /^[a-zA-Z0-9]+@{0,1}$/;
    return regex.test(input);
}


function getdataChuyendiCus() {
    $.ajax({
        type: "Get",
        url: "/Profiles/Chuyendi",
        success: function (data) {
            $("#contentList").html(data);
            console.log("da log trnag chueyn di cho user");
        },
        error: function () {
            alert("error API");
        }
    });
}

function getdataChuyendidaduyet() {
    $.ajax({
        type: "Get",
        url: "/Profiles/Chuyendihientai",
        success: function (data) {
            $("#contentList").html(data);
            console.log("da log chuyen trang hoan thanh cho user");
        },
        error: function () {
            alert("error API");
        }
    });
}

function getdataChuyendidathanhtoan() {
    $.ajax({
        type: "Get",
        url: "/Profiles/chuyenxedathanhtoan",
        success: function (data) {
            $("#contentList").html(data);
            console.log("da log chuyen trang hoan thanh cho user");
        },
        error: function () {
            alert("error API");
        }
    });
}

function CheckInfoUser() {

    $.ajax({
        type: "GET",
        url: "/Home/CheckInfoUser",
        success: function (res) {
            // Kiểm tra res và res.result
            if (res && res.result == 0) {

                $('#dangkiModal').modal('show');
            } else {
                $('#DatXeModal').modal('show');
            };
        },
        error: function () {
            alert("Có lỗi khi kiểm tra thông tin người dùng.");
        }
    });

}


function ThanhToan() {
    $("#thanhtoan").click(function () {

        var Id = $("#Idddx").val();
        var Idchu = $("#Idchu").val();

        var tol = parseFloat($("#totalGia").text());


        console.log(tol);

        $.ajax({

            type: "Post",
            url: "/Profiles/ThanhToan",
            data: {
                Idchu: Idchu,
                Id: Id,
                Total: tol
            },
            success: function () {
                $('#thongbao').modal('show');

            },
            error: function () {
                alert("Sai APi");
            }


        });



    });

    $("#ok").click(function () {
        window.location.href = "/Home/Index";
    });
}

function checkLogin() {

    $("#btndatxe").click(function () {

        if (userId) {
            console.log("da chay checkinfo user");
            CheckInfoUser();
        }
        else {
            alert("Login để đặt xe");
        }

    });

    //-------- CLOSE MODAL AT THERE- --- -

    $(".closeModal").click(function () {
        $(this).closest('.modal').modal('hide');

    });

}




