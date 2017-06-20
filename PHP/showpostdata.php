<?php
	header('content-type:text/html;charset=utf-8');

	echo "<font size='24' face='Arial'>";//PHP放大字體

	$firstname = htmlspecialchars($_POST['firstname']);
	$lastname = $_POST['lastname'];

	$myfile = fopen("newfile.txt", "w") or die("Unable to open file!");
	fwrite($myfile, $lastname);
	fwrite($myfile, $firstname);
	fclose($myfile);
	echo 'OK';
?>