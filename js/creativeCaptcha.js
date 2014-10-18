$(document).ready(function() {
    console.log("I'm alive!");
    //Locate the form closest to the Captcha div
    $("#myCaptcha").parents("form").submit(function(event) {
    event.preventDefault();
    console.log("Hello!");
    });
    // Request an image to trace
    $.get('/captcha/basic', function(data) {
        $(captcha).html('<img src="'+ data + '">');
    });
});
