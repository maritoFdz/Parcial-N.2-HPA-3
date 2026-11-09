<img width="389" height="385" alt="image" src="https://github.com/user-attachments/assets/74b39722-cb36-491c-87d6-73f1ef0ce297" /># Parcial N. 2 — MVP por Capas

📅 Fecha: 08/11/2026  
📚 Asignatura: Herramientas de Programacion Aplicadas III  
👩‍🏫 Instructora: Ing. Irina Fong  
👥 Grupo: 1IL133

## 📋 Contenido del Repositorio

Este repositorio contiene una aplicación de escritorio desarrollada en **C# con .NET 9 y Windows Forms**, organizada en **programación por capas** y aplicando el patrón de diseño **MVP (Modelo – Vista – Presentador)**.

La aplicación está compuesta por las siguientes funcionalidades:

1. **Inicio de sesión seguro:** validación de credenciales con hash de contraseñas generado y verificado desde C#.
2. **Ventana principal MDI:** menú lateral izquierdo, reloj en tiempo real y usuario en sesión en la parte inferior del menú.
3. **CRUD de productos con roles:** pantalla de Inicio con la lista de productos. El rol `ADMIN` puede agregar, actualizar y eliminar; el rol `USER` solo puede consultar.
4. **Registro de usuarios:** formulario disponible únicamente para el administrador.

También se incluye el script SQL necesario para crear la base de datos, las tablas, los procedimientos almacenados y el usuario de la aplicación con privilegios mínimos.

## 🛠 Tecnologías Utilizadas

| Tecnología | Versión |
|---|---|
| **Lenguaje** | C# 13 |
| **Framework** | .NET 9 |
| **Interfaz gráfica** | Windows Forms |
| **Base de datos** | MySQL 8.x |
| **Conector** | MySql.Data 26.7.0 |
| **IDE recomendado** | Visual Studio 2022 |
| **Control de versiones** | Git |
| **Hash de contraseñas** | PBKDF2-SHA256 (`Rfc2898DeriveBytes`), 100 000 iteraciones, salt de 16 bytes |

**Conceptos aplicados:**

- Programación por capas
- Patrón de diseño MVP
- Interfaces y contratos independientes
- Inyección de dependencias por constructor
- Principio de responsabilidad única
- Hash y verificación de contraseñas con salt
- Roles y permisos (`ADMIN` y `USER`)
- Procedimientos almacenados
- Consultas parametrizadas
- Usuario de base de datos con privilegios mínimos
- Manejo de excepciones
- Validación de datos
- Operaciones CRUD
- Windows Forms y formularios MDI
- Documentación XML del código (`///`)

## 💻 Arquitectura y Funcionalidades

### Arquitectura por capas

```text
Presentacion (Vistas + Presentadores)  ──►  Negocios (Servicios + Contratos)  ──►  Datos  ──►  MySQL
              │                                         │                           │
              └────────────────────────  Entidades  ────────────────────────────────┘
```

| Proyecto | Responsabilidad | Referencia a |
|---|---|---|
| `Entidades` | Clases que representan los datos (`E_Usuario`, `E_Producto`). Sin lógica. | Nada |
| `Datos` | Conexión a MySQL y acceso a datos mediante procedimientos almacenados. | `Entidades` |
| `Negocios` | Reglas de negocio, permisos por rol y contratos de seguridad. | `Entidades`, `Datos` |
| `Presentacion` | Formularios (Vistas), Presentadores e interfaces de Vista. | `Entidades`, `Negocios` |

La capa de **Presentación no referencia a Datos**: la ventana nunca se comunica directamente con la base de datos.

### Patrón MVP

| Rol | Clases |
|---|---|
| **Modelo** | `IUsuarioService` / `N_Usuario` e `IProductoService` / `N_Producto` (capa de Negocios) |
| **Vista** | `FrmLogin`, `FrmPrincipal`, `FrmProductos`, `FrmRegistroUsuario` |
| **Presentador** | `LoginPresenter`, `MainPresenter`, `ProductosPresenter`, `RegistroUsuarioPresenter` |

Las Vistas implementan una interfaz (`ILoginView`, `IMainView`, `IProductosView`, `IRegistroUsuarioView`). El Presentador solo conoce la interfaz, nunca el formulario concreto.

