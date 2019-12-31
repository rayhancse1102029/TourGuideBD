$(document).ready(function () {

    // load all distric

    $('#division-id').change(function () {
        var id = $("#division-id option:selected").val();
        $.ajax({
            url: "/AjaxCall/GetDistricList/" + id,
            type: "GET",
            dataType: "JSON",
            success: function (data) {

                $("#distric-id").empty();
                $("#place-id").empty();

                var s = '<option value=' + 0 + '>' + '---Select Distric----' + '</option>';

                $.each(data, function (i, d) {
                    s += '<option value=' + d.districId + '>' + d.districName + '</   option>';
                });
                $("#distric-id").append(s);
                $("#place-id").append('<option value=' + 0 + '>' + '---Select Place----' + '</option>');
            }
        });
    });

    //  load all place 

    $('#distric-id').change(function () {
        var id = $("#distric-id option:selected").val();
        $.ajax({
            url: "/AjaxCall/GetPlaceList/" + id,
            type: "GET",
            dataType: "JSON",
            success: function (data) {

                $("#place-id").empty();

                var s = '<option value=' + 0 + '>' + '---Select Place----' + '</option>';

                $.each(data, function (i, d) {
                    s += '<option value=' + d.placeId + '>' + d.placeName + '</option>';
                });
                $("#place-id").append(s);
            }
        });
    });

});