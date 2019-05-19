<#
 Author:        jsoto25@hotmail.com
 Date:          11/11/2018
 Project:       CarPi
 Script Type:   
 Description:   Push el contenedor al Docker Registry
 Dependencias:  0031
 #>

 $urlCarpiRegistry = "carpiacr.azurecr.io";
 $tagApp =  $urlCarpiRegistry + "/carpi.web";
 $tagApp;

 # Logearse en el docker regisry
 docker login $urlCarpiRegistry;
 # Build el contenedor basado en el Dockerfile
 docker build -t $tagApp;
 # Push al contenedor en el registry
 docker push $tagApp;