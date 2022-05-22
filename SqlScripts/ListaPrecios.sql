use ferreteria;
Create Table Categorias
(
Id int AUTO_INCREMENT primary key,
Descripcion varchar(50) not null unique,
Activo bit default 1
);


Create Table Productos
(
Id int AUTO_INCREMENT primary key,
Codigo int unique not null,
IdCotegoria int not null,
Descripcion varchar(50) not null,
Activo bit default 1,
Imagen longblob,
FOREIGN KEY (IdCotegoria) REFERENCES Categorias(Id)
);

Create Table ListaPrecios
(
Id int AUTO_INCREMENT primary key,
Descripcion varchar(50) not null,
Activo bit default 1
);

Create Table ListaPreciosProductos
(
Id int AUTO_INCREMENT primary key,
IdListaPrecio int,
CodigoProducto int,
FOREIGN KEY (IdListaPrecio) REFERENCES ListaPrecios(Id),
FOREIGN KEY (CodigoProducto) REFERENCES Productos(Codigo),
PrecioCosto decimal not null default 0,
AlicuotaIva decimal not null default 21,
PrecioVentaFinal decimal not null default 0,
FechaActualizacion Datetime not null
);

Create Table Negocio
(
Id int AUTO_INCREMENT primary key,
Nombre Varchar(50) not null,
Cuit Varchar(20)
);

Create Table Usuarios
(
Id int AUTO_INCREMENT primary key,
Nombre varchar(50) not null,
Login varchar(50) not null,
Clave varchar(255) not null,
Activo bit default 1
);

Create Table HistoricoListaPreciosProductos
(
Id int not null AUTO_INCREMENT primary key,
IdListaPrecio int,
CodigoProducto int,
PrecioCosto decimal,
AlicuotaIva decimal,
PrecioVentaFinal decimal,
FechaActualizacion Datetime not null
);

insert into Categorias (descripcion, activo) values ('General',1);
insert into Categorias (descripcion, activo) values ('Sanitarios',1);
insert into Categorias (descripcion, activo) values ('Válvulas',1);
insert into Categorias (descripcion, activo) values ('Tornillos',1);
insert into Categorias (descripcion, activo) values ('Herramientas',1);
insert into Categorias (descripcion, activo) values ('Seguridad Industrial',1);
insert into Categorias (descripcion, activo) values ('Conectores',1);
insert into Categorias (descripcion, activo) values ('Plomería',1);
insert into Categorias (descripcion, activo) values ('Tubos',1);
insert into Categorias (descripcion, activo) values ('Pintura',1);
insert into Categorias (descripcion, activo) values ('Soldadura',1);
insert into Categorias (descripcion, activo) values ('Materiales eléctricos',1);
insert into Categorias (descripcion, activo) values ('Mangueras',1);
insert into Categorias (descripcion, activo) values ('Artículos de limpieza',1);
insert into Categorias (descripcion, activo) values ('Gas',1);

DELIMITER //
CREATE PROCEDURE `GetCategorias`()
BEGIN

Select id, descripcion, activo from Categorias;

END













