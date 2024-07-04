fetch("https://localhost:7268/api/TodoItem/GetAllCategorias")
.then(response => response.json())
.then(categorias => {

    let body = document.getElementById("selectCategoria")

    categorias.forEach(categoria => {
        body.innerHTML += `
             <option value="${categoria.id}">${categoria.nombre}</option>
            `;

    });
});

fetch("https://localhost:7268/api/TodoItem/GetAllItems")
.then(response => response.json())
.then(categorias => {

    let body = document.getElementById("selectIdentificador")

    categorias.forEach(categoria => {
        body.innerHTML += `
             <option value="${categoria.id}">${categoria.id}</option>
            `;

    });
});

document.getElementById("selectIdentificador").addEventListener("change", function () {
    let tareaSeleccionada = this.value;
        fetch(`https://localhost:7268/api/TodoItem/CategoriaXId/${tareaSeleccionada}`)
        .then(response => response.json())
            .then(name => {
                document.getElementById('InputTarea').value = name.nombreTarea;
                document.getElementById('selectCategoria').value = name.categoriaId;
            })
    });
    

    $(document).ready(function () {

        $('#btn-actualizar').click(function () {
            if ($('#form-actualizarItem').valid() == false) {
                Swal.fire({
                    title: "Error..",
                    text: "Debe completar los campos..",
                    icon: "error"
                });
            }
    
        });
    
        $('#form-actualizarItem').validate({
            rules: {
                selectIdentificador: {
                    required: true
                },
                InputTarea: {
                    required: true
                },
                selectCategoria: {
                    required: true
                }
            },
            messages: {
                selectIdentificador: {
                    required: "Error, este campo es requerido.."
                },
                InputTarea: {
                    required: "Error, este campo es requerido..",
                },
                selectCategoria: {
                    required: "Error, debe seleccionar un genero.."
                }
            },
            submitHandler: function () {
    
                const nameTarea = document.getElementById("InputTarea")
                const rbtCompleta = document.querySelector('input[name="opcionRespuesta"]:checked').value;
                const selectCategoria = document.getElementById("selectCategoria")
                const selectIdentificador = document.getElementById("selectIdentificador")
    
                fetch("https://localhost:7268/api/TodoItem/UpdateTodoItem", {
                    method: 'PUT',
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify({
                        id: selectIdentificador.value,
                        nombreTarea: nameTarea.value,
                        estaCompleta: rbtCompleta === 'true',
                        categoriaId: parseInt(selectCategoria.value, 10),
                    })
                })
                
                Swal.fire({
                    title: "Success..",
                    text: "Se cargo con éxito..",
                    icon: "success"
                }).then(() => {
                    window.location.href = "GetItems-list.html";
                });
                
            }
    
        });
    });
