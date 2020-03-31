# ServicioFinanciero

Migraciones:
- Ubicarse en la carpeta Infrastructure
``
    dotnet ef migrations add Initial --context=BancoContext -s ../WebApi/
    dotnet ef database update --context=BancoContext -s ../WebApi/ 
``