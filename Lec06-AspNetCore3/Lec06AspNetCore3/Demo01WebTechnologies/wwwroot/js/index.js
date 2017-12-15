// Write your JavaScript code.
$("#increaseButton").on("click", function() {
    var counter = $("#counter").html();
    counter = parseInt($("#counter").html()) + 1;
    $("#counter").html(counter);
});

$("#showHideButton").on("mouseenter",
    function() {
        $("#counterContainer").hide();
    });

$("#showHideButton").on("mouseleave",
    function () {
        $("#counterContainer").show();
    });
$("#renderButton").on("click",
    function() {
        $.get("/home/getstudents",
            function(students) {

            });
    });
