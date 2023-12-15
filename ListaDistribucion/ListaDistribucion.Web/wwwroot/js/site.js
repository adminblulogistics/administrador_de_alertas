function logout(urlLogout) {
    bootbox.confirm('Esta saliendo del sistema.<br/><br/>Desea continuar?.', function (result) {
        if (result) {
            showLoading("Cerrando su sesión. Espere por favor...");
            $.ajax({
                async: false,
                crossDomain: true,
                headers: {
                    "accept": "application/json",
                    "Access-Control-Allow-Origin": "*"
                },
                type: 'POST',
                url: urlLogout,
                dataType: 'json',
                data: {},
                success: function (response) {
                    $.ajax({
                        async: false,
                        type: 'POST',
                        url: pathToAction() + "/Home/Logout",
                        dataType: 'json',
                        data: {},
                        success: function (response) {
                            closeNotify();
                            showSuccess("Sesión Terminada. Espere por favor...");
                        }
                    });
                    
                }
            });
        }
    });
}

function cargarSelect(url, id, idSelect, value, param1) {

    var val = typeof (value) != 'undefined' ? value : -1;
    var param1Val = typeof (param1) != 'undefined' ? param1 : -1;
    var ids = [];

    $("#" + idSelect).empty();
    $("#" + idSelect).append("<option value = '' >Seleccione uno...</option>");

    if (id != "" && id != 0) {

        if (!Array.isArray(id)) {
            ids.push(id);
        } else{
            ids = id;
        }

        for (let i = 0; i < ids.length; i++) {
            $.ajax({
                type: 'POST',
                url: pathToAction() + '/' + url,
                data:
                {
                    id: ids[i],
                    param1: param1Val
                },
                dataType: 'json',
                success: function (result) {
                    $.each(result, function (i, item) {
                        if (val == item.value)
                            $("#" + idSelect).append("<option value = '" + item.value + "' selected='selected'>" + item.text + "</option>");
                        else
                            $("#" + idSelect).append("<option value = '" + item.value + "' >" + item.text + "</option>");
                    });
                }
            });
        }
    }
}

function cargarCheckList(url, id, idCheckList, obj, seleccionados, param1, css = '')
{
    var seleccionados = typeof (seleccionados) != 'undefined' ? seleccionados : -1;
    var param1Val = typeof (param1) != 'undefined' ? param1 : -1;

    var arraySeleccionados = seleccionados.split(',');

    $("#" + idCheckList).empty();

    if (id != "" && id != 0) {
        
        $.ajax({
            type: 'POST',
            url: pathToAction() + '/' + url,
            data:
            {
                id: id,
                param1: param1Val
            },
            dataType: 'json',
            success: function (result) {
                
                $.each(result, function (i, item) {

                    var incluido = false;

                    for (let j = 0; j < arraySeleccionados.length; j++) {
                        if (arraySeleccionados[j] == item.value)
                            incluido = true;
                    }

                    chequeado = incluido ? 'checked' : '';
                    
                    $("#" + idCheckList).append('<div class="'+css+'">' +
                        '<input type="checkbox" style="margin-left:5px; margin-right:5px;" name="'+obj+'" value="'+item.value+'" '+chequeado+' >' +
                            '<label style="margin-bottom:0px">'+item.text+'</label>' +
                    '</div> ');
                    
                });
            }
        });
    }
}

function obtenerValorRelacionado(url, id, objeto) {
    $.ajax({
        type: 'POST',
        dataType: "json",
        url: pathToAction() + '/' + url,
        data:
        {
            id: id
        },
        success: function (response) {
            $("#" + objeto).html(response.Value);
        }
    });
}

