<?php
session_start();
$url = "http://creativecaptcha1-001-site1.smarterasp.net/backend7/CreativeCaptcha.WebApi/";
if (isset($_POST['movements']))
{
	$json = json_encode(array(
		'ID' => $_SESSION['captchaID'],
		'Movements' => json_decode($_POST['movements']),
	));
	$curl = curl_init();
	curl_setopt_array($curl, array(
			CURLOPT_RETURNTRANSFER => 1,
			CURLOPT_URL => $url.'validate/basic',
			CURLOPT_POSTFIELDS => $json,
			CURLOPT_POST => 1,
			CURLOPT_CUSTOMREQUEST => "POST",
			CURLOPT_HTTPHEADER => array('Content-Type: application/json', 'Content-Length: ' . strlen($json)),
		));
	$result = json_decode(curl_exec($curl));
	//unset($_SESSION['captchaID']);
}
$curl = curl_init();
curl_setopt_array($curl, array(
		CURLOPT_RETURNTRANSFER => 1,
		CURLOPT_URL => $url . 'captcha/basic'
	));
$data = json_decode(curl_exec($curl));
if (isset($data->ID)) {
	$_SESSION['captchaID'] = $data->ID;
	$data->ID = 'blah';
}
?>

<html>
<head>
    <title>Creative Captcha</title>
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
				</div>
			</div>
		</div> <!-- /container -->
		<div class="col-sm-12 col-md-8 col-md-offset-2 panel panel-default">
			<div class="panel-body">
				<?php if (isset($result->IsHuman) && $result->IsHuman)
				{
					echo '<div class="alert alert-success" role="alert"><b>Awesome</b>, your human!</div>';
				}
				elseif (isset($result->IsHuman))
				{
					echo '<div class="alert alert-danger" role="alert">Bots aren\'t welcome round here buddy.</div>';
				}
				?>
				<form method="post">
					<label for="email">Email:</label>
					<input type="text" name="email" placeholder="email" class="form-control" /><br>
					<label for="status">Are you: </label>
					<select name="status" class="form-control">
						<option value="awesome">Awesome</option>
						<option value="great">Great</option>
					</select>
					<br>
					<div id='myCaptcha' class="panel panel-default" >
						<canvas data-processing-sources="mixing.pde" id="myCanvas" style="opacity:0.6;display:inline-block;">
						</canvas>
						<div id="msg" style="display:inline-block;"></div>
					</div><br>
					<input type="hidden" name="movements" id="captchaMovements">
					<input type="submit" value="Submit" class="btn btn-primary center-block"/>
				</form>
			</div>
		</div>
	</div>
</div>
<script src="js/jquery-2.1.1.min.js"></script>
<script src="js/processing-1.4.8.min.js"></script>
<script>var captcha = '#myCaptcha';</script>
<script src='js/creativeCaptcha.js'></script>
<script>$(document).ready(function() { fillCaptcha(<?php echo json_encode($data); ?>); });</script>
</body>
</html>
