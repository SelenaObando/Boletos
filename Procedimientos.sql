use Buses_Boletos

----creando procedimientos
select * from propietario
---1
CREATE PROCEDURE cliente
@b int, @Idcliente int, @Nombres varchar(50), @Apellidos varchar(50), @Cedula varchar(20), @Telefono varchar(20), @Idruta int, @Idboleto int
as
begin 
    set nocount on;
	if @b=1
	insert into Clientes values (@Nombres, @Apellidos, @Cedula, @Telefono, @Idruta, @Idboleto);
	 
	if @b=2
	delete from Clientes where Idcliente=@Idcliente;
	 
	if @b=3
	select * from Clientes;

	if @b=4
	update Clientes
	set Nombres=@Nombres, Apellidos=@Apellidos, Cedula=@Cedula, Telefono=@Telefono, Idruta=@Idruta, Idboleto=@Idboleto
	 where @Idcliente=Idcliente;
	 
	if @b=5
	select * from Clientes
	where Nombres like '%' + @Nombres + '%'

end 
go

-----2
create procedure compraboleto
@b int, @Idboleto int, @Nmero_asiento int, @Precio int, @Fecha varchar(50), @Idruta int
as
begin
    set nocount on;
	if @b= 1
	insert into Compra_boleto values (@Nmero_asiento, @Precio, @Fecha, @Idruta);
	
	if @b= 2
	delete from Compra_boleto where Idboleto=@Idboleto;
	
	if @b=3
	select * from Compra_boleto;
	
	if @b=4
	update Compra_boleto
	set Nmero_asiento=@Nmero_asiento, Precio=@Precio, Fecha=@Fecha, Idruta=@Idruta
	where @Idboleto=Idboleto;
	
	if @b=5
	select * from Compra_boleto
	where Idboleto like '%' + @Idboleto + '%'

end 
go


---3
create procedure propiet
@b int, @Idpropietario int, @Nombresp varchar(50), @Apellidosp varchar(50), @Direccionp varchar(100), @Telefonop varchar(10), @Nombretransp varchar(20)
as
begin
    set nocount on;
	if @b=1
	insert into Propietario values (@Nombresp, @Apellidosp, @Direccionp, @Telefonop, @Nombretransp);
	
	if @b= 2
	delete from Propietario where Idpropietario=@Idpropietario;
	
	if @b=3
	select * from Propietario;
	
	if @b= 4
	update Propietario
	set Nombresp=@Nombresp, Apellidosp=@Apellidosp, Direccionp=@Direccionp, Telefonop=@Telefonop, @Nombretransp=@Nombretransp
	where @Idpropietario=Idpropietario;
	
	if @b=5
	select * from Propietario
	where Nombresp like '%' + Nombresp + '%'

end 
go

----4
create procedure rut
@b int, @Idruta int, @NombreR varchar(50), @Cant_asientos int, @Hora_origen1 varchar(50), @Hora_destino1 varchar(50), @Hora_origen2 varchar(50), @Hora_destino2 varchar(50), @Idpropietario int
as
begin
    set nocount on;
	if @b=1
	Insert into Ruta values (@NombreR, @Cant_asientos, @Hora_origen1, @Hora_destino1, @Hora_origen2, @Hora_origen2, @Idpropietario);
	
	if @b=2
	delete from Ruta where Idruta=@Idruta;
	
	if @b=3
	select * from Ruta;
	
	if @b=4
	update Ruta
	set NombreR=@NombreR, Cant_asientos=@Cant_asientos, Hora_origen1=@Hora_origen1, Hora_destino1=@Hora_destino1, 
	Hora_origen2=@Hora_origen2, Hora_destino2=@Hora_destino2, Idpropietario=@Idpropietario
	where @Idruta=Idruta;
	
	if @b=5
	select * from Ruta
	where NombreR like '%' + NombreR;

end
go

---5
create procedure usuar
@b int, @Idusuario int, @Nombre varchar(20), @Apellido varchar(20), @Direccion varchar(50), @Correo varchar(30), @TelefonoU varchar(20)
as
begin
    set nocount on;
	
	if @b=1
	insert into Usuario values (@Nombre, @Apellido, @Direccion, @Correo, @TelefonoU);
	
	if @b=2
	delete from Usuario where Idusuario=@Idusuario;
	
	if @b=3
	select * from Usuario;
	
	if @b= 4
	update Usuario
	set Nombre=@Nombre, Apellido=@Apellido, Direccion=@Direccion, Correo=@Correo, TelefonoU=@TelefonoU
	where @Idusuario=Idusuario;
	
	if @b=5
	select * from Usuario
	where Nombre like '%' + Nombre + '%'

end
go