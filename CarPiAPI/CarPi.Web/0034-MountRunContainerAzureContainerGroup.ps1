<#
 Author:        jsoto25@hotmail.com
 Date:          11/11/2018
 Project:       CarPi
 Script Type:   Azure CLI
 Description:   Montar y ejecutar el Contenedor en Azure Container
 Dependencias:    
 #>

#$baseImage = "microsoft/aspnetcore:2";
$urlCarpiRegistry = "carpiacr.azurecr.io";
$tagApp =  $urlCarpiRegistry + "/carpi.web";
$containerGroupName = "carpi-api-container-group";
$resourceGroup = "totemapps-carpi";
$cpu = 1;
$ram = 1;
$port = 80;
$dnsLabel = "carpiapicontainder";
$loginACR = "carpiACR";
$acrPassword = "yYYQJe337GWxT=/nCdtk/I8vSOPvqW1=";
$osType = "Windows";
$ipAddress = "Public";

#Crear el contenedor
az container create -g $resourceGroup -n $containerGroupName `
--image $tagApp `
--cpu $cpu --memory $ram `
--registry-username $loginACR `
--registry-password $acrPassword `
--dns-name-label $dnsLabel `
--os-type $osType `
--ports $port `
--ip-address $ipAddress ;








