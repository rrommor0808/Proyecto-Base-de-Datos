const express = require('express');
const sql = require('mssql');
const cors = require('cors');

const app = express();

app.use(cors());
app.use(express.json());

const dbConfig = {
    user: 'tu_usuario',
    password: 'tu_password',
    server: 'localhost',
    database: 'inventario_db',
    options: {
        encrypt: false,
        trustServerCertificate: true
    }
};

sql.connect(dbConfig)
    .then(() => console.log("Conectado a SQL Server"))
    .catch(err => console.error(err));

app.get('/articulos', async (req, res) => {
    let consulta = "SELECT * FROM articulos";
    let filtros = [];
    let request = new sql.Request();

    try {

        if (req.query.search) {
            filtros.push("nombre LIKE @search");
            request.input('search', sql.VarChar, `%${req.query.search}%`);
        }

        if (filtros.length > 0) {
            consulta += " WHERE " + filtros.join(" AND ");
        }

        if (req.query.sort === 'ASC' || req.query.sort === 'DESC') {
            consulta += ` ORDER BY nombre ${req.query.sort}`;
        }

        const resultado = await request.query(consulta);
        res.json(resultado.recordset);

    } catch (error) {
        res.status(500).send("Error al obtener los artículos");
    }
});

app.post('/articulos', async (req, res) => {

    const { nombre, imagen, stock } = req.body;

    if (!nombre || !imagen || stock == null) {
        return res.status(400).send("Todos los campos son obligatorios");
    }

    try {
        const request = new sql.Request();

        request.input('nombre', sql.VarChar, nombre);
        request.input('imagen', sql.VarChar, imagen);
        request.input('stock', sql.Int, stock);

        await request.query(`
            INSERT INTO articulos (nombre, imagen, stock)
            VALUES (@nombre, @imagen, @stock)
        `);

        res.status(201).send("Creado");

    } catch (error) {
        res.status(500).send("Error al crear el artículo");
    }
});

app.delete('/articulos/:id', async (req, res) => {

    const id = req.params.id;

    try {
        const request = new sql.Request();
        request.input('id', sql.Int, id);

        await request.query("DELETE FROM articulos WHERE id = @id");

        res.send("Eliminado");

    } catch (error) {
        res.status(500).send("Error al eliminar el artículo");
    }
});

app.listen(3000, () => {
    console.log("Servidor en puerto 3000");
});
