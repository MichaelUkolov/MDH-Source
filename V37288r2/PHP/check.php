<?
if(isset($_GET['value']))
{
	$server = ""; // Your MySQL server
	$user = ""; // Your login for MySQL
	$password = ""; // Your password for MySQL
	$database = ""; // Database in the MySQL
	
	$version = $_GET['value'];
	mysql_connect($server, $user, $password);
	mysql_select_db($database);
	$query = mysql_query("SELECT * FROM `mdh` WHERE `setting` = 'ver'");
	$row = mysql_fetch_assoc($query);
	if($row['value'] == $version)
	{
		echo $version;
	}
	
	
}
?>