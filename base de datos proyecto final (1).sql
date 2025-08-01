CREATE DATABASE HotelLaCeibenia;
USE HotelLaCeibenia;

CREATE TABLE Clientes (
id_cliente INT AUTO_INCREMENT PRIMARY KEY,
nombre VARCHAR(50),
apellido VARCHAR(50),
dni VARCHAR(20),
teléfono VARCHAR(20),
correo VARCHAR(100),
dirección VARCHAR(100)
);

CREATE TABLE Habitaciones (
id_habitacion INT AUTO_INCREMENT PRIMARY KEY,
numero VARCHAR(10),
tipo VARCHAR(30), -- SI ES SUITE, SI ES PARA DOS PERSONAS O UNA ETC 
precio_noche VARCHAR(50),
estado  VARCHAR(20) -- SI ESTA OCUPADA O DISPONIBLE, EN LIMPIEZA ETC 
);

CREATE TABLE Reservas (
id_reserva INT AUTO_INCREMENT PRIMARY KEY,
id_cliente INT,
fecha_entrada DATE,
fecha_salida DATE,
estado VARCHAR(20)-- SI ESTA ACTIVA, CANCELADA, FINALIZADA ETC 
);

CREATE TABLE Detalles_Reserva (
id_detalle INT AUTO_INCREMENT PRIMARY KEY,
id_reserva INT,
id_habitacion INT,
cantidad_noches INT ,
subtotal VARCHAR (50)
);

CREATE TABLE Pagos (
id_pago INT AUTO_INCREMENT PRIMARY KEY,
id_reserva INT,
fecha_pago DATETIME,
monto_total VARCHAR(50),
metodo_pago VARCHAR(50) -- SI PAGA CON EFECTIVO, TARJETA O TRANSFERENCIA 
);

-- LOGIN 

CREATE TABLE Usuarios (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(50) NOT NULL,
    nombre_completo VARCHAR(100),
    rol VARCHAR(20) -- admin, recepcionista, cliente
);

-- usuarios de prueba 
INSERT INTO Usuarios (username, password, nombre_completo, rol)
VALUES ('admin1', 'admin123', 'Administrador General', 'admin');


INSERT INTO Habitaciones(numero, tipo, precio_noche, estado) VALUES
(1, 'Simple', 800.00, 'Disponible'),
(2, 'Simple', 800.00, 'Disponible'),
(3, 'Simple', 800.00, 'Disponible'),
(4, 'Simple', 800.00, 'Disponible'),
(5, 'Simple', 800.00, 'Disponible'),
(6, 'Doble', 1200.00, 'Disponible'),
(7, 'Doble', 1200.00, 'Disponible'),
(8, 'Doble', 1200.00, 'Disponible'),
(9, 'Doble', 1200.00, 'Disponible'),
(10, 'Doble', 1200.00, 'Disponible'),
(11, 'Suite', 1800.00, 'Disponible'),
(12, 'Suite', 1800.00, 'Disponible'),
(13, 'Suite', 1800.00, 'Disponible'),
(14, 'Suite', 1800.00, 'Disponible'),
(15, 'Suite', 1800.00, 'Disponible'),
(16, 'Simple', 800.00, 'Disponible'),
(17, 'Doble', 1200.00, 'Disponible'),
(18, 'Suite', 1800.00, 'Disponible'),
(19, 'Simple', 800.00, 'Disponible'),
(20, 'Doble', 1200.00, 'Disponible');

