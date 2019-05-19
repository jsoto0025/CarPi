<#
 Author:        jsoto25@hotmail.com
 Date:          11/11/2018
 Project:       CarPi
 Script Type:   Azure CLI
 Description:   Ver la url del contenedor
 Dependencias:    
 #>

$containerGroupName = "carpi-api-container-group";
$resourceGroup = "totemapps-carpi";

az container show -g $resourceGroup -n $containerGroupName `
--query ipAddress.fqdn -o tsv








