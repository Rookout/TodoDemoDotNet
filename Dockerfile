FROM microsoft/iis@sha256:d8d98880a4628291bcd680661d78f1cb4f75f8bd6d6b0e2709836c2b3314cfd0
SHELL ["powershell"]

RUN Install-WindowsFeature NET-Framework-45-ASPNET ; \
    Install-WindowsFeature Web-Asp-Net45

WORKDIR Todo-Demo-Dotnet
COPY . .

RUN Remove-WebSite -Name 'Default Web Site'
RUN New-Website -Name 'todo-demo-dotnet' -Port 80 \
    -PhysicalPath 'c:\Todo-Demo-Dotnet' -ApplicationPool '.NET v4.5'
EXPOSE 80

CMD Write-Host IIS Started... ;