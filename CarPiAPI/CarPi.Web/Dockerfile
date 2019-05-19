#Autor:	jsoto25@hotmail.com
#Fecha:	12/11/2018

FROM microsoft/aspnetcore:2

WORKDIR /carpiweb
COPY bin/Debug/netcoreapp2.0/publish .

ENTRYPOINT ["dotnet", "/carpiweb/carpi.web.dll"]
