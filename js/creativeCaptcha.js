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
    })
    // Add a fail catch because we can't talk to the back end
    .fail(function() {
        $(captcha).html('<img width="300" height="200" src="Images/BasicImages/House.png">');
    });
    // Detect mouse movements
        var mouseMovements = [];
        var position;
    $('html').mousemove(function(event){
        position = {
            x: event.pageX,
            y: event.pageY
        };
        //console.log(position.x);
        mouseMovements.push(position);
        console.log(mouseMovements);
        // "Draw" the outline from mouse movement
        var color = 'red';
        var size = '2px';
        $("body").append(
            $('<div></div>')
                .css('position', 'absolute')
                .css('top', event.pageY + 'px')
                .css('left', event.pageX + 'px')
                .css('width', size)
                .css('height', size)
                .css('background-color', color)
        );
    }); 
});
