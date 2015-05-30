<?
if(isset($_GET['new']))
{
	$server = ""; // Your MySQL server
	$user = ""; // Your login for MySQL
	$password = ""; // Your password for MySQL
	$database = ""; // Database in the MySQL
	
	mysql_connect($server, $user, $password);
	mysql_select_db($database);
	$query = mysql_query("SELECT * FROM `mdh` WHERE `setting` = 'launch'");
	$row = mysql_fetch_assoc($query);
	$new_launch = $row['value'] + 1;
	$query_update = mysql_query("UPDATE `mdh` SET `value` = '".$new_launch."' WHERE `id` = 2") or die(mysql_error());
}
?>