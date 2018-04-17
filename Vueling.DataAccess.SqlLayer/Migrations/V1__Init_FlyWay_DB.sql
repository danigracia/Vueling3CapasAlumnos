USE StudentDB
-- Crear nueva Tabla llamada 'Customers' con Chema 'dbo'
-- La tabla si existe la borramos

--IF OBJECT_ID('dbo.Students', 'U') IS NOT NULL
--DROP TABLE dbo.Students
--GO

-- Creamos la Tabla
CREATE TABLE dbo.Students
(
   Id        INT    NOT NULL   PRIMARY KEY IDENTITY(1,1), -- Clave Primaria
   Nombre      [NVARCHAR](50)  NOT NULL,
   Apellidos       [NVARCHAR](50)  NOT NULL,
   Dni       [NVARCHAR](50)  NOT NULL,
   Edad			[INT] NOT NULL,
   FechaNacimiento		[DATE] NOT NULL,
   HoraRegistro		[DATETIME] NOT NULL,
   Student_Guid				[NVARCHAR](50) NOT NULL
);
GO