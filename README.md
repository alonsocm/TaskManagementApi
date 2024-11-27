# TaskManagementApi

<p>Para ejecutar el proyecto, después de clonar el repositorio:<p>  
<p>1. Dentro de la carpeta raíz del proyecto, ingresar el siguiente comando para restaurar los paquetes:<p> 
  <b>dotnet restore</b> 
<p>2. Aplicar las migraciones con el siguiente comando:<p>
  <b>dotnet ef database update -s src/TaskManagementApi.API</b> 
<p>3. Ingresar a la carpeta del proyecto API:<p>
  <b>cd .\src\TaskManagementApi.API\</b>
<p>4. Ejecutar el proyecto con el siguiente comando:</p> 
  <b>dotnet run</b>
<p>5. Mediante Swagger, se pueden visualizar los endpoints existentes:</p>
  <b>Ejemplo: https://localhost:7240/swagger/index.html</b>
