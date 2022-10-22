
/* TIPOS DE USUARIO */

Create table tipoUsuario(
id_tipoUsuario int Not Null Primary key IDENTITY(1, 1),
nombreTipoUsuario varchar(20),
funciones varchar (200))



create proc Select_tipoUsuario(
@idtipousuario int)
as
begin
	Select
	id_tipoUsuario, nombreTipoUsuario, funciones
	from tipoUsuario where id_tipoUsuario = @idtipousuario
end


create proc SelectAll_tipoUsuario
as
begin
	Select
	id_tipoUsuario, nombreTipoUsuario, funciones
	from tipoUsuario
end


create proc Save_tipoUsuario(
@nombretipousuario varchar(20),
@funciones varchar(200))
as
begin
	insert into tipoUsuario(nombreTipoUsuario,funciones) values (@nombretipousuario, @funciones)
end

create proc Edit_TipoUsuario(
@idtipousuario int,
@nombretipousuario varchar(20) null,
@funciones varchar(200) null)
as
begin
	update tipoUsuario set
	nombreTipoUsuario = isnull(@nombretipousuario, nombreTipoUsuario),
	funciones = isnull(@funciones, funciones)
	where id_tipoUsuario = @idtipousuario

end

create proc Delete_TipoUsuario(
@idtipousuario int)
as
begin
	delete from TipoUsuario where id_tipoUsuario = @idtipousuario
end



/* SUCURSAL */

Create table sucursal(
id_sucursal int Not Null Primary key IDENTITY(1, 1),
nombreSucursal varchar(20))


create proc Select_sucursal(
@idsucursal int)
as
begin
	Select
	id_sucursal, nombreSucursal
	from sucursal where id_sucursal = @idsucursal
end


create proc SelectAll_sucursal
as
begin
	Select
	id_sucursal, nombreSucursal
	from sucursal
end


create proc Save_sucursal(
@nombresucursal varchar(20))
as
begin
	insert into sucursal(nombresucursal) values (@nombresucursal)
end

create proc Edit_sucursal(
@idsucursal int,
@nombresucursal varchar(20) null)
as
begin
	update sucursal set
	nombresucursal = isnull(@nombresucursal, nombresucursal)
	where id_sucursal = @idsucursal

end

create proc Delete_sucursal(
@idsucursal int)
as
begin
	delete from sucursal where id_sucursal = @idsucursal
end


/* TIPOS DE PAGO */


Create table tipoPago(
id_tipoPago int Not Null Primary key IDENTITY(1, 1),
nombreTipoPago varchar(20))


create proc Select_tipoPago(
@idtipopago int)
as
begin
	Select
	id_tipopago, nombreTipoPago
	from tipoPago where id_tipopago = @idtipopago
end


create proc SelectAll_tipopago
as
begin
	Select
	id_tipopago, nombretipopago
	from tipopago
end


create proc Save_tipopago(
@nombretipopago varchar(20))
as
begin
	insert into tipopago(nombretipopago) values (@nombretipopago)
end

create proc Edit_tipopago(
@idtipopago int,
@nombretipopago varchar(20) null)
as
begin
	update tipopago set
	nombretipopago = isnull(@nombretipopago, nombretipopago)
	where id_tipopago = @idtipopago

end

create proc Delete_tipopago(
@idtipopago int)
as
begin
	delete from tipopago where id_tipopago = @idtipopago
end



/* Bodegas */

Create table Bodega(
id_Bodega int Not Null Primary key IDENTITY(1, 1),
nombreBodega varchar(30),
id_Sucursal int,
Foreign Key(id_Sucursal) REFERENCES sucursal(id_Sucursal) )


create proc Select_Bodega(
@idbodega int)
as
begin
	Select
	id_bodega, nombrebodega, id_sucursal
	from bodega where id_bodega = @idbodega
end


create proc SelectAll_bodega
as
begin
	Select
	id_bodega, nombrebodega, id_sucursal
	from bodega
end


create proc Save_bodega(
@nombrebodega varchar(30),
@idsucursal int)
as
begin
	insert into bodega(nombrebodega, id_sucursal) values (@nombrebodega, @idsucursal)
end



