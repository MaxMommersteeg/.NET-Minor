$(document).ready(function () {

    $("[name='cbUseDateRange']").on("change", function () {
        var dpStartDate = $("#dpStartDate");
        var dpEndDate = $("#dpEndDate");

        dpStartDate.prop('disabled', !this.checked);
        dpEndDate.prop('disabled', !this.checked);
    });
});