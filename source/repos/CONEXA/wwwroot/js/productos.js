// Agregar familia desde el modal
document.getElementById("guardarFamilia").addEventListener("click", function () {
    const nombre = document.getElementById("nombreFamilia").value;

    if (!nombre.trim()) {
        alert("El nombre de la familia es obligatorio.");
        return;
    }

    fetch("/Productos/CrearFamilia", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ Nombre: nombre }),
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                const familiaSelect = document.getElementById("familia");
                const nuevaOpcion = document.createElement("option");
                nuevaOpcion.value = data.id;
                nuevaOpcion.text = data.nombre;
                familiaSelect.appendChild(nuevaOpcion);
                familiaSelect.value = data.id;
                $('#crearFamiliaModal').modal('hide');
                document.getElementById("nombreFamilia").value = "";
            } else {
                alert(data.message);
            }
        })
        .catch(error => console.error("Error:", error));
});

// Agregar unidad de medida desde el modal
document.getElementById("guardarUnidad").addEventListener("click", function () {
    const nombre = document.getElementById("nombreUnidad").value;

    if (!nombre.trim()) {
        alert("El nombre de la unidad de medida es obligatorio.");
        return;
    }

    fetch("/Productos/CrearUnidad", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ Nombre: nombre }),
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                const unidadSelect = document.getElementById("unidadMedida");
                const nuevaOpcion = document.createElement("option");
                nuevaOpcion.value = data.id;
                nuevaOpcion.text = data.nombre;
                unidadSelect.appendChild(nuevaOpcion);
                unidadSelect.value = data.id;
                $('#crearUnidadModal').modal('hide');
                document.getElementById("nombreUnidad").value = "";
            } else {
                alert(data.message);
            }
        })
        .catch(error => console.error("Error:", error));
});
