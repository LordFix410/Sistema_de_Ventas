# Sistema_de_Ventas

#Requisitos minimos
-Visual Studio 2022
-SQL Server 2019
-.NET Freamework

#Instalación
1. Clonar el repositorio

2. Ejecutar las consultas para crear la base de datos mediante el archivo  
   "querys.sql".

3. Abrir el proyecto en Visual Studio.

4. Configurar la cadena de conexion en Visual Studio en el archivo "Properties" 
que se encuentra en la CapaPresentación, en el apartado de configuración, en la columna valor,
en los tres puntos, se abrira las propiedades de conexion, se coloca el nombre del servidor
de su equipo (cuando se crea una nueva conexion en sql, especifica el servidor en el cual
esta trabajando, por ejemplo: "(localdb)\MSSQLLocalDB"), o probando poner un ".", 
ya luego se selecciona el nombre de la base de datos.

5. se prueba conexion, y en avanzado se copia la cadena, y se corrobora que sea la misma que 
aparezca en App.config, en la seccion de connectionString, que sea igual la cadena de conexion,
y que no hayan dos cadenas de conexion al mismo tiempo, la que debe de funcionar es la que
se llama "cadena_conexion" y tiene la misma direccion en connectionString al que vimos en 
la configuracion de CapaPresentación.

6. Las credenciales son: 
	Numero Documento:admin
	contraseña:admin
//para colaborador:
	Numero documento:usuario
	contraseña:usuario