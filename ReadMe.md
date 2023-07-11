
# Generador de sistema de critica y evaluacion de contenido usando MDA

En esta página se encontrará un generador de aplicaciones web generados a patir de un modelo relacional


        




## Aplicaciones necesarias para el despliegue:

- Visual Studio Comunity 2022
- SQL Server 2022

## Instrucciones para el despliegue: 

### Pasos para importar el modelo relacional que generara la base de datos de la aplicacion::

- Importar el repositorio de github del link: https://github.com/pulidxxx/Modelo-relacional-base-de-datos.git
- Abrir la solucion en visual studio 
- Abrir el archivo modeloBD.edmx
- Fuera de las entiddades dar click derecho 
- Genererar base de datos desde modelo > anterior > Nueva conexion 
- En el nombre del servidor poner el nombre que sale en Microsoft SQL Server Management en la parte superior izquierda en mi caso
"PULIDXXX\SQLEXPRESS"
- Escribir el nombre de la base de datos 
- Dar click en Aceptar > Siguiente
- Si se siguieron los pasos deberia aprecer la base de datos en el management de sql server

### Instrucciones para generar la pagina de Critica de Contenido con modulos opcionales cómo: Comentarios, Categorias, Noticias y Contacto.


- En el explorador de la solución "Sistema De Critica.sln" hacer clic derecho en el fichero "Controllers".
- Ir al apartado de "Agregar".
- En el apartado de "Agregar" hacer clic en "Controlador...".
- Seleccionar "Controlador MVC 5 con vistas, usando Entity Framework", se desplegará una interfaz para añadir el controlador.
- En la sección de "Model Class" o "Clase Modelo" podremos seleccionar cualquiera de los modulos opcionales. Por ejemplo: "Usuario(Sistema_de_critica)".
- En la lista de Clase de Contexto de Datos o DBContext seleccionar "SistemaDeCriticaBDEntities1(Sistema_de_critica)"
- Hacer clic en añadir.
- Cuando se desee ejecutar la aplicación se debe modificar el archivo llamado "_Layout.cshtml" que se encuentra en la carpeta "Views" en el fichero "Shared".
- Se debe añadir el codigo a continuación según se desee visualizar cada modulo.




```bash
                    <li>@Html.ActionLink("Inicio", "Index", "Home", new { area = "" }, new { @class = "nav-link" })</li>
                    <li>@Html.ActionLink("Usuarios", "Index", "Usuarios", new { area = "" }, new { @class = "nav-link" })</li>  Para visualizar la sección de Usuarios
                    <li>@Html.ActionLink("Reseñas", "Index", "Reseña", new { area = "" }, new { @class = "nav-link" })</li>     Para visualizar la sección de Reseña
                    <li>@Html.ActionLink("Categorias", "Index", "Categorias", new { area = "" }, new { @class = "nav-link" })</li>  Para visualizar la sección de Categorias
                    <li>@Html.ActionLink("Noticias", "Index", "Noticias", new { area = "" }, new { @class = "nav-link" })</li>  Para visualizar la sección de Noticias
                    <li>@Html.ActionLink("Comentarios", "Contact", "Home", new { area = "" }, new { @class = "nav-link" })</li>  Para visualizar la sección de Contacto

```


