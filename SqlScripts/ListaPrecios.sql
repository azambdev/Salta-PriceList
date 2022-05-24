use ferreteria;


create Table Categorias
(
Id int AUTO_INCREMENT primary key,
Codigo varchar (5) unique not null,
Descripcion varchar(50) not null unique,
Activo bit default 1
);


Create Table Productos
(
Id int AUTO_INCREMENT primary key,
Codigo varchar(50) unique not null,
IdCategoria int not null,
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
CodigoProducto varchar(50),
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
SELECT * FROM Categorias
insert into Categorias (codigo, descripcion, activo) values ('GE','General',1);
insert into Categorias (codigo, descripcion, activo) values ('HN','Herramientas Neumáticas',1);
insert into Categorias (codigo, descripcion, activo) values ('VA','Válvulas',1);
insert into Categorias (codigo, descripcion, activo) values ('TO','Tornillos',1);
insert into Categorias (codigo, descripcion, activo) values ('HE','Herramientas Eléctricas',1);
insert into Categorias (codigo, descripcion, activo) values ('SI','Seguridad Industrial',1);
insert into Categorias (codigo, descripcion, activo) values ('CO','Conectores',1);
insert into Categorias (codigo, descripcion, activo) values ('PL','Plomería',1);
insert into Categorias (codigo, descripcion, activo) values ('TU','Tubos',1);
insert into Categorias (codigo, descripcion, activo) values ('PI','Pintura',1);
insert into Categorias (codigo, descripcion, activo) values ('SO','Soldadura',1);
insert into Categorias (codigo, descripcion, activo) values ('ME','Materiales eléctricos',1);
insert into Categorias (codigo, descripcion, activo) values ('MA','Mangueras',1);
insert into Categorias (codigo, descripcion, activo) values ('LI','Artículos de limpieza',1);
insert into Categorias (codigo, descripcion, activo) values ('GA','Gas',1);



insert into productos (codigo, IdCategoria, Descripcion, Activo) values ('ME-0000001',12, 'Luces Halógenas',1);
insert into productos (codigo, IdCategoria, Descripcion, Activo) values ('ME-0000002',12, 'Bombillos ahorradores de luz',1);
DELIMITER //
CREATE PROCEDURE `GetCategorias`()
BEGIN

Select id, codigo, descripcion, activo from Categorias;

END

DELIMITER //
CREATE PROCEDURE `GetListasDePrecios`()
BEGIN

Select id, descripcion, activo from listaprecios;

END

DELIMITER //
CREATE PROCEDURE `GetProductos`()
BEGIN
select Id, Codigo, IdCategoria, Descripcion, Activo, Imagen from productos;
END










