$(document).ready(function() {
    // Locate the form closest to the Captcha div
    $("#myCaptcha").parents("form").submit(function(event) {
        event.preventDefault();
    });

    // Request an image to trace
    $.get('/captcha/basic', function(data) {
        $("#myCanvas").css({
            "width": 300, "height": 300,
            "background-image": "url(" + data + ")",
            "background-repeat": "no-repeat",
            "background-position": "center",
            "opacity": 0.4
        });
    })
    // Add a fail catch because we can't talk to the back end
    .fail(function() {
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
    $(captcha).mousedown(function () {
        // Add mouse positions in mouseMovements list
        $(document).mousemove(function (event) {
            position = {
                left: event.pageX,
                top: event.pageY
            };
            mouseMovements.push(position);
        });
    });

    $(captcha).mouseup(function () {
        $(document).unbind("mousemove");
        // Now you can use mouseMovements
    });

    // Loop through detected mousemovements and simplify them
    $(captcha).click(function () {
        var directions = [];
        $.each(mouseMovements, function (index, co) {
            if (index > 0) {
                // Get the direction and add it if a new direction
                var direction, angle, primary, secondary;
                if (directions.length > 0)
                {
                    prev = directions[(directions.length - 1)].start;
                }
                else
                {
                    prev = mouseMovements[0];
                }
                var left = prev.left - co.left;
                var top = prev.top - co.top;
                if ((Math.abs(left) + Math.abs(top)) > 0)
                {
                    if (top < 0)
                    {
                        primary = 'S';
                    }
                    else
                    {
                        primary = 'N';
                    }
                    if (left < 0)
                    {
                        secondary = 'E';
                    }
                    else
                    {
                        secondary = 'W';
                    }
                    if (left == 0)
                    {
                        angle = 90;
                    }
                    else if (top == 0)
                    {
                        angle = 0;
                    }
                    else
                    {
                        var angle = Math.atan(Math.abs(top) / Math.abs(left)) * 180 / Math.PI;
                    }
                    if (angle <= 22.5)
                    {
                        direction = secondary;
                    }
                    else if (angle > 22.5 && angle <= 67.5)
                    {
                        direction =  primary + secondary;
                    }
                    else
                    {
                        direction = primary;
                    }

                    // Create first direction object
                    if (directions.length == 0) {
                        directions.push({'direction': direction, 'start': {'left': co.left, 'top': co.top}});
                    }
                    // And subsequent directions if they are a change from the first
                    else if (direction != directions[(directions.length - 1)].direction) {
                        prevDirection = directions[(directions.length - 1)].start;
                        var length = (prevDirection.left - co.left) * (prevDirection.left - co.left);
                        length += (prevDirection.top - co.top) * (prevDirection.top - co.top);
                        directions[(directions.length - 1)].length = Math.round(Math.sqrt(length));
                        delete directions[(directions.length - 1)].start;
                        if ((mouseMovements.length - 1) == index)
                        {
                            directions.push({'direction': direction, 'length': 1});
                        }
                        else
                        {
                            directions.push({'direction': direction, 'start': {'left': co.left, 'top': co.top}});
                        }
                    }
                    else if ((mouseMovements.length - 1) == index) {
                        prevDirection = directions[(directions.length - 1)].start;
                        var length = (prevDirection.left - co.left) * (prevDirection.left - co.left);
                        length += (prevDirection.top - co.top) * (prevDirection.top - co.top);
                        directions[(directions.length - 1)].length = Math.round(Math.sqrt(length));
                        delete directions[(directions.length - 1)].start;
                    }
                }
            }
        });
    });
});
