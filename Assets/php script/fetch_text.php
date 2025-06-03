<?php
$host = 'localhost';
$db = 'futurebob';
$user = 'root';
$pass = ''; // XAMPP default is blank

$conn = new mysqli($host, $user, $pass, $db);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT opgaver, svar FROM spørgsmål";
$result = $conn->query($sql);

$opgaver = array();

if ($result->num_rows > 0) {
    while($row = $result->fetch_assoc()) {
        $opgaver[] = $row;
    }
    echo json_encode($opgaver);
} else {
    echo "[]";
}

$conn->close();
?>
