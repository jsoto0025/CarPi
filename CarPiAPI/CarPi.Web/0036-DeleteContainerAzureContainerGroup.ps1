<#
 Author:        jsoto25@hotmail.com
 Date:          11/11/2018
 Project:       CarPi
 Script Type:   Azure CLI
 Description:   Eliminar el Grupo de Contenedore
 ADVERTENCIA Esto borra el contendor completo
 Dependencias:    
 #>

$containerGroupName = "carpi-api-container-group";
$resourceGroup = "totemapps-carpi";

az container delete --name $containerGroupName `
--resource-group $resourceGroup;