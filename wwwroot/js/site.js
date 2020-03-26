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
                        
                    })

                }              
                // data["data"].forEach(p => {
                //     p = p.id;
                //     p.value;
                //    console.log(p);
                // });         

                    document.getElementById("data").innerHTML = temp;             
 })            

 //Post

 var evento = function(event) {
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
})
.catch(error => {
    console.log(error.response)
})

 }

var meuform = document.getElementById("postdata");
meuform.addEventListener('submit', evento);


//Put

// let up = (teste) => {
//     teste.preventDefault();

//     let nomeupdate = document.getElementById('nomeupdate').value;
//     let cpfupdate = document.getElementById('cpfupdate').value;
//     let dataNascimentoupdate = new Date(document.getElementById('dataupdate').value);
//     let ufupdate = parseInt(document.getElementById('ufupdate').value);

//     axios.put('Pessoa', {
//         'data.nome' : nomeupdate,
//         'data.cpf' : cpfupdate,
//         'data.dataNascimento' : dataNascimentoupdate,
//         'data.uf' : ufupdate
//     })
//     .then(res => {
//         console.log(res)
//     })
//     .catch(error => {
//         console.log(error);
//     })
// }

