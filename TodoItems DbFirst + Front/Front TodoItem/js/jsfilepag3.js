fetch("https://localhost:7268/api/TodoItem/GetTareaCategoriaSinId")
    .then(response => response.json())
    .then(categorias => {

        let body = document.getElementById("selectTarea")

        categorias.forEach(categoria => {
            body.innerHTML += `
                 <option value="${categoria.id}">${categoria.nombreTarea}</option>
                `;

            });
        });
        
        
        document.getElementById("selectTarea").addEventListener("change", function () {
        let tareaSeleccionada = this.value;
            fetch(`https://localhost:7268/api/TodoItem/GetTareaCategoria/${tareaSeleccionada}`)
            .then(response => response.json())
                .then(name => {
                    document.getElementById('InputCategoria').value = name.categoriaName;
                })
        });
        
        


        $(document).ready(function () {
        
            $('#formDelete').validate({
                rules: {
                    InputCategoria: {
                        required: true
                    },
                    selectTarea: {
                        required: true
                    },
                },
                messages: {
                    InputCategoria: {
                        required: "Error, este campo es requerido.."
                    },
                    selectTarea: {
                        required: "Error, este campo es requerido..",
                    }
                },
                submitHandler: function () {
                    let itemSelected = document.getElementById('selectTarea').value;
                    fetch(`https://localhost:7268/api/TodoItem/DeleteTodoItem/${itemSelected}`, {
                        method: 'DELETE'
                    })
                    .then(response => {
                        if (response.ok) {
                            return Swal.fire({
                                title: "Success..",
                                text: "Se elimino con éxito..",
                                icon: "success"
                            });
                        } else {
                            throw new Error('Algo salió mal con la solicitud de eliminación.');
                        }
                    })
                    .then(() => {
                        window.location.href = "GetItems-list.html";
                    })
                    .catch(error => {
                        console.error('Error:', error);
                        Swal.fire({
                            title: "Error",
                            text: "No se pudo eliminar el item.",
                            icon: "error"
                        });
                    });
                }

    });
});