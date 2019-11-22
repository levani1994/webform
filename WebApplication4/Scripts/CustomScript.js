$(document).ready(function () {
    var selectedTrId = 0;
    var ReloadURL = window.location.href;
    $('#UpdateBtn').click(function () {
        var Name = $('#UserName').val();
        var Surname = $('#Surname').val();
        var Email = $('#Email').val();
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/UserControll.aspx/Update",
            data: JSON.stringify({ 'id': selectedTrId, 'name': Name, 'surname': Surname, 'email': Email }),
            datatype: "json",
            success: function () {
                window.location.replace(ReloadURL);
            },
            error: function () {
                alert(" conection to the server failed ");
            }
        });
    });

    $('.btn-success').click(function () {
        selectedTrId = $(this).data('id');
        $.ajax({
            url: '/UserControll.aspx/GetUserDetails',
            method: 'GET',
            data: { 'id': selectedTrId },
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                var user = response.d;
                $('#UserName').val(user.UserName);
                $('#Surname').val(user.UserSurname);
                $('#Email').val(user.UserEmail);
                for (var i in user.UserRoles) {
                    var id = user.UserRoles[i].ID;
                    $('#' + id).attr('checked', 'checked');

                }
                
            }
        });
    });


    //$('#myModal').on('hide.bs.modal', function () {
    //   // $('#modal-div').each(function () {
    //        $('#' + 1).attr('checked', 'checked');
    //   // });
    //    });

});