function autocompleteCustom(url, idObj, multiple) {

    var jsonData = [];
    $.getJSON(pathToAction() + url, function (data) {
        jsonData = data;

        var $input = $("#" + idObj);

        $input.typeahead({
            source: jsonData,
            autoSelect: true
        });

        $input.change(function () {
            var current = $input.typeahead("getActive");
            if (current) {

                var uid = current.uid;
                var id = current.id;
                var value = current.name;

                // Some item from your model is active!
                if (current.name == $input.val()) {

                    setTimeout(function () {

                        if (multiple) {
                            var itemsSeleccionados = $("#" + idObj + "_values").val();

                            //VALIDAMOS SI YA ESTA SELECCIONADO EL VALOR PARA NO INGRESARLO
                            if (itemsSeleccionados.search("," + id + ",") == -1) {

                                $("#" + idObj + "_values").val(itemsSeleccionados + id + ",");
                                $("#" + idObj).val("");
                                var dataSelected = "<div id='elemento_" + uid + "'>" + value + " &nbsp;&nbsp;<a href=\"javascript:quitarElemento('" + idObj + "','" + id + "', '" + uid + "');\" class='eliminar_reg'><i class='fa fa-times-circle fa-lg'></i></a></div>";
                                $("#" + idObj + "_text").append(dataSelected);
                            }
                            else {
                                $("#" + idObj).val("");
                            }
                        }
                        else {
                            $("#" + idObj + "_values").val(id);
                            $("#" + idObj).val(value);
                        }

                    }, 2);


                } else {
                    // This means it is only a partial match, you can either add a new item 
                    // or take the active if you don't want new items
                }
            } else {
                // Nothing is active so it is a new value (or maybe empty value)
            }
        });
    });
}

function quitarElemento(idObj, id, uid) {

    $("#elemento_" + uid).remove();
    var itemsSeleccionados = $("#" + idObj + "_values").val();
    $("#" + idObj + "_values").val(itemsSeleccionados.replace(id + ",", ""));

}

/**
 * / Exportar datos a excel sin la primera columna.
 * @param {any} objetoTableHtml
 * @param {any} tituloReporte
 * @param {any} idForm
 */
function exportarExcel(objetoTableHtml, tituloReporte, idForm, hideColumns) {
  debugger;
    var dataFiltros = typeof (idForm) != 'undefined' ? readForm("datos_reporte") : "";
    var oSettings = oTableExport.fnSettings();
    var base = oSettings._iDisplayLength;
    oSettings._iDisplayLength = -1;
    oTableExport.fnSetColumnVis(0, false);

    if (hideColumns) {
        for (let i = 0; i < hideColumns.length; i++) {
            oTableExport.fnSetColumnVis(hideColumns[i], false);
        }
    }

    oTableExport.fnDraw();

    window.setTimeout(function () {

        var dataExcel = $("#" + objetoTableHtml).html();

        $("#__dataExcel").val(dataExcel);
        $("#__tituloReporte").val(tituloReporte);
        $("#__filtrosReporte").val(dataFiltros);
        $("#formExport").attr("action", pathToAction() + "/Views/Excel/ExportarExcel");
        $("#formExport").submit();

        oSettings._iDisplayLength = base;
        oTableExport.fnSetColumnVis(0, true);
        oTableExport.fnDraw();

    }, 200);
}

function exportarExcelWithColumn(objetoTableHtml, tituloReporte, idForm) {

    var dataFiltros = typeof (idForm) != 'undefined' ? readForm("datos_reporte") : "";
    var oSettings = oTableExport.fnSettings();
    var base = oSettings._iDisplayLength;
    oSettings._iDisplayLength = -1;
    oTableExport.fnDraw();
    window.setTimeout(function () {

        var dataExcel = $("#" + objetoTableHtml).html();

        $("#__dataExcel").val(dataExcel);
        $("#__tituloReporte").val(tituloReporte);
        $("#__filtrosReporte").val(dataFiltros);
        $("#formExport").attr("action", pathToAction() + "/Report/ExportarExcel");
        $("#formExport").submit();

        oSettings._iDisplayLength = base;
        oTableExport.fnDraw();

    }, 200);
}

function exportarExcelFromDiv(objetoDivHtml, tituloReporte) {

    loader();
    window.setTimeout(function () {

        var dataExcel = $("#" + objetoDivHtml).html();

        $("#__dataExcel").val(dataExcel);
        $("#__tituloReporte").val(tituloReporte);
        $("#formExport").attr("action", pathToAction() + "/Report/ExportarExcelFromDiv");
        $("#formExport").submit();
        loader();
    }, 500);
}

/**
 * Muestra gif de procesamiento e inhabilita las acciones de la pantalla actual.
 * */
function loader() {
    $('.overlayCustom').toggle();
    $(".text_loading").toggle();
}

/**
 * Marca error si no se mínimo un check de la lista.
 * Parámetros: Nombre de checks que se van a validar, ID de contenedor de checks que se validan, Mensaje de error si no hay ckecks seleccionados.
 * Retorno: Si no hay check seleccionado, devuleve el mensaje de error establecido.
 * @param {any} comboCheck 
 * @param {any} comboContainer 
 * @param {any} message 
 */