create proc Edit_bodega(
@idbodega int,
@nombrebodega varchar(30) null,
@idsucursal int null)
as
begin
	update bodega set
	nombrebodega = isnull(@nombrebodega, nombrebodega),
	id_sucursal = isnull(@idsucursal, id_sucursal)
	where id_bodega = @idbodega

end


create proc Delete_Bodega(
@idBodega int)
as
begin
	delete from Bodega where id_Bodega = @idBodega
end


/* Transportes */

Create table Transporte(
id_Transporte int Not Null Primary key IDENTITY(1, 1),
nombreTransporte varchar(30),
id_Sucursal int,
Foreign Key(id_Sucursal) REFERENCES sucursal(id_Sucursal) )


create proc Select_Transporte(
@idTransporte int)
as
begin
	Select
	id_Transporte, nombreTransporte, id_sucursal
	from Transporte where id_Transporte = @idTransporte
end


create proc SelectAll_Transporte
as
begin
	Select
	id_Transporte, nombreTransporte, id_sucursal
	from Transporte
end




create proc Save_Transporte(
@nombreTransporte varchar(30),
@idsucursal int)
as
begin
	insert into Transporte(nombreTransporte, id_sucursal) values (@nombreTransporte, @idsucursal)
end



create proc Edit_Transporte(
@idTransporte int,
@nombreTransporte varchar(30) null,
@idsucursal int null)
as
begin
	update Transporte set
	nombreTransporte = isnull(@nombreTransporte, nombreTransporte),
	id_sucursal = isnull(@idsucursal, id_sucursal)
	where id_Transporte = @idTransporte

end


create proc Delete_Transporte(
@idTransporte int)
as
begin
	delete from Transporte where id_Transporte = @idTransporte
end

/* Cliente, la idea es dividir por tipo cliente que tendra costos de tarifa que podría considerarse otra división */

/* TIPOS DE Cliente */


Create table tipoCliente(
id_tipoCliente int Not Null Primary key IDENTITY(1, 1),
nombreTipoCliente varchar(20),
cantidadMaxPaquetes int)


create proc Select_tipoCliente(
@idtipocliente int)
as
begin
	Select
	id_tipocliente, nombreTipoCliente, cantidadMaxPaquetes
	from tipoCliente where id_tipocliente = @idtipocliente
end


create proc SelectAll_tipocliente
as
begin
	Select
	id_tipocliente, nombreTipoCliente, cantidadMaxPaquetes
	from tipoCliente
end


create proc Save_tipocliente(
@nombretipocliente varchar(20),
@cantidadmaxpaquetes int)
as
begin
	insert into tipocliente(nombretipocliente,cantidadMaxPaquetes) values (@nombretipocliente, @cantidadmaxpaquetes)
end

create proc Edit_tipocliente(
@idtipocliente int,
@nombretipocliente varchar(20) null,
@cantidadmaxpaquetes int null)
as
begin
	update tipocliente set
	nombretipocliente = isnull(@nombretipocliente, nombretipocliente),
	cantidadmaxpaquetes = isnull(@cantidadmaxpaquetes, cantidadMaxPaquetes)
	where id_tipocliente = @idtipocliente

end

create proc Delete_tipocliente(
@idtipocliente int)
as
begin
	delete from tipocliente where id_tipocliente = @idtipocliente
end


/* Tarifas por Tipo de CLiente */


Create table Tarifa(
id_Tarifa int Not Null Primary key IDENTITY(1, 1),
id_TipoCliente int,
Foreign Key(id_TipoCliente) REFERENCES TipoCliente(id_TipoCliente),
id_Transporte int,
Foreign Key(id_Transporte) REFERENCES Transporte(id_Transporte),
nombreTarifa varchar(20),
costoCiudad float,
costoMunicipio float,
costoInteriorPais float)


create proc Select_Tarifa(
@idtarifa int)
as
begin
	Select
	id_tarifa, id_TipoCliente, id_Transporte, nombreTarifa, costoCiudad, costoMunicipio, costoInteriorPais
	from Tarifa where id_tarifa = @idtarifa
end


create proc SelectAll_Tarifa
as
begin
	Select
	id_tarifa, id_TipoCliente, id_Transporte, nombreTarifa, costoCiudad, costoMunicipio, costoInteriorPais
	from Tarifa
end