La Vista únicamente muestra controles y lanza eventos. No conoce el hash de las contraseñas ni la base de datos.

### Contratos independientes en la capa de Negocios

Ubicación:

```text
Negocios/Seguridad/
```

```csharp
public interface IHashService
{
    string GenerarHash(string textoPlano);
}

public interface IVerificarHashService
{
    bool Verificar(string textoPlano, string hashAlmacenado);
}
```

| Interfaz | Única responsabilidad | Implementación |
|---|---|---|
| `IHashService` | Generar el hash de una contraseña | `HashService` |
| `IVerificarHashService` | Verificar una contraseña en texto plano contra el hash almacenado | `VerificarHashService` |

El hash se guarda con el formato:

```text
PBKDF2$iteraciones$salt(Base64)$hash(Base64)
```

Si en el futuro se cambia el algoritmo (por ejemplo a BCrypt o Argon2), solo se reemplazan las clases que implementan las interfaces.

### 1. Inicio de sesión

Clases principales: `FrmLogin`, `LoginPresenter`, `N_Usuario`, `D_Usuario`.

- El procedimiento `sp_login` devuelve el usuario activo y su hash.
- La verificación de la contraseña se realiza en C# mediante `IVerificarHashService`.
- Si el usuario no existe o la contraseña no coincide, se muestra el mismo mensaje, para no revelar cuál de los dos datos falló.
- El hash no se envía hacia la interfaz: se elimina de la entidad antes de devolverla.
- Después de 3 intentos fallidos, la aplicación se cierra.

### 2. Ventana principal MDI

Clases principales: `FrmPrincipal`, `MainPresenter`.

- Formulario contenedor MDI (`IsMdiContainer = true`).
- **Menú lateral izquierdo** con las opciones Inicio, Registrar usuario (solo administrador) y Cerrar sesión.
- **Hora y fecha actuales** actualizadas cada segundo mediante un `Timer`.
- **Usuario en sesión** en la parte inferior del menú lateral.
- La opción **Cerrar sesión** regresa a la pantalla de inicio de sesión.
- `FrmBienvenida` es un formulario hijo MDI sencillo que muestra un saludo al usuario en sesión. No contiene lógica de negocio, por lo que no utiliza Presentador.

### 3. CRUD de productos con roles

Clases principales: `FrmProductos`, `ProductosPresenter`, `N_Producto`, `D_Producto`.

La pantalla de **Inicio** muestra la lista de productos y, en la esquina inferior derecha, el usuario en sesión con su rol.

| Rol | Permisos |
|---|---|
| `ADMIN` | Agregar, actualizar y eliminar productos. Registrar usuarios. |
| `USER` | Solo consultar la lista de productos (modo solo lectura). |

El permiso se valida en la **capa de Negocios** (`N_Producto` y `N_Usuario`). Ocultar el panel de edición en la pantalla es solo una comodidad visual: aunque se intentara ejecutar la acción desde la interfaz, Negocios lanzaría una `UnauthorizedAccessException`.

### 4. Registro de usuarios

Clases principales: `FrmRegistroUsuario`, `RegistroUsuarioPresenter`, `N_Usuario`.

- Disponible solo para el rol `ADMIN`.
- La contraseña se convierte en hash con `IHashService` antes de guardarse.
- Se registra quién creó cada usuario.
- Los usuarios nuevos se crean con el rol `USER`.

### Validación de información

| Pantalla | Regla | Mensaje |
|---|---|---|
| Login | Usuario vacío | "Ingrese el usuario." |
| Login | Contraseña vacía | "Ingrese la contraseña." |
| Login | Credenciales incorrectas | "Usuario o contraseña incorrectos. Intento X de 3." |
| Login | 3 intentos fallidos | La aplicación se cierra |
| Registro | Usuario de 3 a 50 caracteres | "El usuario debe tener entre 3 y 50 caracteres." |
| Registro | Contraseña de al menos 6 caracteres | "La contraseña debe tener al menos 6 caracteres." |
| Registro | Confirmación distinta | "Las contraseñas no coinciden." |
| Registro | Usuario repetido | "El usuario ya existe." |
| Registro | Usuario que no es administrador | "Solo el administrador puede registrar usuarios." |
| Productos | Nombre vacío | "Ingrese el nombre del producto." |
| Productos | Precio no numérico | "El precio debe ser un número válido." |
| Productos | Stock no entero | "El stock debe ser un número entero." |
| Productos | Stock negativo | "El stock no puede ser negativo." |
| Productos | Nombre repetido | "Ya existe un producto con ese nombre." |
| Productos | Sin selección al actualizar o eliminar | "Seleccione un producto de la lista." |
| Productos | Usuario sin rol de administrador | "Solo el administrador puede realizar esta acción." |

