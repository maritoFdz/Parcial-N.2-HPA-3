CREATE DATABASE IF NOT EXISTS bd_login
  DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE bd_login;

DROP TABLE IF EXISTS usuarios;
DROP TABLE IF EXISTS productos;

CREATE TABLE usuarios (
  id                    INT          NOT NULL AUTO_INCREMENT,
  dsId                  VARCHAR(50)  NOT NULL,
  dsUsuario             VARCHAR(50)  NOT NULL,
  dsPassword            VARCHAR(255) NOT NULL,
  dsEstado              CHAR(1)      NOT NULL DEFAULT '1',
  dsRol                 VARCHAR(10)  NOT NULL DEFAULT 'USER',
  dsUsuarioCreacion     VARCHAR(50)  NOT NULL DEFAULT 'Sistema',
  dtFechaCreacion       DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP,
  dsUsuarioModificacion VARCHAR(50)  NOT NULL DEFAULT 'Sistema',
  dtFechaModificacion   DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (id),
  UNIQUE KEY uq_usuarios_dsId (dsId),
  UNIQUE KEY uq_usuarios_dsUsuario (dsUsuario)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE productos (
  id                INT           NOT NULL AUTO_INCREMENT,
  dsNombre          VARCHAR(100)  NOT NULL,
  dcPrecio          DECIMAL(10,2) NOT NULL,
  nuStock           INT           NOT NULL,
  dsUsuarioCreacion VARCHAR(50)   NOT NULL DEFAULT 'Sistema',
  dtFechaCreacion   DATETIME      NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (id),
  UNIQUE KEY uq_productos_dsNombre (dsNombre)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO usuarios (dsId, dsUsuario, dsPassword, dsEstado, dsRol, dsUsuarioCreacion)
VALUES ('001', 'admin',
        'PBKDF2$100000$s9ZZ05yl21TLZXccpuBOCQ==$Tp928oQVG4fj/BVC0AcV54lk60QTYGabalz3nfVIt5I=',
        '1', 'ADMIN', 'Sistema');

INSERT INTO productos (dsNombre, dcPrecio, nuStock) VALUES
  ('Laptop Asus X540LA',     549.99, 12),
  ('Notebook Acer SW1-011',  329.50,  8),
  ('Zenbook Asus UX305',     799.00,  5),
  ('Mouse Logitech M185',     14.99, 40);

DROP PROCEDURE IF EXISTS sp_login;
DROP PROCEDURE IF EXISTS sp_registrar_usuario;
DROP PROCEDURE IF EXISTS sp_listar_productos;
DROP PROCEDURE IF EXISTS sp_agregar_producto;
DROP PROCEDURE IF EXISTS sp_actualizar_producto;
DROP PROCEDURE IF EXISTS sp_eliminar_producto;

DELIMITER $$

CREATE PROCEDURE sp_login(IN p_usuario VARCHAR(50))
BEGIN
    SELECT id, dsId, dsUsuario, dsPassword, dsEstado, dsRol
    FROM usuarios
    WHERE dsUsuario = p_usuario
      AND dsEstado = '1';
END$$

CREATE PROCEDURE sp_registrar_usuario(
    IN p_usuario VARCHAR(50),
    IN p_hash    VARCHAR(255),
    IN p_creador VARCHAR(50))
BEGIN
    DECLARE v_dsId VARCHAR(50);
    SELECT LPAD(IFNULL(MAX(id), 0) + 1, 3, '0') INTO v_dsId FROM usuarios;

    INSERT INTO usuarios (dsId, dsUsuario, dsPassword, dsEstado, dsUsuarioCreacion)
    VALUES (v_dsId, p_usuario, p_hash, '1', p_creador);
END$$

CREATE PROCEDURE sp_listar_productos()
BEGIN
    SELECT id, dsNombre, dcPrecio, nuStock, dsUsuarioCreacion, dtFechaCreacion
    FROM productos
    ORDER BY id;
END$$

CREATE PROCEDURE sp_agregar_producto(
    IN p_nombre  VARCHAR(100),
    IN p_precio  DECIMAL(10,2),
    IN p_stock   INT,
    IN p_creador VARCHAR(50))
BEGIN
    INSERT INTO productos (dsNombre, dcPrecio, nuStock, dsUsuarioCreacion)
    VALUES (p_nombre, p_precio, p_stock, p_creador);
END$$

CREATE PROCEDURE sp_actualizar_producto(
    IN p_id     INT,
    IN p_nombre VARCHAR(100),
    IN p_precio DECIMAL(10,2),
    IN p_stock  INT)
BEGIN
    UPDATE productos
    SET dsNombre = p_nombre, dcPrecio = p_precio, nuStock = p_stock
    WHERE id = p_id;
END$$

CREATE PROCEDURE sp_eliminar_producto(IN p_id INT)
BEGIN
    DELETE FROM productos WHERE id = p_id;
END$$

DELIMITER ;

CREATE USER IF NOT EXISTS 'app_login'@'localhost' IDENTIFIED BY 'ClaveSegura#2026';

GRANT EXECUTE ON PROCEDURE bd_login.sp_login               TO 'app_login'@'localhost';
GRANT EXECUTE ON PROCEDURE bd_login.sp_registrar_usuario   TO 'app_login'@'localhost';
GRANT EXECUTE ON PROCEDURE bd_login.sp_listar_productos    TO 'app_login'@'localhost';
GRANT EXECUTE ON PROCEDURE bd_login.sp_agregar_producto    TO 'app_login'@'localhost';
GRANT EXECUTE ON PROCEDURE bd_login.sp_actualizar_producto TO 'app_login'@'localhost';
GRANT EXECUTE ON PROCEDURE bd_login.sp_eliminar_producto   TO 'app_login'@'localhost';

FLUSH PRIVILEGES;