create proc Save_Tarifa(
@idtipocliente int,
@idtransporte int,
@nombretarifa varchar(20),
@costociudad float,
@costoMunicipio float,
@costointeriorpais float)
as
begin
	insert into Tarifa(id_TipoCliente, id_Transporte, nombreTarifa, costoCiudad, costoMunicipio, costoInteriorPais) 
	values (@idtipocliente, @idtransporte, @nombretarifa, @costociudad, @costoMunicipio, @costointeriorpais)
end


create proc Edit_tarifa(
@idtarifa int,
@idtipocliente int null,
@idtransporte int null,
@nombretarifa varchar(20) null,
@costociudad float null,
@costoMunicipio float null,
@costointeriorpais float null)
as
begin
	update tarifa set
	id_tipocliente = isnull(@idtipocliente, id_tipocliente),
	id_transporte = isnull(@idtransporte, id_transporte),
	nombreTarifa = isnull(@nombretarifa, NombreTarifa),
	costoCiudad = isnull(@costociudad, costoCiudad),
	costoMunicipio = isnull(@costoMunicipio, costoMunicipio),
	costointeriorpais = isnull(@costointeriorpais, costoInteriorPais)
	where id_tarifa = @idtarifa

end

exec Edit_tarifa 1,1, 1, 'Tarifa moto', 22, 28, 31
/* Si funciona*/ 

create proc Delete_Tarifa(
@idtarifa int)
as
begin
	delete from Tarifa where id_Tarifa = @idtarifa
end

/* Cliente*/

Create table Cliente(
id_Cliente int Not Null Primary key IDENTITY(1, 1),
id_TipoCliente int,
Foreign Key(id_TipoCliente) REFERENCES TipoCliente(id_TipoCliente),
nombreCliente varchar(20),
apellidoCliente varchar(20))

create proc Select_Cliente(
@idcliente int)
as
begin
	Select
	id_Cliente, id_TipoCliente, nombreCliente, apellidoCliente
	from Cliente where id_cliente = @idcliente
end


create proc SelectAll_Cliente
as
begin
	Select
	id_Cliente, id_TipoCliente, nombreCliente, apellidoCliente
	from Cliente
end


create proc Save_Cliente(
@idtipocliente int,
@nombrecliente varchar(20),
@apellidocliente varchar(20))
as
begin
	insert into Cliente(id_TipoCliente, nombreCliente, apellidoCliente) 
	values (@idtipocliente, @nombrecliente, @apellidocliente)
end




create proc Edit_Cliente(
@idcliente int,
@idtipocliente int null,
@nombrecliente varchar(20) null,
@apellidocliente varchar(20) null)
as
begin
	update cliente set
	id_tipocliente = isnull(@idtipocliente, id_tipocliente),
	nombrecliente = isnull(@nombrecliente, NombreCliente),
	apellidoCliente = isnull(@apellidocliente, ApellidoCliente)
	where id_cliente = @idcliente

end

create proc Delete_Cliente(
@idcliente int)
as
begin
	delete from Cliente where id_Cliente = @idcliente
end


/* Estatus paquete */

Create table statusPaquete(
id_statusPaquete int Not Null Primary key IDENTITY(1, 1),
nombreStatusPaquete varchar(30))


create proc Select_StatusPaquete(
@idstatuspaquete int)
as
begin
	Select
	id_StatusPaquete, nombreStatusPaquete
	from statusPaquete where id_statusPaquete = @idstatuspaquete
end


create proc SelectAll_StatusPaquete
as
begin
	Select
	id_StatusPaquete, nombreStatusPaquete
	from StatusPaquete
end


create proc Save_StatusPaquete(
@nombreStatusPaquete varchar(30))
as
begin
	insert into StatusPaquete(nombreStatusPaquete) values (@nombreStatusPaquete)
end



create proc Edit_StatusPaquete(
@idStatusPaquete int,
@nombreStatusPaquete varchar(30) null)
as
begin
	update StatusPaquete set
	nombreStatusPaquete = isnull(@nombreStatusPaquete, nombreStatusPaquete)
	where id_StatusPaquete = @idStatusPaquete

end


create proc Delete_StatusPaquete(
@idStatusPaquete int)
as
begin
	delete from StatusPaquete where id_StatusPaquete = @idStatusPaquete
