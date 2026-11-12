/* ============================================================
   TPC Comercio - Script de base de datos (SQL Server)
   Incluye: creación de la base, tablas, restricciones y datos de prueba.

   Cómo usarlo: abrirlo en SSMS (o en Visual Studio > Explorador de
   objetos de SQL Server) y ejecutarlo completo.

   Si necesitan EMPEZAR DE CERO (borra TODA la base), ejecuten antes:
       USE master;
       ALTER DATABASE comercio_db SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
       DROP DATABASE comercio_db;
   ============================================================ */

IF DB_ID('comercio_db') IS NULL
    CREATE DATABASE comercio_db;
GO

USE comercio_db;
GO

/* ------------------------------------------------------------
   TABLAS
   ------------------------------------------------------------ */

CREATE TABLE Perfil (
    idPerfil INT IDENTITY(1,1) NOT NULL,
    nombre   NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_Perfil PRIMARY KEY (idPerfil),
    CONSTRAINT UQ_Perfil_nombre UNIQUE (nombre)
);

CREATE TABLE Usuario (
    idUsuario     INT IDENTITY(1,1) NOT NULL,
    nombreUsuario NVARCHAR(50)  NOT NULL,
    -- Tamaño amplio a propósito: más adelante se guardará un hash, no el texto plano.
    password      NVARCHAR(200) NOT NULL,
    nombre        NVARCHAR(100) NOT NULL,
    apellido      NVARCHAR(100) NOT NULL,
    activo        BIT NOT NULL CONSTRAINT DF_Usuario_activo DEFAULT 1,
    idPerfil      INT NOT NULL,
    CONSTRAINT PK_Usuario PRIMARY KEY (idUsuario),
    CONSTRAINT UQ_Usuario_nombreUsuario UNIQUE (nombreUsuario),
    CONSTRAINT FK_Usuario_Perfil FOREIGN KEY (idPerfil) REFERENCES Perfil(idPerfil)
);

CREATE TABLE Marca (
    idMarca INT IDENTITY(1,1) NOT NULL,
    nombre  NVARCHAR(100) NOT NULL,
    activo  BIT NOT NULL CONSTRAINT DF_Marca_activo DEFAULT 1,
    CONSTRAINT PK_Marca PRIMARY KEY (idMarca),
    CONSTRAINT UQ_Marca_nombre UNIQUE (nombre)
);

CREATE TABLE Categoria (
    idCategoria INT IDENTITY(1,1) NOT NULL,
    nombre      NVARCHAR(100) NOT NULL,
    activo      BIT NOT NULL CONSTRAINT DF_Categoria_activo DEFAULT 1,
    CONSTRAINT PK_Categoria PRIMARY KEY (idCategoria),
    CONSTRAINT UQ_Categoria_nombre UNIQUE (nombre)
);

CREATE TABLE Producto (
    idProducto         INT IDENTITY(1,1) NOT NULL,
    nombre             NVARCHAR(150) NOT NULL,
    descripcion        NVARCHAR(300) NULL,
    stockActual        INT NOT NULL CONSTRAINT DF_Producto_stockActual DEFAULT 0,
    stockMinimo        INT NOT NULL CONSTRAINT DF_Producto_stockMinimo DEFAULT 0,
    -- Porcentaje de ganancia, por ejemplo 30.00 = 30 %
    porcentajeGanancia DECIMAL(5,2) NOT NULL,
    activo             BIT NOT NULL CONSTRAINT DF_Producto_activo DEFAULT 1,
    idMarca            INT NOT NULL,
    idCategoria        INT NOT NULL,
    CONSTRAINT PK_Producto PRIMARY KEY (idProducto),
    CONSTRAINT FK_Producto_Marca FOREIGN KEY (idMarca) REFERENCES Marca(idMarca),
    CONSTRAINT FK_Producto_Categoria FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria),
    CONSTRAINT CK_Producto_stockActual CHECK (stockActual >= 0),
    CONSTRAINT CK_Producto_stockMinimo CHECK (stockMinimo >= 0),
    CONSTRAINT CK_Producto_ganancia CHECK (porcentajeGanancia >= 0)
);

CREATE TABLE Proveedor (
    idProveedor INT IDENTITY(1,1) NOT NULL,
    razonSocial NVARCHAR(150) NOT NULL,
    cuit        NVARCHAR(13)  NOT NULL,
    email       NVARCHAR(150) NULL,
    telefono    NVARCHAR(30)  NULL,
    activo      BIT NOT NULL CONSTRAINT DF_Proveedor_activo DEFAULT 1,
    CONSTRAINT PK_Proveedor PRIMARY KEY (idProveedor),
    CONSTRAINT UQ_Proveedor_cuit UNIQUE (cuit)
);

-- Relación N a N: un producto puede tener varios proveedores y viceversa.
CREATE TABLE ProductoProveedor (
    idProducto  INT NOT NULL,
    idProveedor INT NOT NULL,
    CONSTRAINT PK_ProductoProveedor PRIMARY KEY (idProducto, idProveedor),
    CONSTRAINT FK_ProdProv_Producto FOREIGN KEY (idProducto) REFERENCES Producto(idProducto),
    CONSTRAINT FK_ProdProv_Proveedor FOREIGN KEY (idProveedor) REFERENCES Proveedor(idProveedor)
);

