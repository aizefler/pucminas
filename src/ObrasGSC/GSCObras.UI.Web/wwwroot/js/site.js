// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function obraChange() {
    var obraObj = document.getElementById('obras').ej2_instances[0]; // Combobox instance
    var grid = document.getElementById('Grid').ej2_instances[0]; // Grid instance
    var ajax = new ej.base.Ajax('/Home/CarregarPagamentos?obraId=' + obraObj.value, 'GET');
    ajax.send();
    ajax.onSuccess = function (data) {
        grid.dataSource = ej.data.DataUtil.parse.parseJson(data);
        //console.log(ej.data.DataUtil.parse.parseJson(data));
        grid.refresh();
    };
}