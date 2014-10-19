<?php
$url = "http://creativecaptcha1-001-site1.smarterasp.net/backend5/CreativeCaptcha.WebApi/";
if (isset($_POST['Movements']))
{
	$data = json_encode(array(
			'DescriptiveSentence' => $_POST['DescriptiveSentence'],
			'ImagePath' => $_POST['ImagePath'],
			'MovementList' => json_decode($_POST['Movements'],1),
		));
	print_R($data);
	$curl = curl_init();
	curl_setopt_array($curl, array(
			CURLOPT_RETURNTRANSFER => 1,
            CURLOPT_URL => $url.'add/basic',
            CURLOPT_POST => 1,
            CURLOPT_POSTFIELDS => $data,
			CURLOPT_CUSTOMREQUEST => "POST",
			CURLOPT_HTTPHEADER => array('Content-Type: application/json', 'Content-Length: ' . strlen($data)),
    ));
$data = curl_exec($curl);
	print_r($data);
}
?>
<html>
<head>
    <title>Upload your Image</title>
    <link rel="stylesheet" href="css/bootstrap.min.css">
</head>
<body>
<div class="row">
    <div class="col-sm-12">
        <!-- Main component for a primary marketing message or call to action -->
        <div class="jumbotron">
            <div class="row">
                <div class="col-md-3">
                    <img src="logo.png">
                </div>
                <div class="col-md-9">
                    <h1>Custom Captchas</h1>
                    <p>Get more out of Creative Captcha's and upload your own branded images for your clients to trace!</p>
                    <p>To include these captcha's in your site just pass your user ID with your captcha image request.</p>
                </div>
            </div>
        </div> <!-- /container -->
        <div class="col-sm-12 col-md-8 col-md-offset-2 panel panel-default">
            <div class="panel-body">
                <form method="post" role="form">
                    <!--<div class="form-group">
                        <label for="userID">User ID</label>
                        <input type="text" class="form-control" id="userID" name="userID">
                    </div>
                    <div class="form-group">
                        <label for="key">API Key</label>
                        <input type="text" class="form-control" id="key" name="key">
                    </div>-->
                    <div class="form-group">
                        <label for="instructions">Instructions</label>
                        <input type="text" class="form-control" id="instructions" name="DescriptiveSentence" placeholder="User instructions">
                    </div>
                    <div class="form-group">
                        <label for="ImagePath">Image URL</label>
                        <input type="text" class="form-control" id="ImagePath" placeholder="URL to image" name="ImagePath">
                    </div>
                    <div class="form-group">
                        <label for="instructions">Movements</label>
                        <input type="text" class="form-control" id="movements" name="Movements" placeholder="User Movements">
                    </div>
                    <!--<div class="form-group">
                        <label for="image">Image</label>
                        <input type="file" id="image" name="image">
                        <p>Images should be 300 by 200 and include indication of starting point and direction.</p>
                    </div>-->
                    <button type="submit" class="btn btn-primary center-block">Add Your Captcha!</button>
                </form>
            </div>
        </div>
    </div>
</div>
<script src="js/jquery-2.1.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</body>
</html>