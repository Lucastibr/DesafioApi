// Get
fetch('Pessoa/BuscarTodos').then(
    res => {
        res.json().then(
            data => {
                console.log(data);
                if(data.length > 0)
                {
                    var temp = "";
                    data.forEach((u) => {
                        temp += "<tr>";
                        temp += "<td>"+u.id+"<td>";
                        temp += "<td>"+u.nome+"<td>";
                        temp += "<td>"+u.cpf+"<td>";
                        temp += "<td>"+u.dataNascimento+"<td>";
                        temp += "<td>"+u.uf+"<td>";
                    })
                    document.getElementById("data").innerHTML = temp;
                }
            })            
 })

 //Post

document.getElementById('cadastrar').addEventListener('submit',
    submit)

    submit(event)
    event.preventDefault();

    let nome = document.getElementById('nome').value;
    let cpf = document.getElementById('cpf').value;
    let dataNascimento = document.getElementById('dataNascimento').value;
    let uf = document.getElementById('uf').value;

    fetch('Pessoa', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: { "nome": nome, "cpf": cpf, "dataNascimento": dataNascimento, "uf": uf }
    }).then((res) => res.json())
        .then((data) => console.log(data))
        .catch((error) => console.log('erro', error));
