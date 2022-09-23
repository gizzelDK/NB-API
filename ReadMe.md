# NB-API - ASP.NET core REST API til privat ølbrygning

```
git clone https://github.com/gizzelDK/NB-API.git
```
Have a local MSSQL instance
Open Visual Studio 2022 and open Package Manager Console

enter
```
Add-Migration encryptAdminWithExistingSalt
```
```
Update-Database
```

Press play ▶️ (F5) to run in debug mode

You are now able to test the api endpoints in swagger 
or interface with the original [Nano-Bryggere Angular frontend](https://github.com/gizzelDK/NANO-Bryggere)
