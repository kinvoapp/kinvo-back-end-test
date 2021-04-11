// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var ViewModel = function () {
    var self = this;
    self.aplicacoes = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();

    self.irs = ko.observableArray();
    self.newAplicacao = {
        valor: ko.observable(),
        dataAplicacao: ko.observable(),
    }

    self.newIR = {
        valor: ko.observable(),
        dataAplicacao: ko.observable(),
        dataResgate: ko.observable(),
        ir: ko.observable(),
        lucro: ko.observable(),
        aliquota: ko.observable()
    }

    var irsUri = '/IR_Controller/';
    var aplicacoesUri = '/Aplicacao_Controller/';

    function ajaxHelper(uri, method, data) {
        self.error('');
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllAplicacoes() {
        ajaxHelper(aplicacoesUri, 'GET').done(function (data) {
            self.aplicacoes(data);
        });
    }

    self.getAplicacaoDetail = function (item) {
        ajaxHelper(aplicacoesUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    function getIR() {
        ajaxHelper(irsUri, 'GET').done(function (data) {
            self.irs(data);
        });
    }

    self.addAplicacao = function (formElement) {
        var aplicacao = {
            valor: self.newAplicacao.valor(),
            dataAplicacao: self.newAplicacao.dataAplicacao(),
        };

        ajaxHelper(aplicacoesUri, 'POST', aplicacao).done(function (item) {
            self.aplicacoes.push(item);
        });
        document.getElementById("inputPreco").value = "";
        document.getElementById("inputName").value = "";

    }

    self.addIR = function (formElement) {
        var ir_ = {
            valor: self.newIR.valor(),
            dataAplicacao: self.newIR.dataAplicacao(),
            dataResgate: self.newIR.dataResgate(),
            ir: self.newIR.ir(),
            lucro: self.newIR.lucro(),
            aliquota: self.newIR.aliquota()
        };

        ajaxHelper(irsUri, 'POST', ir_).done(function (item) {
            getIR();
        });
        document.getElementById("inputFabricante").value = "";
    }

    self.delAplicacao = function (item) {
        ajaxHelper(aplicacoesUri + item.Id, 'DELETE').done(function (data) {
            getAllAplicacoes();
        });
    }

    function delIR(item) {
        ajaxHelper(irsUri + '5', 'DELETE').done(function (data) {
            getAllAplicacoes();
        });
    }
    //delFabricante();
    getIR();
    getAllAplicacoes();
};

ko.applyBindings(new ViewModel());

function Buscar() {
    // Declare variables
    var input, filter, ul, li, a, i, txtValue;
    input = document.getElementById('inputBusca');
    filter = input.value.toUpperCase();
    ul = document.getElementById("listProdutos");
    li = ul.getElementsByTagName('li');

    // Loop through all list items, and hide those who don't match the search query
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("tag")[0];
        txtValue = a.textContent || a.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }
}
