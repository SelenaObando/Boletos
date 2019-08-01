create database Buses_Boletos
go
use Buses_Boletos



-------Creando tablas con sus atributos

create table Clientes(
Idcliente int primary key identity (1,1),
Nombres varchar(50),
Apellidos varchar(50),
Cedula varchar(20),
Telefono varchar(20),
Idruta int,
Idboleto int,
foreign key(Idruta) references Ruta (Idruta),
foreign key(Idboleto) references Compra_boleto(Idboleto),
);

create table Usuario(
Idusuario int primary key identity(1,1),
Nombre varchar(20),
Apellido varchar(20),
Direcciòn varchar(50),
Correo varchar(30),
TelefonoU varchar(20),
);

create table Propietario(
Idpropietario int primary key identity(1,1),
Nombresp varchar(50),
Apellidosp varchar(50),
Direccionp varchar(100),
Telefonop varchar(10),
Nombretransp varchar(20),
);


create table Ruta(
Idruta int primary key identity(1,1),
NombreR varchar (50),
Idbus int,
Cant_asientos int,
Hora_origen1 time,
Hora_destino1 time,
Hora_origen2 time,
Hora_destino2 time,
Idpropietario int,
foreign key(Idpropietario) references Propietario(Idpropietario),
); 

create table Compra_boleto(
Idboleto int primary key identity (1,1),
Nmero_asiento int,
Precio int,
Fecha datetime default getdate(),
Idruta int,
foreign key(Idruta) references Ruta(Idruta),
);