### Controles utilizados

| Control | Uso |
|---|---|
| `Form` (`IsMdiContainer = true`) | Ventana principal MDI y formularios hijos |
| `Panel` (`Dock = Left`) | Menú lateral izquierdo |
| `Panel` (`Dock = Bottom`) | Zona del usuario en sesión y barra de mensajes |
| `Panel` (`Dock = Top`) | Panel de edición de productos |
| `Button` (`FlatStyle.Flat`) | Opciones del menú y acciones de los formularios |
| `Label` | Títulos, mensajes de validación, hora, fecha y usuario |
| `TextBox` (`UseSystemPasswordChar`) | Entrada de usuario, contraseñas y datos del producto |
| `DataGridView` | Lista de productos |
| `Timer` | Actualiza la hora cada segundo |
| `MessageBox` | Confirmación de eliminación y avisos |

### Base de datos

El archivo:

```text
querysParcial.sql
```

crea la base de datos `bd_login`, las tablas, los procedimientos almacenados, el usuario de la aplicación y los permisos.

Se encuentra en la carpeta de solución **Solution Items**, por lo que puede abrirse directamente desde el Explorador de soluciones de Visual Studio.

**Tabla `usuarios`**

| Campo | Tipo | Descripción |
|---|---|---|
| `id` | `int` | Identificador único autoincremental |
| `dsId` | `varchar(50)` | Código del usuario |
| `dsUsuario` | `varchar(50)` | Nombre de usuario (único) |
| `dsPassword` | `varchar(255)` | Hash de la contraseña |
| `dsEstado` | `char(1)` | `1` activo, `0` inactivo |
| `dsRol` | `varchar(10)` | `ADMIN` o `USER` |
| `dsUsuarioCreacion` | `varchar(50)` | Quién creó el registro |
| `dtFechaCreacion` | `datetime` | Fecha de creación |
| `dsUsuarioModificacion` | `varchar(50)` | Quién modificó el registro |
| `dtFechaModificacion` | `datetime` | Fecha de modificación |

**Tabla `productos`**

| Campo | Tipo | Descripción |
|---|---|---|
| `id` | `int` | Identificador único autoincremental |
| `dsNombre` | `varchar(100)` | Nombre del producto (único) |
| `dcPrecio` | `decimal(10,2)` | Precio |
| `nuStock` | `int` | Cantidad disponible |
| `dsUsuarioCreacion` | `varchar(50)` | Quién creó el registro |
| `dtFechaCreacion` | `datetime` | Fecha de creación |

**Procedimientos almacenados:** `sp_login`, `sp_registrar_usuario`, `sp_listar_productos`, `sp_agregar_producto`, `sp_actualizar_producto`, `sp_eliminar_producto`.

### Conexión con privilegios mínimos

La aplicación **no utiliza `root`**. Se conecta con el usuario `app_login`, que solo tiene permiso `EXECUTE` sobre los seis procedimientos anteriores. No puede leer ni modificar las tablas directamente, ni acceder a otras bases de datos.

## 💻 Capturas de Pantalla

### Ventana principal MDI (menú lateral, hora y usuario en sesión)

###Como USER
<img width="1920" height="1024" alt="image" src="https://github.com/user-attachments/assets/2b205eeb-299c-431f-b4f7-d7df9fe6a30c" />


###Como ADMIN
<img width="1920" height="1023" alt="image" src="https://github.com/user-attachments/assets/74c91a6c-c0db-4bec-986f-dfeb20f8716b" />


### Inicio de sesión

