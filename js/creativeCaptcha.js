$(document).ready(function() {
    console.log("I'm alive!");
    //Locate the form closest to the Captcha div
    $("#myCaptcha").parents("form").css("background", "yellow");

    // Request an image to trace
    $.get('/captcha/basic', function(data) {
        $(captcha).html('<img src="'+ data + '">');
    })
    // Add a fail catch because we can't talk to the back end
    .fail(function() {
        $(captcha).html('<img width="300" height="200" src="Images/BasicImages/House.png">');
    });
});