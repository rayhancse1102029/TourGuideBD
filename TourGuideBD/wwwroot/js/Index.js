$(document).ready(function () {

    $(".show-more-btn-click").click(function () {

        $(".travel-of-this-month-item-hidden-row").show();
        $(".show-more-btn-click").hide();
        $(".hide-more-btn-click").show();
    });
    $(".hide-more-btn-click").click(function () {

        $(".travel-of-this-month-item-hidden-row").hide();
        $(".show-more-btn-click").show();
        $(".hide-more-btn-click").hide();
    });

});