<img width="389" height="383" alt="image" src="https://github.com/user-attachments/assets/13fcb56c-d301-4c9d-880e-2f386c0a0c1b" />


### CRUD de productos en modo solo lectura (rol USER)
<img width="855" height="524" alt="image" src="https://github.com/user-attachments/assets/533edbdc-0629-493f-84e6-91de0ab3f56a" />


### CRUD de productos en modo edición (rol ADMIN)
<img width="832" height="507" alt="image" src="https://github.com/user-attachments/assets/3f179c70-e957-4d5c-9e5c-ff6644c721e1" />

<img width="848" height="523" alt="image" src="https://github.com/user-attachments/assets/f57c6aba-bd48-497f-9b94-adad10a32e26" />

<img width="905" height="528" alt="image" src="https://github.com/user-attachments/assets/6533d46a-655a-4a72-b6cc-5010ff421901" />

<img width="873" height="552" alt="image" src="https://github.com/user-attachments/assets/99b151d3-b6b1-44c1-8ee5-79c17607d32f" />

<img width="855" height="527" alt="image" src="https://github.com/user-attachments/assets/1fe68149-f0fc-46c9-b458-f31d9c3e5f72" />

<img width="855" height="527" alt="image" src="https://github.com/user-attachments/assets/f73017cb-51d2-48ed-b253-ffbab5d89ebf" />


### Registro de Usuarios

<img width="389" height="385" alt="image" src="https://github.com/user-attachments/assets/0fcfb45b-dbae-48ed-8b73-982cfcbd6c4d" />


### Validaciones

<img width="372" height="390" alt="image" src="https://github.com/user-attachments/assets/a60d9fd7-288c-46d7-9890-0cc233d204b6" />

<img width="850" height="506" alt="image" src="https://github.com/user-attachments/assets/1e81c486-4c7a-4276-98c2-24dbd1d28e4d" />

<img width="838" height="511" alt="image" src="https://github.com/user-attachments/assets/9f402717-ea46-4a05-b0b6-4b856350c191" />

<img width="378" height="403" alt="image" src="https://github.com/user-attachments/assets/992f2d99-afbd-4028-bfc0-f27a49983327" />


## 📁 Estructura de Carpetas o Directorios

```text
Parcial MVP por Capas/
│
├── README.md
├── .gitignore
├── LoginMVP.sln
├── querysParcial.sql
│
├── docs/
│   └── img/
│
├── Entidades/
│   ├── Entidades.csproj
│   ├── E_Usuario.cs
│   └── E_Producto.cs
│
├── Datos/
│   ├── Datos.csproj
│   ├── ConexionBD.cs
│   ├── D_Usuario.cs
│   └── D_Producto.cs
│
├── Negocios/
│   ├── Negocios.csproj
│   ├── Seguridad/
│   │   ├── IHashService.cs
│   │   ├── IVerificarHashService.cs
│   │   ├── ParametrosHash.cs
│   │   ├── HashService.cs
│   │   └── VerificarHashService.cs
│   └── Servicios/
│       ├── IUsuarioService.cs
│       ├── N_Usuario.cs
│       ├── IProductoService.cs
│       └── N_Producto.cs
│
└── Presentacion/
    ├── Presentacion.csproj
    ├── Program.cs
    ├── Vistas/
    │   ├── ILoginView.cs
    │   ├── IMainView.cs
    │   ├── IProductosView.cs
    │   └── IRegistroUsuarioView.cs
    ├── Presentadores/
    │   ├── LoginPresenter.cs
    │   ├── MainPresenter.cs
    │   ├── ProductosPresenter.cs
    │   └── RegistroUsuarioPresenter.cs
    └── Formularios/
        ├── FrmBienvenida.cs
        ├── FrmBienvenida.Designer.cs
        ├── FrmBienvenida.resx
        ├── FrmLogin.cs
        ├── FrmLogin.Designer.cs
        ├── FrmLogin.resx
        ├── FrmPrincipal.cs
        ├── FrmPrincipal.Designer.cs
        ├── FrmPrincipal.resx
        ├── FrmProductos.cs
        ├── FrmProductos.Designer.cs
        ├── FrmProductos.resx
        ├── FrmRegistroUsuario.cs
        ├── FrmRegistroUsuario.Designer.cs
        └── FrmRegistroUsuario.resx
```

