# Instrucciones para Ejecutar el Proyecto

Para ejecutar el proyecto, sigue estos pasos:

1. **Instalación de la Base de Datos**:

   - Primero, instala la base de datos que se encuentra en la carpeta `./doc/recursos`.
   - Luego, ejecuta el archivo `store-procedure.sql` ubicado en `./doc`.

2. **DML y T-SQL**:

   - La Solución de los puntos de T-SQL y las consultas DML se encuentran en el archivo `store-procedure.sql` ubicado en `./doc`.

3. **Arquitectura del Proyecto**:

   - El proyecto utiliza una arquitectura limpia (Clean Architecture), basada en los principios SOLID y el patrón CQRS.

4. **Estructura del Proyecto**:

   - **API**: Contiene la Web API.
   - **CORE**: Incluye la capa de dominio y la capa de aplicación, encargada de aplicar la lógica de negocio.
   - **Infraestructura**: Implementa la base de datos.

5. **Paso a seguir**:

   - Crear la suit de testing
   - implemetar el front-end en angular 17

## JSON de Pedido (API creación de orden con sus respectivos detalles)

documentacion de API para crear ordenes en la base de datos de ejemplo, esta api permite crear el encabezado de la orden, como sus productos asociados en el detalle de la orden.

### Ejemplo de JSON

```json
[
  {
    "empid": 1,
    "shipperid": 1,
    "shipname": "string",
    "shipaddress": "string",
    "shipcity": "string",
    "orderdate": "2025-02-06",
    "requireddate": "2025-02-06",
    "shippeddate": "2025-02-06",
    "freight": 1,
    "shipcountry": "string",
    "detailsJson": "[{\"Productid\":1,\"Unitprice\":25.5,\"Qty\":2,\"Discount\":0.1},{\"Productid\":2,\"Unitprice\":15.75,\"Qty\":3,\"Discount\":0.05}]"
  }
]
```

### Descripción de los Campos

| Campo          | Tipo   | Descripción                                                                             |
| -------------- | ------ | --------------------------------------------------------------------------------------- |
| `empid`        | Número | ID del empleado que generó el pedido.                                                   |
| `shipperid`    | Número | ID del transportista.                                                                   |
| `shipname`     | String | Nombre del destinatario del envío.                                                      |
| `shipaddress`  | String | Dirección de envío.                                                                     |
| `shipcity`     | String | Ciudad de envío.                                                                        |
| `orderdate`    | Fecha  | Fecha en la que se realizó el pedido.                                                   |
| `requireddate` | Fecha  | Fecha requerida para la entrega.                                                        |
| `shippeddate`  | Fecha  | Fecha en la que se envió el pedido.                                                     |
| `freight`      | Número | Costo del flete.                                                                        |
| `shipcountry`  | String | País de envío.                                                                          |
| `detailsJson`  | String | JSON anidado con los detalles del pedido (productos, precios, cantidades y descuentos). |

### Ejemplo de `detailsJson`

```json
[
  {
    "Productid": 1,
    "Unitprice": 25.5,
    "Qty": 2,
    "Discount": 0.1
  },
  {
    "Productid": 2,
    "Unitprice": 15.75,
    "Qty": 3,
    "Discount": 0.05
  }
]
```
