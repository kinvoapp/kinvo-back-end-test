var campoDataResgate = document.getElementById('data-resgate');
var botaoResgate = document.getElementById('botao-resgate');
var campoErro = document.getElementById('erro-resgate');
var bmodal = new bootstrap.Modal(document.getElementById('resgate-modal'));

campoDataResgate.addEventListener("keypress", function (evento) {
    if (evento.keyCode < 47 || evento.keyCode > 57) {
        evento.preventDefault();
    }
    var tamanho = campoDataResgate.value.length;
    if (tamanho !== 1 || tamanho !== 3) {
        if (evento.keyCode == 47) {
            evento.preventDefault();
        }
    }

    if (tamanho === 2) {
        campoDataResgate.value += '/';
    }

    if (tamanho === 5) {
        campoDataResgate.value += '/';
    }
});

botaoResgate.addEventListener("click", function (evento) {
    var Id = document.getElementById('Id').value;
    var DataResgate = document.getElementById('data-resgate').value;

    var dados = {
        Id: Id,
        DataResgate: DataResgate
    };
    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
        if (request.readyState == 4) {
            if (request.status == 200) {
                var resposta = JSON.parse(request.responseText);
                processamento_resultado(resposta);
            }
        }
    };
    request.open('POST', '/ProdutoFinanceiro/Resgatar');
    request.setRequestHeader('Content-Type', 'application/json');
    request.send(JSON.stringify(dados));
});


function processamento_resultado(retorno_json) {
    var erro = retorno_json.hasOwnProperty('Erro');
    if (erro) {
        processamento_erro(retorno_json.Erro);
    } else {
        processamento_sucesso();
    }
}

function processamento_erro(erro) {
    campoErro.innerHTML = erro;
}

function processamento_sucesso() {
    window.location.href = '/Painel';
}