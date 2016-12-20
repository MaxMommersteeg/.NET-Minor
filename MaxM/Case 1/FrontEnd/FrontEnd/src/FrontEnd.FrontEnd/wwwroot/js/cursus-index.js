$(document).ready(function () {

    $("#btnShowCursussenByYearAndWeek").on("click", function () {
        // Retrieve ddlYears and ddlWeekNumbers dropdownlists
        var rawCurrentYear = $("#ddlYears").val();
        var rawCurrentWeekNumber = $("#ddlWeekNumbers").val();

        if (isNaN(rawCurrentYear)) {
            defaultIndex();
        }
        if(isNaN(rawCurrentWeekNumber)) {
            defaultIndex();
        }

        // Parse CurrentYear and CurrentWeekNumber to ints
        var currentYear = parseInt(rawCurrentYear);
        var currentWeekNumber = parseInt(rawCurrentWeekNumber);

        // Redirect page
        callIndex(currentYear, currentWeekNumber);
    });

    $("#btnPreviousWeek").on("click", function () {
        // Retrieve ddlYears and ddlWeekNumbers dropdownlists
        var rawCurrentYear = $("#ddlYears").val();
        var rawCurrentWeekNumber = $("#ddlWeekNumbers").val();

        if (isNaN(rawCurrentYear)) {
            defaultIndex();
            return;
        }
        if (isNaN(rawCurrentWeekNumber)) {
            defaultIndex();
            return;
        }

        // Parse CurrentYear and CurrentWeekNumber to ints
        var currentYear = parseInt(rawCurrentYear);
        var currentWeekNumber = parseInt(rawCurrentWeekNumber);

        // Check border value
        var previousWeek = currentWeekNumber - 1;
        if (previousWeek < 1) {
            callIndex(currentYear - 1, 53);
            return;
        }
        // Redirect page
        callIndex(currentYear, previousWeek);
    });

    $("#btnNextWeek").on("click", function () {
        // Retrieve ddlYears and ddlWeekNumbers dropdownlists
        var rawCurrentYear = $("#ddlYears").val();
        var rawCurrentWeekNumber = $("#ddlWeekNumbers").val();

        if (isNaN(rawCurrentYear)) {
            defaultIndex();
            return;
        }
        if (isNaN(rawCurrentWeekNumber)) {
            defaultIndex();
            return;
        }

        // Parse CurrentYear and CurrentWeekNumber to ints
        var currentYear = parseInt(rawCurrentYear);
        var currentWeekNumber = parseInt(rawCurrentWeekNumber);

        // Check border value
        var nextWeek = currentWeekNumber + 1;
        if (nextWeek > 53) {
            callIndex(currentYear + 1, 1);
            return;
        }
        // Redirect page
        callIndex(currentYear, nextWeek);
    });

    function callIndex(year, week) {
        // Call Index view with given parameters
        var url = '/Cursus/Index/' + year + '/' + week;
        window.location = url;
    }

    function defaultIndex() {
        var url = '/Cursus/Index';
        window.location = url;
    }
});