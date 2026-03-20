const API_URL = "http://localhost:5111/api/articulos";

const params = new URLSearchParams(window.location.search);
const editId = params.get("id");

async function cargarArticuloEditar() {
    if (!editId) return;

    const res = await fetch(`${API_URL}/${editId}`);
    const art = await res.json();

    document.getElementById("tituloForm").textContent = "EDITAR ARTÍCULO";
    document.getElementById("id").value = art.id;
    document.getElementById("nombre").value = art.nombre;
    document.getElementById("stock").value = art.stock;

    const preview = document.getElementById("preview");
    preview.src = "http://localhost:5111" + art.imagen;
    preview.style.display = "block";
}

if (document.getElementById("btnGuardar")) {
    document.getElementById("btnGuardar").onclick = async () => {

        const id = document.getElementById("id").value;
        const nombre = document.getElementById("nombre").value;
        const stock = document.getElementById("stock").value;
        const archivo = document.getElementById("imagenArchivo").files[0];

        const formData = new FormData();
        formData.append("nombre", nombre);
        formData.append("stock", stock);

        if (archivo) formData.append("imagen", archivo);

        const method = id ? "PUT" : "POST";
        const url = id ? `${API_URL}/${id}` : API_URL;

        await fetch(url, {
            method,
            body: formData
        });

        window.location.href = "index.html";
    };
}

window.editar = function (id) {
    window.location.href = `nuevo.html?id=${id}`;
};

window.eliminarArticulo = async function (id) {
    if (!confirm("¿Borrar definitivamente?")) return;
    await fetch(`${API_URL}/${id}`, { method: "DELETE" });
    cargar();
};

if (document.getElementById("btnBuscar"))
    document.getElementById("btnBuscar").onclick = cargar;

if (document.getElementById("btnFiltrar"))
    document.getElementById("btnFiltrar").onclick = cargar;

if (document.getElementById("busqueda")) {
    document.getElementById("busqueda").addEventListener("keydown", e => {
        if (e.key === "Enter") cargar();
    });
}

if (document.getElementById("btnNuevo")) {
    document.getElementById("btnNuevo").onclick = () => {
        window.location.href = "nuevo.html";
    };
}

async function cargar() {
    if (!document.getElementById("grid")) return;

    const busqueda = document.getElementById("busqueda").value;
    const orden = document.getElementById("orden").value;

    const res = await fetch(`${API_URL}?busqueda=${encodeURIComponent(busqueda)}&orden=${orden}`);
    const datos = await res.json();

    document.getElementById("grid").innerHTML = datos.map(a => `
        <div class="card">
            <img src="http://localhost:5111${a.imagen}" alt="">
            <h3>${a.nombre}</h3>
            <p>Disponibles: <strong>${a.stock}</strong></p>
            <button onclick="editar(${a.id})">EDITAR</button>
            <button onclick="eliminarArticulo(${a.id})">ELIMINAR</button>
        </div>
    `).join("");
}

cargarArticuloEditar();

cargar();