Los directorios `.vs`, `bin` y `obj` corresponden a archivos generados por Visual Studio y por el proceso de compilación. No se incluyen en el repositorio (ver `.gitignore`).

## ▶️ Instrucciones de Instalación y Ejecución

### Requisitos

- Windows 10 u 11.
- Visual Studio 2022 con la carga de trabajo **Desarrollo de escritorio de .NET**.
- .NET 9 SDK.
- Servidor MySQL 8.x instalado y funcionando.

### Pasos

**1. Clonar el repositorio**

```bash
git clone https://github.com/[usuario]/[repositorio].git
cd [repositorio]
```

**2. Crear la base de datos**

Ejecutar el script `querysParcial.sql` con un usuario administrador de MySQL:

```bash
mysql -u root -p < querysParcial.sql
```

O abrirlo en MySQL Workbench (o desde **Solution Items** en Visual Studio, copiando su contenido) y ejecutarlo completo.

> ⚠️ El script comienza con `DROP TABLE`, por lo que elimina los datos de las tablas `usuarios` y `productos` si ya existen.

**3. Verificar la creación**

```sql
USE bd_login;
SELECT id, dsUsuario, dsRol FROM usuarios;
SHOW GRANTS FOR 'app_login'@'localhost';
```

**4. Abrir la solución**

Abrir `LoginMVP.sln` en Visual Studio. Los paquetes NuGet (`MySql.Data`) se restauran automáticamente.

**5. Establecer el proyecto de inicio**

Clic derecho en `Presentacion` → **Establecer como proyecto de inicio**.

**6. Compilar y ejecutar**

Compilar con `Ctrl + Shift + B` y ejecutar con `F5`.

### Credenciales de prueba

| Usuario | Contraseña | Rol |
|---|---|---|
| `admin` | `123456` | `ADMIN` |

Los demás usuarios se crean desde la opción **Registrar usuario** y tienen el rol `USER`.

Para convertir a otro usuario en administrador, se hace directamente en MySQL (a propósito, para que nadie pueda ascenderse desde la aplicación):

```sql
UPDATE usuarios SET dsRol = 'ADMIN' WHERE dsUsuario = 'nombre';
```

## ⚠️ Consideraciones

La cadena de conexión se construye en:

```text
Datos/ConexionBD.cs
```

Los valores por defecto son:

```text
Server=localhost
Database=bd_login
Uid=app_login
Pwd=ClaveSegura#2026
```

Para no dejar credenciales fijas en el código, estos valores pueden sobrescribirse con variables de entorno:

| Variable | Valor que reemplaza |
|---|---|
| `LOGIN_DB_SERVER` | Servidor |
| `LOGIN_DB_NAME` | Nombre de la base de datos |
| `LOGIN_DB_USER` | Usuario |
| `LOGIN_DB_PASSWORD` | Contraseña |

La contraseña por defecto y el usuario `admin` / `123456` son **solo para fines académicos**. En un proyecto real deben cambiarse y no publicarse en un repositorio público.

## 👤 Autor y Contexto

- **Nombre:** Mario Fernández Morales
- **Institución:** Universidad Tecnológica de Panamá (UTP) — Facultad de Ingeniería en Sistemas Computacionales, Campus Víctor Levi Sasso
- **Asignatura:** Herramientas de Programación Aplicadas III
- **Grupo:** 1IL133
- **Instructora:** Ing. Irina Fong
- **Fecha de Realización:** 08/11/2026

Este proyecto fue desarrollado como parte del Parcial N. 2, con el propósito de aplicar la programación por capas, el patrón MVP y buenas prácticas de seguridad en una aplicación de escritorio con C# y .NET.

## 📚 Referencias

- Microsoft Learn — Documentación oficial de C#.
- Microsoft Learn — .NET 9.
- Microsoft Learn — Windows Forms.
- Microsoft Learn — `Rfc2898DeriveBytes` (PBKDF2).
- MySQL Documentation — Stored Programs y administración de privilegios.
- Documentación de `MySql.Data` para conectividad entre C# y MySQL.
