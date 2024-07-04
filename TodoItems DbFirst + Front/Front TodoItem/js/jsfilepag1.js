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


$(document).ready(function () {

    $('#btn-item').click(function () {
        if ($('#form-ingresarItem').valid() == false) {
            Swal.fire({
                title: "Error..",
                text: "Debe completar los campos..",
                icon: "error"
            });
        }

    });

    $('#form-ingresarItem').validate({
        rules: {
            InputTarea: {
                required: true
            },
            selectCompleta: {
                required: true
            },
            selectCategoria: {
                required: true
            }
        },
        messages: {
            InputTarea: {
                required: "Error, este campo es requerido.."
            },
            selectCompleta: {
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

            fetch("https://localhost:7268/api/TodoItem/CreateTodoItem", {
                method: 'POST',
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
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