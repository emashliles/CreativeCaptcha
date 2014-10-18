$(document).ready(function() {
    console.log("I'm alive!");
    // Locate the form closest to the Captcha div
    $("#myCaptcha").parents("form").submit(function(event) {
    event.preventDefault();
    console.log("Hello!");
    });
    // Request an image to trace
    $.get('/captcha/basic', function(data) {
        $(captcha).html('<img src="'+ data + '">');
        $("#myCanvas").css("background-image", '"'+data+'"');
    })
    // Add a fail catch because we can't talk to the back end
    .fail(function() {
        //$(captcha).html('<img width="300" height="200" src="Images/BasicImages/House.png">');
        $("#myCanvas").css({
                                    "width": 300, "height": 300, 
                                    "background-image": "url(Images/BasicImages/House.png)",
                                    "background-repeat": "no-repeat",
                                    "background-position": "center", 
                                    "opacity": 0.4
                                });
    });
    // Detect mouse movements on mouse down event
    var mouseMovements = [];
    var position;
    $(captcha).mousedown(function() {
        // Add mouse positions in mouseMovements list
        $("html").mousemove(function(event){
            position = {
                x: event.pageX,
                y: event.pageY
            };
            mouseMovements.push(position);
        });
    });
    $(captcha).mouseup(function() {
        $("html").unbind("mousemove");
        // Now you can use mouseMovements
    }); 
});


