fetch("https://localhost:7268/api/TodoItem/GetAllItems")
    .then(response => response.json())
    .then(categorias => {

        let body = document.getElementsByTagName("tbody")[0]

        categorias.forEach(categoria => {
            body.innerHTML += `
                    <tr>
                        <th>${categoria.nombreTarea}</th>
                        <th>${categoria.estaCompleta}</th>
                        <th>${categoria.categoria}</th>
                    </tr>
                `;

        });
    });