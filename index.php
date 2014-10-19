<?php
session_start();
$url = "http://creativecaptcha1-001-site1.smarterasp.net/backend2/CreativeCaptcha.WebApi/";
if (!isset($_POST['movements']))
{
	$curl = curl_init();
	curl_setopt_array($curl, array(
			CURLOPT_RETURNTRANSFER => 1,
			CURLOPT_URL => $url . 'captcha/basic'
		));
	$data = json_decode(curl_exec($curl));
	$_SESSION['captchaID'] = $data->ID;
	$data->ID = 'blah';
}
else {
	$curl = curl_init();
	curl_setopt_array($curl, array(
			CURLOPT_RETURNTRANSFER => 1,
			CURLOPT_URL => $url.'validate/basic',
			CURLOPT_POST => 1,
			CURLOPT_POSTFIELDS => array(
				'ID' => $_SESSION['captchaID'],
				'Movements' => $_POST['movements'],
			)
		));
	$data = curl_exec($curl);
	print_r($data);
	//unset($_SESSION['captchaID']);
	die();
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
		<div class="col-sm-12 col-md-8 col-md-offset-2 panel panel-default">
			<div class="panel-body">
				<form method="post">
					<label for="email">Email:</label>
					<input type="text" name="email" placeholder="email" class="form-control" /><br>
					<label for="status">Are you: </label>
					<select name="status" class="form-control">
						<option></option>
						<option value="great">Great</option>
						<option value="awesome">Awesome</option>
					</select>
					<br>
					<div id='myCaptcha'>
						<canvas data-processing-sources="mixing.pde" id="myCanvas" style="opacity:0.6;">
						</canvas>
						<div id="msg"></div>
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
