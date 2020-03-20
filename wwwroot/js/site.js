// Get
fetch('/Pessoa/BuscarTodos').then(
    res => {
        res.json().then(
            data => {
                console.log(data);
                if(data.length > 0)
                {
                    var temp = "";
                    data.forEach((u) => {
                        temp += "<tr>";
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

 document.getElementById('cadastrar').addEventListener('submit', postData) 

 function postData(event) {
     event.PreventDefault();

let nome = document.getElementById('Nome').value;
let cpf = document.getElementById('CPF').value;
let dataNascimento = document.getElementById('DataNascimento').value;
let uf = document.getElementById('UF').value;

fetch('Pessoa', {
    Method: 'POST',
    // headers: new headers(),
    body: JSON.stringify({"Nome": nome, "CPF": cpf, "DataNascimento": dataNascimento, "UF" : uf})
}).then((res) => res.json())
.then((data) => console.log(data))
.catch((erro) => console.log('erro', erro));

 }



