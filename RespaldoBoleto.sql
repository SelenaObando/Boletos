use buses_boletos

create procedure RespaldoBD_BOLETO
AS
BEGIN

SET NOCOUNT ON
BACKUP DATABASE [Buses_Boletos]
TO DISK = N'F:\BACKUPBOLETO\rbd_Boleto.bak'
WITH CHECKSUM;
END 
GO
