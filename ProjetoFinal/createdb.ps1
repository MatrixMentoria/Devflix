#createdb.ps1
#Creates a new database using our specifications
[System.Reflection.Assembly]::LoadWithPartialName('Microsoft.SqlServer.SMO')  | out-null

$s = new-object ('Microsoft.SqlServer.Management.Smo.Server') '.\SQLEXPRESS'

$dbname = 'ProjetoFinal'
$loginName = 'usuario_banco'
$passwd = '123456_'
$dbold = $s.Databases[$dbname]

if($dbold){
    $s.KillAllProcesses($dbname)
    $dbold.Drop()
}


$db = new-object ('Microsoft.SqlServer.Management.Smo.Database') ($s, $dbname)
$sysfg = new-object ('Microsoft.SqlServer.Management.Smo.FileGroup') ($db, 'PRIMARY')
$db.FileGroups.Add($sysfg)
#$appfg = new-object ('Microsoft.SqlServer.Management.Smo.FileGroup') ($db, 'AppFG')
#$db.FileGroups.Add($appfg)

# Create the file for the system tables
$syslogname = $dbname + '_SysData'
$dbdsysfile = new-object ('Microsoft.SqlServer.Management.Smo.DataFile') ($sysfg, $syslogname)
$sysfg.Files.Add($dbdsysfile)
$dbdsysfile.FileName = $s.Information.MasterDBPath + '\' + $syslogname + '.mdf'
$dbdsysfile.Size = [double](5.0 * 1024.0)
$dbdsysfile.GrowthType = 'None'
$dbdsysfile.IsPrimaryFile = 'True'

# Create the file for the Application tables
#$applogname = $dbname + '_AppData'
#$dbdappfile = new-object ('Microsoft.SqlServer.Management.Smo.DataFile') ($appfg, $applogname)
#$appfg.Files.Add($dbdappfile)
#$dbdappfile.FileName = $s.Information.MasterDBPath + '\' + $applogname + '.ndf'
#$dbdappfile.Size = [double](25.0 * 1024.0)
#$dbdappfile.GrowthType = 'Percent'
#$dbdappfile.Growth = 25.0
#$dbdappfile.MaxSize = [double](100.0 * 1024.0)

# Create the file for the log
$loglogname = $dbname + '_Log'
$dblfile = new-object ('Microsoft.SqlServer.Management.Smo.LogFile') ($db, $loglogname)
$db.LogFiles.Add($dblfile)
$dblfile.FileName = $s.Information.MasterDBLogPath + '\' + $loglogname + '.ldf'
$dblfile.Size = [double](10.0 * 1024.0)
$dblfile.GrowthType = 'Percent'
$dblfile.Growth = 25.0



$SqlUserLogin = $s.Logins[$loginName]

$SqlUser = $null

if(!$SqlUserLogin) {
    $SqlUser = New-Object -TypeName Microsoft.SqlServer.Management.Smo.User -ArgumentList $db, $loginName
    $SqlUser.Login = $loginName
    $SqlUser.Name = $loginName        
    $SqlUser.Create()
}else{
    $SqlUser = New-Object -TypeName Microsoft.SqlServer.Management.Smo.User -ArgumentList $db, $loginName    
    $SqlUser.Login = $loginName
}

#$SqlUser.ChangePassword($passwd)

$role = $s.Roles["sysadmin"]

$role.AddMember($SqlUser.Login)

# Create the database
$db.Create()

$db.Users.Add($SqlUser)
