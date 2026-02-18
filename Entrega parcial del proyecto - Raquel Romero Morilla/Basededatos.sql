
USE inventario_db;
GO


IF OBJECT_ID('articulos', 'U') IS NOT NULL 
    DROP TABLE articulos;
GO

CREATE TABLE articulos (
    id INT IDENTITY(1,1) PRIMARY KEY,
    imagen VARCHAR(MAX) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    stock INT NOT NULL
);
GO

INSERT INTO articulos (imagen, nombre, stock) VALUES
('FOTOS/teclado.jpg', 'Teclado', 10),
('FOTOS/raton.jpg', 'Rat�n', 25),
('FOTOS/monitor.jpg', 'Monitor', 8),
('FOTOS/impresora.jpg', 'Impresora', 5),
('FOTOS/altavoces.jpg', 'Altavoces', 12),
('FOTOS/webcam.jpg', 'Webcam', 18),
('FOTOS/microfono.jpg', 'Micr�fono', 7),
('FOTOS/portatil.jpg', 'Port�til', 4),
('FOTOS/tablet.jpg', 'Tablet', 9),
('FOTOS/discoduro.jpg', 'Disco Duro', 15),
('FOTOS/memoriausb.jpg', 'Memoria USB', 30),
('FOTOS/router.jpg', 'Router', 6),
('FOTOS/switch.jpg', 'Switch', 11),
('FOTOS/proyector.jpg', 'Proyector', 3),
('FOTOS/camara.jpg', 'C�mara', 14),
('FOTOS/smartphone.jpg', 'Smartphone', 20),
('FOTOS/auriculares.jpg', 'Auriculares', 22),
('FOTOS/cable_hdmi.jpg', 'Cable HDMI', 40),
('FOTOS/cableusb.jpg', 'Cable USB', 35),
('FOTOS/tarjetagrafica.jpg', 'Tarjeta Gr�fica', 2),
('FOTOS/fuentepoder.jpg', 'Fuente de Poder', 6),
('FOTOS/placabase.jpg', 'Placa Base', 5),
('FOTOS/procesador.jpg', 'Procesador', 7),
('FOTOS/memoriamram.jpg', 'Memoria RAM', 16),
('FOTOS/ssd.jpg', 'SSD', 13),
('FOTOS/sillagaming.jpg', 'Silla Gaming', 4),
('FOTOS/mesaescritorio.jpg', 'Mesa Escritorio', 3),
('FOTOS/lamparaled.jpg', 'L�mpara LED', 17),
('FOTOS/regleta.jpg', 'Regleta', 21),
('FOTOS/adaptador.jpg', 'Adaptador', 19);
GO


SELECT * FROM articulos;