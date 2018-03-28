var checkBoxProcessor = function (checkbocIdentifier, targetFormInput) {

    $("#" + checkbocIdentifier).click(function () {
        if ($(this).is(':checked')) {
            $("#" + targetFormInput).val(true);
        } else {
            $("#" + targetFormInput).val(false);
        };
    });

}