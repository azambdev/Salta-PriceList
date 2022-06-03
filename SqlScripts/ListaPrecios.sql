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
Porcentaje int default 0, 
Activo bit default 1
);
select * from ListaPreciosProductos;
Create Table ListaPreciosProductos
(
Id int AUTO_INCREMENT primary key,
IdListaPrecio int,
CodigoProducto varchar(50),
FOREIGN KEY (IdListaPrecio) REFERENCES ListaPrecios(Id),
FOREIGN KEY (CodigoProducto) REFERENCES Productos(Codigo),
PrecioCosto decimal not null default 0,
Porcentaje int default 0, 
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
CodigoProducto varchar(50),
PrecioCosto decimal,
AlicuotaIva decimal,
PrecioVentaFinal decimal,
FechaActualizacion Datetime not null
);
SELECT * FROM Productos;
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
CREATE PROCEDURE `GetListaPrecios`()
BEGIN
Select id, descripcion, porcentaje,  activo from listaprecios;
END

DELIMITER //
CREATE PROCEDURE `GetProductos`()
BEGIN
select Id, Codigo, IdCategoria, Descripcion, Activo, Imagen from productos;
END

DELIMITER //
CREATE PROCEDURE `CreateProducto`(IN Codigo varchar(50), IN IdCategoria int, IN Descripcion varchar(100), IN Activo bit, IN Imagen LongBlob )
BEGIN

insert into Productos (Codigo, IdCategoria, Descripcion,Activo, Imagen) values (Codigo,IdCategoria,Descripcion,Activo, Imagen );

insert into listapreciosProductos (idListaPrecio, CodigoProducto, precioCosto, Porcentaje, AlicuotaIva, precioVentaFinal, FechaActualizacion) 
select distinct lp.id as IdListaPrecio, Codigo, 0, lp.Porcentaje, 21,0,now()
from productos p, listaprecios lp, listapreciosproductos lpp
where p.codigo = lpp.codigoproducto
or lpp.codigoproducto is null
and lpp.idListaprecio = lp.id
and p.codigo = Codigo;
END

DELIMITER //
CREATE PROCEDURE `UpdateProducto`(IN inCodigo varchar(50), IN inIdCategoria int, IN inDescripcion varchar(100), IN inActivo bit, IN inImagen LongBlob )
BEGIN

update productos
set Descripcion = inDescripcion, 
Activo = inActivo,
Imagen = inImagen
where codigo = inCodigo;

END

DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateListaDePrecios`(in inDescripcion varchar(50), IN inPorcentaje int)
BEGIN
DECLARE idListaInsertado int;
	
insert into listaprecios (Descripcion, Porcentaje, Activo) values (inDescripcion, inPorcentaje, 1);
SET idListaInsertado:= LAST_INSERT_ID();
    

insert into listapreciosProductos (idListaPrecio, CodigoProducto, precioCosto, Porcentaje, AlicuotaIva, precioVentaFinal, FechaActualizacion) 
select idListaInsertado, codigo, 0, inPorcentaje, 21,0,now()
from productos;

END
DELIMITER //

CREATE PROCEDURE `GetListaPreciosProductos`()
BEGIN

select lp.id as IdListaPrecio, lp.Descripcion as ListaPrecioDescripcion, lp.Porcentaje as PorcentajeListaPrecios, lpp.id as IdListaPreciosProductos, lpp.idlistaprecio as lppIdListaPrecio, lpp.CodigoProducto,prod.Id as IdProducto, prod.Descripcion as DescripcionProducto, lpp.precioCosto,
 lpp.porcentaje, lpp.AlicuotaIva, lpp.PrecioVentaFinal, lpp.FechaActualizacion, Cat.Id as IdCategoria, Cat.Codigo as CodigoCategoria, Cat.Descripcion DescripcionCategoria
from listapreciosproductos lpp, productos prod, categorias cat, listaprecios lp
where lpp.CodigoProducto = prod.Codigo
And prod.IdCategoria = cat.Id
AND lp.id = lpp.IdListaPrecio
and prod.activo=1
order by lpp.CodigoProducto asc;

END

DELIMITER //
CREATE PROCEDURE `UpdateListaPreciosProductos`(in inIdListaPrecio int, in inCodigoProducto varchar(50), in inPrecioCosto decimal, in inPorcentaje int, in inAlicuotaIva decimal, in inPrecioVentaFinal decimal )
BEGIN

insert into HistoricoListaPreciosProductos (IdListaPrecio, CodigoProducto, PrecioCosto, AlicuotaIva,PrecioVentaFinal,FechaActualizacion) 
select IdListaPrecio, CodigoProducto, PrecioCosto, AlicuotaIva,PrecioVentaFinal,FechaActualizacion
from listaPreciosProductos
where IdListaPrecio = inIdListaPrecio
and CodigoProducto = inCodigoProducto;

update listaPreciosProductos
set PrecioCosto = inPrecioCosto,
Porcentaje = inPorcentaje, 
PrecioCosto = inPrecioCosto, 
AlicuotaIva = inAlicuotaIva,
PrecioVentaFinal = inPrecioVentaFinal,
FechaActualizacion = now()
where IdListaPrecio = inIdListaPrecio
and CodigoProducto = inCodigoProducto;

END
DELIMITER //

