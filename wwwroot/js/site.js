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

                    document.getElementById("data").innerHTML = temp;
                }
 })            

 //Post

 var evento = function(event) {
     event.preventDefault();

let nome = document.getElementById('nome').value;
let cpf = document.getElementById('cpf').value;
let dataNascimento = document.getElementById('dataNascimento').value;
let uf = document.getElementById('uf').value;

console.log(nome);
console.log(cpf);
console.log(dataNascimento);
console.log(uf);

     
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



