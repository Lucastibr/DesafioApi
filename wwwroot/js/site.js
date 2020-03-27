//Get
let dados = axios.get('Pessoa/BuscarTodos');
dados.then(
            data => {
                console.log(data["data"]);
                if(data["data"].length > 0)
                {
                   var temp = ""; 
                    data["data"].forEach((u) => {
                        temp += "<tr>";
                        temp += "<td>"+u.id+"<td>";
                        temp += "<td>"+u.nome+"<td>";
                        temp += "<td>"+u.cpf+"<td>";
                        temp += "<td>"+u.dataNascimento+"<td>";
                        temp += "<td>"+u.uf+"<td>";
                        temp += "<td><button id='btEditar' class='btn btn-info' input type='submit' data-toggle='modal' data-target='#mymodal'>Editar</button><td>";
                        temp += "<td><button id='btExcluir' class='btn btn-danger' type='button' onclick='excluirPessoa("+ u.id +")'>Excluir</button><td>";                       
                    })

                }             

                    document.getElementById("data").innerHTML = temp;                              
 })     

//Post
let evento = function(event) {
    event.preventDefault();

let nome = document.getElementById('nome').value;
let cpf = document.getElementById('cpf').value;
let dataNascimento = new Date(document.getElementById('dataNascimento').value);
let uf = parseInt(document.getElementById('uf').value);

axios.post('Pessoa', {  
        'nome': nome,
        'cpf': cpf,
        'dataNascimento': dataNascimento,
        'uf': uf
    }
)
.then(response => {
    console.log(response)
    location.reload ? location.reload() : location = location;
})
.catch(error => {
    console.log(error.response)
})

 }
let meuform = document.getElementById("postdata");
meuform.addEventListener('submit', evento);

//Put
let editarPessoa = function(event) { 
    event.preventDefault();

let nomeupdate = document.getElementById('nomeupdate').value;
let cpfupdate = document.getElementById('cpfupdate').value;
let dataupdate = new Date(document.getElementById('dataupdate').value);
let ufupdate = parseInt(document.getElementById('ufupdate').value);

    const url = 'Pessoa/'
    axios.put(url, {
        'nome' : nomeupdate,
        'cpf' : cpfupdate,
        'dataNascimento' : dataupdate,
        'uf' : ufupdate
    })
    .then(res => {
        console.log(res);
    })
    .catch(error => {
        console.log(error)
    }) 
}

window.onload = function() {
	let form = document.getElementById("mymodal");
	form.addEventListener('submit', editarPessoa);
};

//Delete
function excluirPessoa(id) {
	const url = 'Pessoa/'+id
    axios.delete(url)
	.then(res => {
        console.log(res)
        location.reload ? location.reload() : location = location;
    })
    .catch(error => {
        console.log(error)
    });
}