function validateComboCheck(comboCheck, comboContainer) {

    let error = 0;
    
    var checks = $('[name=' + comboCheck + ']');
    var container = $('#' + comboContainer);
    var contador = 0;

    for (var i = 0; i < checks.length; i++) {
        if (checks[i].checked)
            contador++
    }

    if (contador == 0) {
        error++;
        container.addClass("invalid");
    } else {
        container.removeClass("invalid");
    }

    return error;
}

function vincularClienteSF() {

    showLoading("Enviando información. Espere por favor...");
    var strUrl = pathToAction() + "/Customer/BuscadorClienteSF";
    $.ajax({
        type: 'POST',
        url: strUrl,
        dataType: "html",
        data: {},
        mimeType: "multipart/form-data",
        cache: false,
        success: function (response) {
            closeNotify();
            var dialog = bootbox.dialog({
                title: "Buscar cliente en SalesForce",
                message: response
            });
            $(".bootbox").show().addClass("show");
        }
    });
}

function buscarOportunidadesClienteSF(idCliente, nombreCliente, isAir) {

    showLoading("Consultando información en SalesForce. Espere por favor...");
    var strUrl = pathToAction() + "/Customer/BuscadorOportunidadesClienteSF";
    $.ajax({
        type: 'POST',
        url: strUrl,
        dataType: "html",
        data: 
        {
            id_cliente_sf: idCliente,
            is_Air: isAir
        },
        mimeType: "multipart/form-data",
        cache: false,
        success: function (response) {
            closeNotify();
            var dialog = bootbox.dialog({
                title: "Buscador oportunidades registradas en SF del cliente " + nombreCliente,
                message: response
            });
            $(".bootbox").show().addClass("show");
        }
    });
}

function verOportunidad(idOportunidad,isAir) {

    showLoading("Consultando información en SalesForce. Espere por favor...");
    var strUrl = pathToAction() + "/Customer/VerOportunidad";
    $.ajax({
        type: 'POST',
        url: strUrl,
        dataType: "html",
        data:
        {
            id_oportunidad: idOportunidad,
            is_Air: isAir
        },
        mimeType: "multipart/form-data",
        cache: false,
        success: function (response) {
            closeNotify();
            var dialog = bootbox.dialog({
                title: "Oportunidad asociada",
                message: response
            });
            $(".bootbox").show().addClass("show");
        }
    });
}

function buscarCotizacionHome() {

    var idCotizacion = $("#param_buscar_cotizacion_home").val();
    if (idCotizacion != "")
    {
        loader();
        $("#content").load(pathToAction() + '/Quote/ViewQuote', { idCotizacion: idCotizacion, referer : "Home" }, function () {
            loader();
        });
    }

}

function buscarCotizacionAirHome() {

    var idCotizacion = $("#param_buscar_cotizacion_air_home").val();
    if (idCotizacion != "") {
        loader();
        $("#content").load(pathToAction() + '/QuotesAir/EditQuoteAir', { idCotizacion: idCotizacion, referer: "Home" }, function () {
            loader();
        });
    }

}


function cambiarOpcionBusqueda(idObj, tipo) {

    $("." + idObj + "_group").find(".airport").removeClass("btn-danger text-white");
    $("." + idObj + "_group").find(".seaport").removeClass("btn-danger text-white");
    $("." + idObj + "_group").find(".unlocos").removeClass("btn-danger text-white");

    $("." + idObj + "_group").find("." + tipo).addClass("btn-danger text-white");
    $("#" + idObj).val(tipo);
}




class OperacionCotizacion {
    // 1 = Modificar Estado,  2=  Modificar Vigencias
    static Aprobar = new OperacionCotizacion("Aprobar", 1 , 1);
    static Rechazar = new OperacionCotizacion("Rechazar", 2 , 1);
    static Eliminar = new OperacionCotizacion("Eliminar", 3 , 1);
    static Abrir = new OperacionCotizacion("Abrir", 4 , 1);
    static Habilitar = new OperacionCotizacion("Habilitar", 5 , 1);
    static ModificarVigencias = new OperacionCotizacion("Modificar Vigencias" , 6 , 2);
    //
    constructor(p_name, p_value, p_tipoOperacionCotizacion) {
        this.name = p_name;
        this.value = p_value;
        this.tipoOperacionCotizacion = p_tipoOperacionCotizacion;
    }
}

