'use strict'

 const openModal = () => document.getElementById('modal')
    .classList.add('active')

const closeModal = () => document.getElementById('modal')
    .classList.remove('active')

document.getElementById('cadastrarCliente')
     .addEventListener('click', openModal)

document.getElementById('modalClose')
     .addEventListener('click', closeModal)

const form = document.getElementById("form-dados");
const tabela = document.querySelector('#tabela-dados tbody');

// Função para carregar os dados na tabela
function carregarDados() {

  fetch("https://localhost:7031/api/cliente")
  .then(response => response.json())
  .then(data => {
  // Limpa a tabela antes de preenchê-la novamente
      tabela.innerHTML = "";

      // Percorre os dados recebidos e cria as linhas e células da tabela dinamicamente
        // Preenche a tabela com os dados recebidos da API
        data.forEach(dado => {
          const tr = document.createElement("tr");
          const tdNome = document.createElement("td");
          const tdEmail = document.createElement("td");
          const tdTelefone = document.createElement("td");
          const tdCidade = document.createElement("td");

          tdNome.textContent = dado.nome;
          tdEmail.textContent = dado.email;
          tdTelefone.textContent = dado.telefone;
          tdCidade.textContent = dado.cidade;

          tr.appendChild(tdNome);
          tr.appendChild(tdEmail);
          tr.appendChild(tdTelefone);
          tr.appendChild(tdCidade);

          tabela.appendChild(tr);
      });
  })
  .catch(error => {
  // Exibe uma mensagem de erro caso ocorra algum problema na requisição
  console.error(error.message);
  });
}

// Carrega os dados na tabela quando a página é carregada
document.addEventListener("DOMContentLoaded", carregarDados);

// Adiciona o evento de submit ao formulário
form.addEventListener("submit", cadastrarDados);



//  const xhr = new XMLHttpRequest();
//  xhr.open('GET', 'https://localhost:7031/api/cliente');
//  xhr.setRequestHeader('Authorization', 'Bearer ');

//  let clientes 
//  xhr.onload = function() {
//     if (xhr.status === 200) {
//        const data = JSON.parse(xhr.responseText);
//        clientes = data
//      } else {
//        console.error('Erro ao receber dados:', xhr.status);
//      }
//    };

//  xhr.send();



//  const list = document.createElement('ul');

// // Itera sobre o array de itens
// clientes.forEach(item => {
//    // Cria um novo elemento li para cada item
//   const listItem = document.createElement('li');
//   listItem.textContent = item.name;
//      // Adiciona o novo elemento li ao elemento ul
//   list.appendChild(listItem);
//  });

// // Adiciona o elemento ul ao elemento com id="container"
//  document.getElementById('container').appendChild(list);