end

/* Informe de paquete*/


drop table informepaquete

Create table informePaquete(
id_informePaquete int Not Null Primary key IDENTITY(1, 1),
codigoPaquete varchar(20),
id_Cliente int,
Foreign Key(id_Cliente) REFERENCES Cliente(id_Cliente),
id_Transporte int,
Foreign Key(id_Transporte) REFERENCES Transporte(id_Transporte),
fechaEnvio date,
fechaRecibo date,
id_sucursalOrigen int,
Foreign Key(id_sucursalOrigen) REFERENCES Sucursal(id_sucursal),
id_sucursalDestino int,
Foreign Key(id_sucursalDestino) REFERENCES Sucursal(id_sucursal),
id_StatusPaquete int,
Foreign Key(id_StatusPaquete) REFERENCES StatusPaquete(id_StatusPaquete))

drop proc Select_informePaquete
create proc Select_informePaquete(
@idinformePaquete int)
as
begin
	Select
	id_informePaquete, codigoPaquete, id_cliente, id_transporte,fechaenvio, fecharecibo,id_sucursalOrigen, id_sucursalDestino,id_StatusPaquete 
	from informePaquete where id_informePaquete = @idinformePaquete
end


drop proc SelectAll_informePaquete
create proc SelectAll_informePaquete
as
begin
	Select
	id_informePaquete, codigoPaquete, id_cliente, id_transporte,fechaenvio, fecharecibo,id_sucursalOrigen, id_sucursalDestino,id_StatusPaquete 
	from informePaquete
end

exec SelectAll_informePaquete

drop proc Save_informePaquete
create proc Save_informePaquete(
@idcliente int,
@idtransporte int,
@fechaenvio date,
@fecharecibo date,
@idsucursalorigen int,
@idsucursaldestino int)
as
Begin 
Declare
	@idstatuspaquete int = 1,
	@letras_origen varchar(3), 
	@letras_destino varchar(3),
	@codigopaquete varchar(20);
	set @letras_origen = (select upper(left(nombresucursal,3)) from sucursal where id_sucursal = @idsucursalorigen);
	
	set @letras_destino = (select upper(left(nombresucursal,3)) from sucursal where id_sucursal = @idsucursaldestino);

	Set @codigopaquete = @letras_origen + cast(cast((rand()*10000) as int) as varchar) + @letras_destino

	insert into informePaquete(codigoPaquete, id_cliente,id_transporte, fechaenvio, fecharecibo, id_sucursalorigen, id_sucursaldestino, id_statuspaquete) 
	values (@codigopaquete, @idcliente , @idtransporte , @fechaenvio , @fecharecibo , @idsucursalorigen , @idsucursaldestino,@idstatuspaquete)
end

Exec dbo.Save_informePaquete @idcliente = 1,@idtransporte = 1,@fechaenvio = '2022-10-21',@fecharecibo ='2022-10-31',@idsucursalorigen = 1,@idsucursaldestino =2

drop proc Save_informePaquete

select cast(cast((rand()*10000) as int) as varchar)

drop proc Edit_informePaquete
create proc Edit_informePaquete(
@idinformepaquete int,
@idcliente int null,
@codigopaquete varchar(20) null,
@idtransporte int null,
@fechaenvio date null,
@fecharecibo date null,
@idsucursalorigen int null,
@idsucursaldestino int null,
@idstatuspaquete int null)
as
begin
	update informePaquete set
	id_cliente = isnull(@idcliente, id_cliente),
	codigopaquete = isnull(@codigopaquete, codigoPaquete),
	id_transporte = isnull(@idtransporte, id_transporte),
	fechaenvio = isnull(@fechaenvio, fechaEnvio),
	fecharecibo = isnull(@fecharecibo, fecharecibo),
	id_sucursalorigen = isnull(@idsucursalorigen, id_sucursalorigen),
	id_sucursaldestino = isnull(@idsucursaldestino, id_sucursaldestino),
	id_statuspaquete = isnull(@idstatuspaquete, id_statuspaquete)

	where id_informepaquete = @idinformepaquete

end

create proc Delete_informepaquete(
@idcliente int)
as
begin
	delete from informepaquete where id_informepaquete = @idcliente
end
