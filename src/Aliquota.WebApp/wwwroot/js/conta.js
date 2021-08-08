carregaConta();

function carregaConta() {
    var tabela = document.getElementById("tabela-produto");
    var valorTotal = 0.0;

    for (var i = 1; i < tabela.rows.length; i++) {
        if (tabela.rows[i].cells[1].innerText=='Resgatado') {
            valorTotal = valorTotal + ((parseFloat(tabela.rows[i].cells[2].innerHTML)
                + parseFloat(tabela.rows[i].cells[3].innerHTML)) - parseFloat(tabela.rows[i].cells[5].innerHTML));
        }
    }
    document.getElementById("valor-conta").innerHTML = valorTotal.toFixed(2);
}