create database ABMcliente
use ABMcliente

create table cliente(
Id_cliente int identity(1,1) primary key,
Nombre varchar(50),
Apellido varchar(50),
Direccion varchar(100),
Email varchar(100),
Telefono int,
Fecha date,
);

create procedure sp_Listar
as
begin
select * from cliente 
end
create procedure sp_Obtener(
@Id_cliente int
)
as
begin
select * from cliente where Id_cliente = @Id_cliente
end

create procedure sp_Guardar(
@Nombre varchar(100),
@Apellido varchar(100),
@Direccion varchar(100),
@Email varchar(100),
@Telefono int,
@Fecha date
)
as
begin
  insert into cliente(Nombre,Apellido,Direccion,Email,Telefono,Fecha) values(@Nombre,@Apellido,@Direccion,@Email,@Telefono,@Fecha)
  end
  create procedure sp_Editar(
  @Id_cliente int,
  @Nombre varchar(100),
  @Apellido varchar(100),
  @Direccion varchar(100),
  @Email varchar(100),
  @Telefono int,
  @Fecha date
  )
  as
  begin
   update cliente set Nombre=@Nombre, Apellido=@Apellido, Direccion=@Direccion, Email=@Email, Telefono=@Telefono, Fecha=@Fecha where Id_cliente = @Id_cliente
   end

create procedure sp_Eliminar
 @Id_cliente int
 )
 as
  begin
 delete from cliente where Id_cliente = @Id_cliente
 end