CREATE TABLE Cliente (
    idCliente INT IDENTITY(1,1) NOT NULL,
    nombre    NVARCHAR(100) NOT NULL,
    apellido  NVARCHAR(100) NOT NULL,
    documento NVARCHAR(20)  NOT NULL,
    email     NVARCHAR(150) NULL,
    telefono  NVARCHAR(30)  NULL,
    activo    BIT NOT NULL CONSTRAINT DF_Cliente_activo DEFAULT 1,
    CONSTRAINT PK_Cliente PRIMARY KEY (idCliente),
    CONSTRAINT UQ_Cliente_documento UNIQUE (documento)
);

CREATE TABLE Compra (
    idCompra    INT IDENTITY(1,1) NOT NULL,
    fecha       DATETIME NOT NULL CONSTRAINT DF_Compra_fecha DEFAULT GETDATE(),
    total       DECIMAL(12,2) NOT NULL CONSTRAINT DF_Compra_total DEFAULT 0,
    idProveedor INT NOT NULL,
    idUsuario   INT NOT NULL,
    CONSTRAINT PK_Compra PRIMARY KEY (idCompra),
    CONSTRAINT FK_Compra_Proveedor FOREIGN KEY (idProveedor) REFERENCES Proveedor(idProveedor),
    CONSTRAINT FK_Compra_Usuario FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario),
    CONSTRAINT CK_Compra_total CHECK (total >= 0)
);

CREATE TABLE DetalleCompra (
    idDetalleCompra INT IDENTITY(1,1) NOT NULL,
    cantidad        INT NOT NULL,
    precioCompra    DECIMAL(10,2) NOT NULL,
    idCompra        INT NOT NULL,
    idProducto      INT NOT NULL,
    CONSTRAINT PK_DetalleCompra PRIMARY KEY (idDetalleCompra),
    CONSTRAINT FK_DetCompra_Compra FOREIGN KEY (idCompra) REFERENCES Compra(idCompra),
    CONSTRAINT FK_DetCompra_Producto FOREIGN KEY (idProducto) REFERENCES Producto(idProducto),
    CONSTRAINT CK_DetCompra_cantidad CHECK (cantidad > 0),
    CONSTRAINT CK_DetCompra_precio CHECK (precioCompra >= 0)
);

CREATE TABLE Venta (
    idVenta       INT IDENTITY(1,1) NOT NULL,
    -- Número de factura único (el algoritmo de generación se hace en la Etapa 3).
    numeroFactura NVARCHAR(20) NOT NULL,
    fecha         DATETIME NOT NULL CONSTRAINT DF_Venta_fecha DEFAULT GETDATE(),
    total         DECIMAL(12,2) NOT NULL CONSTRAINT DF_Venta_total DEFAULT 0,
    idCliente     INT NOT NULL,
    idUsuario     INT NOT NULL,
    CONSTRAINT PK_Venta PRIMARY KEY (idVenta),
    CONSTRAINT UQ_Venta_numeroFactura UNIQUE (numeroFactura),
    CONSTRAINT FK_Venta_Cliente FOREIGN KEY (idCliente) REFERENCES Cliente(idCliente),
    CONSTRAINT FK_Venta_Usuario FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario),
    CONSTRAINT CK_Venta_total CHECK (total >= 0)
);

CREATE TABLE DetalleVenta (
    idDetalleVenta INT IDENTITY(1,1) NOT NULL,
    cantidad       INT NOT NULL,
    -- "Foto" del precio al momento de vender: no cambia aunque cambie el precio de compra.
    precioUnitario DECIMAL(10,2) NOT NULL,
    subtotal       DECIMAL(12,2) NOT NULL,
    idVenta        INT NOT NULL,
    idProducto     INT NOT NULL,
    CONSTRAINT PK_DetalleVenta PRIMARY KEY (idDetalleVenta),
    CONSTRAINT FK_DetVenta_Venta FOREIGN KEY (idVenta) REFERENCES Venta(idVenta),
    CONSTRAINT FK_DetVenta_Producto FOREIGN KEY (idProducto) REFERENCES Producto(idProducto),
    CONSTRAINT CK_DetVenta_cantidad CHECK (cantidad > 0),
    CONSTRAINT CK_DetVenta_precio CHECK (precioUnitario >= 0),
    CONSTRAINT CK_DetVenta_subtotal CHECK (subtotal >= 0)
);
GO

/* ------------------------------------------------------------
   DATOS DE PRUEBA
   ------------------------------------------------------------ */

INSERT INTO Perfil (nombre) VALUES (N'Administrador'), (N'Vendedor');

-- OJO: contraseñas en texto plano SOLO para desarrollo.
-- En la etapa de seguridad se reemplazan por un hash.
INSERT INTO Usuario (nombreUsuario, password, nombre, apellido, idPerfil) VALUES
    (N'admin',     N'admin123',    N'Admin',    N'Sistema', 1),
    (N'vendedor1', N'vendedor123', N'Vendedor', N'Uno',     2);

