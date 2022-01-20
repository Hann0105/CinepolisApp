ALTER PROCEDURE [dbo].[spInsertNewUser]
	@User varchar(60), 
	@Password varchar(60),
	@Nombre varchar(60),
	@Apellido varchar(60),
	@tipoUsuario int,
	@idSupervisor int,
	@idRegion int
AS
	
	DECLARE @idSiguiente int;

	Select @idSiguiente = ISNULL((Select MAX(idUsuario)+1 from Usuarios), 1);

	Insert into Usuarios values(@idSiguiente, @User, @Password, @Nombre, @Apellido, @tipoUsuario, @idSupervisor, 1, @idRegion);

RETURN 0
