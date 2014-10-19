$(document).ready(function() {
    var url = "http://creativecaptcha1-001-site1.smarterasp.net/backend6/CreativeCaptcha.WebApi/";
    var jsCaptcha = false;
    var pjs;
    // Locate the form closest to the Captcha div
    $(captcha).parents("form").submit(function(event) {
        event.preventDefault();
        console.log('hello');
    });
    $(captcha).parents("form").children(':submit').attr('disabled', 'disabled')
    getPjsInstance();
    $('#reset').click(function(){ pjs.setup();});
    $(captcha).on('captchaInitiated', function() {
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
            directions = parseDirections(mouseMovements);
            console.log(JSON.stringify(directions));
            if (jsCaptcha) {
                $.post(url+'validate/basic', {
                    'ID': captchaId,
                    'Movements': directions
                }, function (data) {
                    data = $.parseJSON(data);
                    if (data['IsHuman'] == 'true') {
                        $(captcha).parents("form").unbind('submit');
                        $(captcha).parents("form").children(':submit').attr('disabled', 'disabled')
                    }
                });
            }
            else
            {
                $('#captchaMovements').val(JSON.stringify(directions));
                $(captcha).parents("form").unbind('submit');
                $(captcha).parents("form").children(':submit').attr('disabled', null)
            }
        });
    });
    $(captcha).mouseup(function() {
        $("html").unbind("mousemove");
        // Now you can use mouseMovements
    }); 
});

function getPjsInstance() {
    var bound = false;
    pjs = Processing.getInstanceById('myCanvas');
    if(pjs != null)
        bound = true;
    if(!bound)
        setTimeout(getPjsInstance, 250);
    //console.log(pjs.setup());
}

function retrieveCaptcha()
{
    jsCaptcha = true;
    // Request an image to trace
    $.get(url+'captcha/basic', function(data) {
        fillCaptcha(data.Image);
    });
}

function fillCaptcha(data)
{
    captchaId = data.ID;
    $(captcha).css({
        "width": 450, "height": 200,
        "background-image": "url(" + data.ImagePath + ")",
        "background-repeat": "no-repeat",
        "background-position": "left",
        "opacity": 0.6
    });

    $(captcha).trigger('captchaInitiated');
}

// Function to parse directions recorded
function parseDirections(mouseMovements) {
    var directions = [];
    $.each(mouseMovements, function (index, co) {
        if (index > 0) {
            // Get the direction and add it if a new direction
            var direction, angle, primary, secondary;
            if (directions.length > 0) {
                prev = directions[(directions.length - 1)].start;
            }
            else {
                prev = mouseMovements[0];
            }
            var left = prev.left - co.left;
            var top = prev.top - co.top;
            if ((Math.abs(left) + Math.abs(top)) > 0) {
                if (top < 0) {
                    primary = 'S';
                }
                else {
                    primary = 'N';
                }
                if (left < 0) {
                    secondary = 'E';
                }
                else {
                    secondary = 'W';
                }
                if (left == 0) {
                    angle = 90;
                }
                else if (top == 0) {
                    angle = 0;
                }
                else {
                    var angle = Math.atan(Math.abs(top) / Math.abs(left)) * 180 / Math.PI;
                }
                if (angle <= 22.5) {
                    direction = secondary;
                }
                else if (angle > 22.5 && angle <= 67.5) {
                    direction = primary + secondary;
                }
                else {
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
                    if ((mouseMovements.length - 1) == index) {
                        directions.push({'direction': direction, 'length': 1});
                    }
                    else {
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
    var directionsClean = [];
    $.each(directions, function (index, direction) {
        if (direction.length > 5) {
            directionsClean.push(direction);
        }
    });

    return directionsClean;
}