INSERT INTO Marca (nombre) VALUES (N'Marca A'), (N'Marca B'), (N'Marca C'), (N'Marca D');

INSERT INTO Categoria (nombre) VALUES (N'Almacén'), (N'Limpieza'), (N'Bebidas');

INSERT INTO Proveedor (razonSocial, cuit, email, telefono) VALUES
    (N'Distribuidora Norte S.A.', N'30-11111111-1', N'ventas@distnorte.example', N'11-5555-0001'),
    (N'Mayorista Sur S.R.L.',     N'30-22222222-2', N'pedidos@mayosur.example',  N'11-5555-0002');

-- Stock en 0: se completa más abajo a partir de las compras de prueba.
INSERT INTO Producto (nombre, descripcion, stockActual, stockMinimo, porcentajeGanancia, idMarca, idCategoria) VALUES
    (N'Yerba mate 1 kg',          NULL, 0, 10, 30.00, 1, 1),
    (N'Aceite de girasol 900 ml', NULL, 0, 12, 25.00, 2, 1),
    (N'Detergente 750 ml',        NULL, 0,  8, 35.00, 3, 2),
    (N'Fideos tirabuzón 500 g',   NULL, 0, 10, 30.00, 4, 1),
    (N'Gaseosa cola 2,25 l',      NULL, 0, 15, 20.00, 1, 3);

INSERT INTO ProductoProveedor (idProducto, idProveedor) VALUES
    (1, 1), (2, 1), (3, 2), (4, 1), (4, 2), (5, 2);

INSERT INTO Cliente (nombre, apellido, documento, email, telefono) VALUES
    (N'María',  N'Gómez',     N'30111222', N'maria.gomez@example.com',  N'11-4444-0001'),
    (N'Carlos', N'Pérez',     N'28333444', N'carlos.perez@example.com', N'11-4444-0002'),
    (N'Ana',    N'Rodríguez', N'35555666', N'ana.rodriguez@example.com', N'11-4444-0003');

-- Compras de prueba (idProveedor, idUsuario)
INSERT INTO Compra (idProveedor, idUsuario) VALUES (1, 1), (2, 1);

INSERT INTO DetalleCompra (cantidad, precioCompra, idCompra, idProducto) VALUES
    ( 2, 3200.00, 1, 1),
    ( 4, 1800.00, 1, 2),
    ( 9,  900.00, 1, 4),
    ( 6, 1400.00, 2, 3),
    (40, 1500.00, 2, 5);

-- El total de cada compra y el stock actual salen de sus líneas.
UPDATE Compra
SET total = (SELECT SUM(d.cantidad * d.precioCompra)
             FROM DetalleCompra d WHERE d.idCompra = Compra.idCompra);

UPDATE Producto
SET stockActual = ISNULL((SELECT SUM(d.cantidad)
                          FROM DetalleCompra d WHERE d.idProducto = Producto.idProducto), 0);
GO

/* ------------------------------------------------------------
   CONSULTA DE PRUEBA
   Productos con su último precio de compra y el precio de venta calculado:
   precio de venta = precio de compra más reciente x (1 + % ganancia / 100)
   ------------------------------------------------------------ */
SELECT
    p.idProducto,
    p.nombre,
    m.nombre AS marca,
    c.nombre AS categoria,
    p.stockActual,
    p.stockMinimo,
    CASE WHEN p.stockActual < p.stockMinimo THEN 'Reponer' ELSE 'OK' END AS estadoStock,
    ult.precioCompra AS ultimoPrecioCompra,
    CAST(ult.precioCompra * (1 + p.porcentajeGanancia / 100.0) AS DECIMAL(10,2)) AS precioVenta
FROM Producto p
INNER JOIN Marca m     ON m.idMarca = p.idMarca
INNER JOIN Categoria c ON c.idCategoria = p.idCategoria
OUTER APPLY (
    SELECT TOP 1 d.precioCompra
    FROM DetalleCompra d
    INNER JOIN Compra co ON co.idCompra = d.idCompra
    WHERE d.idProducto = p.idProducto
    ORDER BY co.fecha DESC, co.idCompra DESC
) ult
WHERE p.activo = 1
ORDER BY p.nombre;
GO



CREATE PROCEDURE storedListarProductos
AS
BEGIN
    SELECT p.idProducto, p.nombre, p.descripcion, p.stockActual, p.stockMinimo,
           p.porcentajeGanancia, p.activo,
           m.idMarca, m.nombre AS marca,
           c.idCategoria, c.nombre AS categoria,
           ult.precioCompra
    FROM Producto p
    INNER JOIN Marca m ON m.idMarca = p.idMarca
    INNER JOIN Categoria c ON c.idCategoria = p.idCategoria
    OUTER APPLY (SELECT TOP 1 dc.precioCompra
                 FROM DetalleCompra dc
                 INNER JOIN Compra co ON co.idCompra = dc.idCompra
                 WHERE dc.idProducto = p.idProducto
                 ORDER BY co.fecha DESC, dc.idDetalleCompra DESC) ult
    WHERE p.activo = 1
END