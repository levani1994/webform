//$(document).ready(function () {
//    function ConfirmOnDelete(item) {
//        if (confirm("are you sure to delete: " + item + "?") == true)
//            return true;
//        else
//            return false;
//    }

//    $("#AddUserToggle").click(function () {
//        $("#Authors_div").slideToggle("slow");
//    });

//    $("#AddBookToggle").click(function () {
//        $("#Books_div").slideToggle("slow");
//    });
//    // Edit row on edit button click
//    $(document).on("click", ".edit", function () {

//       // var name = $(".name").eq(0).text();
//        var name = $.trim($(".name").eq(0).text());
//        console.log(name);
//        $(this).parents("tr").find("td:first").each(function () {
//            $(this).html('<input type="text" class="form-control" value="' + /*$(this).text() */ name + '">');
//        });
//        $(this).parents("tr").find(".add, .edit").toggle();
//        $(".add-new").attr("disabled", "disabled");
//    });
//    // Delete row on delete button click
//    $(document).on("click", ".delete", function () {
//        $(this).parents("tr").remove();
//        $(".add-new").removeAttr("disabled");
//    });


//   
//    $(".btn[data-target='#myModal']").click(function () {
//        var columnHeadings = $("thead th").map(function () {
//            return $(this).text();
//        }).get();
//        columnHeadings.pop();
//        var columnValues = $(this).parent().siblings().map(function () {
//            return $(this).text();
//        }).get();
//        var modalBody = $('<div id="modalContent"></div>');
//        var modalForm = $('<form role="form" name="modalForm" action="putYourPHPActionHere.php" method="post"></form>');
//        $.each(columnHeadings, function (i, columnHeader) {
//            var formGroup = $('<div class="form-group"></div>');
//            formGroup.append('<label for="' + columnHeader + '">' + columnHeader + '</label>');
//            formGroup.append('<input class="form-control" name="' + columnHeader + i + '" id="' + columnHeader + i + '" value="' + columnValues[i] + '" />');
//            modalForm.append(formGroup);
//        });
//        modalBody.append(modalForm);
//        $('.modal-body').html(modalBody);
//    });
//    $('.modal-footer .btn-primary').click(function () {
//        $('form[name="modalForm"]').submit();
//    });
//});

$(document).ready(function () {
    $(".btn-success").click(function(){
        $("#myModal").modal('show');
    });


});