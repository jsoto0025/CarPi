<#
 Author:        jsoto25@hotmail.com
 Date:          11/11/2018
 Project:       CarPi
 Script Type:   
 Description:   Ejecutar una imagen de Docker
 Dependencias:  0031, 0030
 #>
 <#
Set-Location "D:\FuentesTFS\jsoto25.CarPiAPI\CarPi.Web";
docker run --rm -it -p 8080:80 -v ${PWD}:C:\carpiweb microsoft/aspnetcore:2 dotnet C:\carpiweb\bin\Debug\netcoreapp2.0\publish\CarPi.Web.dll 
#>

#$baseImage = "microsoft/aspnetcore:2";
$urlCarpiRegistry = "carpiacr.azurecr.io";
$tagApp =  $urlCarpiRegistry + "/carpi.web";
docker run --rm -it -p 8080:80 $tagApp;


