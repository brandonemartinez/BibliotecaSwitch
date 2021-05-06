Biblioteca Switch Software Solutions
Datos generales para todos los ejercicios
El servicio de biblioteca es un servicio bastante simple dónde se quiere modelar una biblioteca, la cual a grandes rasgos dará préstamos de libros a estudiantes. Inicialmente se cuenta con un usuario administrador el cual mediante el cual se podrá dar de alta a estudiantes y libros.
Las entidades del sistema por lo pronto serán Estudiantes, Libros, Autores y Usuarios. A continuación, se detallan los datos para cada uno de los objetos:
Entidad
Datos
Autor
Nombre y Fecha de Nacimiento (opcional)
Libro
ISBN, Titulo, Año de Publicación (opcional), Autor
Estudiante
Número de estudiante, Nombre y Fecha de Nacimiento (opcional)
Usuario
Nombre de usuario y Password

 
Ejercicio MER
Los estudiantes podrán solicitar préstamos sobre los libros y los préstamos tienen fecha de inicio y fin, el estudiante puede sacar más de una vez el mismo libro, pero no en el mismo día, además no se debe contabilizar el stock de cada libro.
Hacer un MER en tercera forma normal que resuelva el problema, detallar además en el pasaje a tablas otros atributos relevantes tales como claves primarias, tipo de dato o si una columna es única.

Ejercicio REST
Tomando como referencia que el sistema va a ser utilizado por dos tipos de usuarios, estudiantes y administradores se deben diseñar las siguientes funcionalidades:
Administradores
CRUD de Autores, Libros y Estudiantes.
Ver los préstamos actuales de libros.
Dado un estudiante poder ver qué libros (con todos los datos de los mismos) tienen su poder actualmente
Estudiantes
Listado de Libros
Ver los libros que tiene en su poder, llevarse y devolver un libro
Codificación de API REST
Desarrollar una parte de la API del ejercicio anterior tomando en cuenta sólo alguna de las funcionalidades del Administrador. Se deberá resolver el CRUD de Autores y Libros permitiendo asociar un autor a muchos libros. En este caso cambiaremos un poco las entidades con las que trabajaremos.

Entidad
Datos
Autor
Documento (numérico, único), Nombre (texto no mayor a 100 caracteres) y Fecha de Nacimiento (opcional)
Libro
ISBN (texto no mayor a 50 caracteres, único), Título (texto no mayor a 100 caracteres), Año de Publicación (opcional), Autor


No se deben tener en cuenta parámetros de seguridad en esta primera instancia pero el ejercicio apunta a que se realice una API siguiendo los principios SOLID, KISS, DRY y YAGNI y se apunten a buenas prácticas de diseño de APIs REST.
Tecnologías
El stack de tecnologías para realizar la solución es el siguiente:
Stack
Tecnologías
.NET
Lenguaje: C# .NET Core 3.1
IDE: Visual Studio 2019
Base de datos: SQL Server
ORM: Entity Framework Core
Testing: Nunit o Xunit para correr test, Moq, Fake it easy o NSubstitute para hacer mocking
Opcionales: Se recomienda utilizar automapper para facilitar mappeos
JAVA
Lenguaje: Java 11 con Spring con Spring Boot
IDE: Intelli J 2020
Base de datos: MySQL Server
ORM: JPA
Testing: Spring Boot Test y Mockito para hacer mocking.
Opciones: Se recomienda utilizar Lombok para evitar código de getters, setters, constructores en modelos y MapStruct para facilitar mappeos.
Node.Js
Lenguaje: Node js 14 con Express
IDE: Indistinto
Base de datos: MySQL Server
ORM:  Sequelize
Testing: Jest
Opcionales: sequelize-auto para crear los modelos de Sequellize

Repetimos, se valorará mucho el correcto uso de principios SOLID y similares, para eso recomendamos al menos tener las responsabilidades bien separadas dentro de distintos proyectos teniendo en cuenta la separación de interfaces e implementación, se recomienda como mínimo que exista una capa de API, otra de servicios y otra de repositorios.
