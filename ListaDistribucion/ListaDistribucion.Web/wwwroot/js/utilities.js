var disabledDays = null;
var oTable = null;
var oTableExport = null;

function validateForm(idForm) {

    $("#" + idForm + " :input[type=text], textarea").not('.email').not('.no_mayus').each(function () {
        $(this).val($(this).val().toUpperCase());
    });
     

    $("#" + idForm).validate({
        errorClass: "invalid",
        errorPlacement: function (error, element) {

            if (element.attr("type") == "radio") {
                $("#divRadio" + element.attr("id")).addClass("invalid");
            }

            if (element.attr("type") == "checkbox") {
                $("#divCheckBox" + element.attr("id")).addClass("invalid");
            }

            var elem = $(element);            
            if (element.hasClass("select2-hidden-accessible")) {
                $("#select2-" + element.attr("id") + "-container").parent().addClass("invalid");
            }
        }
    });
}

function validateFormIgnore(idForm) {

    $("#" + idForm + " :input[type=text], textarea").not('.email').not('.no_mayus').each(function () {
        $(this).val($(this).val().toUpperCase());
    });

    $("#" + idForm).validate({
        ignore: "",
        errorClass: "invalid",
        errorPlacement: function (error, element) {

            if (element.attr("type") == "radio") {
                $("#divRadio" + element.attr("id")).addClass("invalid");
            }

            if (element.attr("type") == "checkbox") {
                $("#divCheckBox" + element.attr("id")).addClass("invalid");
            }

            var elem = $(element);
            if (element.hasClass("select2-hidden-accessible")) {
                $("#select2-" + element.attr("id") + "-container").parent().addClass("invalid");
            }

            return true;
        }
    });
}

var nav4 = window.Event ? true : false;
function IsNumber(evt) {
    var key = nav4 ? (evt.which != null ? evt.which : evt.keyCode) : evt.keyCode;
    return (key <= 13 || (key >= 48 && key <= 57) || key == 44 || key == 46 || key == 190);
}

function IsNumberNeg(evt) {
    var key = nav4 ? (evt.which != null ? evt.which : evt.keyCode) : evt.keyCode;
    return (key <= 13 || (key >= 48 && key <= 57) || key == 44 || key == 46 || key == 190 || key == 45);
}

function IsSigno(evt) {
    var key = nav4 ? (evt.which != null ? evt.which : evt.keyCode) : evt.keyCode;
    return (key == 43 || key == 45 || key == 8 || key == 0);
}

function IsNumberEntero(evt) {
    var key = nav4 ? (evt.which != null ? evt.which : evt.keyCode) : evt.keyCode;
    return (key <= 13 || (key >= 48 && key <= 57));
}

function enabledForm(idForm) {

    $("#" + idForm).find('input, textarea, button, select').removeAttr('disabled');

}

function emptyFormDiv(div) {

    $("#" + div).find("input[type='text'], textarea, select").val('');

}

function emptySelect(idSelect) {

    $("#" + idSelect).empty();
    $("#" + idSelect).append("<option value = '' >Seleccione uno...</option>");
}

function customValidateRadio(idRadio) {
    $("#divRadio" + idRadio).removeClass("invalid").addClass("valid");
}

function customValidateCheck(idCheck) {
    $("#divCheckBox" + idCheck).removeClass("invalid").addClass("valid");
}

function openWindow(url, width, height, top, left) {

    var params = 'width=' + width + ', height=' + height;
    params += ', top=' + top + ', left=' + left;
    params += ', directories=no';
    params += ', location=no';
    params += ', menubar=no';
    params += ', resizable=no';
    params += ', scrollbars=no';
    params += ', status=no';
    params += ', toolbar=no';
    newwin = window.open(encodeURI(url), 'ventanaLinePos', params);
    if (window.focus) { newwin.focus() }
    return false;
}

function selectAllCheckboxDataTable(obj, nameSelect) {
    var checked_status = obj.checked;
    $('input[name=' + nameSelect + ']', oTable.fnGetNodes()).attr('checked', checked_status);
}

function selectAllCheckbox(obj, nameSelect) {

    var checked_status = obj.checked;
    $("input[name=" + nameSelect + "]").each(function () {
        this.checked = checked_status;
    });
}

function capturarQueryString() {
    var str = window.location.search.substring(1).split("&");
    var qs = null;
    for (i = 0; i < str.length; i++) {
        str = str[i].split("=");
        if (str[1] != undefined) {
            qs = str[1];
            break;
        }
    }
    return qs;
}
 
/**
 * Muestra mensaje de procesamiento. 
 * Para ser cerrado debe usarse closeNotify().
 * @param {any} msj
 */
function showLoading(msj) {
    var msjTemp = "<div class='spinner-border spinner-border-sm text-primary'></div>&nbsp;&nbsp;" + msj;
    jNotify(msjTemp, {
        MinWidth: 350, HorizontalPosition: 'center', VerticalPosition: 'top', ShowOverlay: true, ColorOverlay: '#CCCEEE',
        TimeShown: 6000000, clickOverlay: false, OpacityOverlay: 0.3
    });
}

function showSuccess(msj, timeShown) {
    var msjTemp = "<i class='fa fa-check-circle fa-lg'></i>&nbsp;&nbsp;" + msj;
    if (timeShown == null) timeShown = 500;
    jSuccess(msjTemp, {
        MinWidth: 350, HorizontalPosition: 'center', VerticalPosition: 'top', ShowOverlay: true, TimeShown: timeShown, clickOverlay: true
    });
}

function showError(msj, timeShown) {

    var msjTemp = "<i class='fa fa-exclamation-triangle fa-lg'></i>&nbsp;&nbsp;" + msj;
    if (timeShown == null) timeShown = 3500;

    
    jError(msjTemp, {
        MinWidth: 350, HorizontalPosition: 'center', VerticalPosition: 'top', ShowOverlay: false, ColorOverlay: '#CCCEEE',
        TimeShown: timeShown, clickOverlay: true, OpacityOverlay: 0.3
    });
}

/**
 * Cierra la notificación activa en la pantalla.
 * Si no se envía el tipo de notificación, busca el JNotify activo y lo remueve.
 * @param {any} tipo
 */
function closeNotify(tipo) {
    if (tipo != null) $("#" + tipo).remove();
    else $("#jNotify").remove();
    $("#jOverlay").remove();
}

function disabledRadio(nameObj) {
    $('input[name="' + nameObj + '"]').each(function (i) {
        $(this).attr("disabled", "disabled");
    });
}

function enabledRadio(nameObj) {
    $('input[name="' + nameObj + '"]').each(function (i) {
        $(this).removeAttr('disabled');
    });
}

function unselectedRadio(nameObj) {
    $('input[name="' + nameObj + '"]').prop("checked", false);
}

function unMaskPrice(idForm) {

    $("#" + idForm).find('.price').each(function () {
        var obj = this;
        if ($(obj).val() != "") {
            $(obj).val($(obj).unmask());
        }
    });
}

function sleep(milliseconds) {
    var start = new Date().getTime();
    for (var i = 0; i < 1e7; i++) {
        if ((new Date().getTime() - start) > milliseconds) {
            break;
        }
    }
}

function nationalDays(date) {
    var m = date.getMonth(), d = date.getDate(), y = date.getFullYear();

    for (i = 0; i < disabledDays.length; i++) {
        if ($.inArray((m + 1) + '-' + d + '-' + y, disabledDays) != -1) {
            return [false];
        }
    }

    return [true];
}

function diasNoLaborales(date) {
    //var noWeekend = jQuery.datepicker.noWeekends(date);
    //return noWeekend[0] ? nationalDays(date) : noWeekend;
    return nationalDays(date);
}

function formatoMoneda(number, places, symbol, thousand, decimal) {
    number = number || 0;
    places = !isNaN(places = Math.abs(places)) ? places : 2;
    symbol = symbol !== undefined ? symbol : "$";
    thousand = thousand || ",";
    decimal = decimal || ".";
    var negative = number < 0 ? "-" : "",
	    i = parseInt(number = Math.abs(+number || 0).toFixed(places), 10) + "",
	    j = (j = i.length) > 3 ? j % 3 : 0;
    return symbol + negative + (j ? i.substr(0, j) + thousand : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + thousand) + (places ? decimal + Math.abs(number - i).toFixed(places).slice(2) : "");
}

function replaceAll(text, busca, reemplaza) {
    while (text.toString().indexOf(busca) != -1)
        text = text.toString().replace(busca, reemplaza);
    return text;

}

function validateFunctionExists(nameFunction) {
    var typeFunction = eval('typeof ' + nameFunction);
    if (typeFunction == 'function') {
        return true;
    }
    return false;
}

function quitarCamposRequeridosDiv(div) {

    $("#" + div + " .required").addClass('temp_required');
    $("#" + div).find("input[type='text'], textarea, select").removeClass('required');

}

function agregarCamposRequeridosDiv(div) {

    $("#" + div + " .temp_required").addClass('required');
    $("#" + div).find("input[type='text'], textarea, select").removeClass('temp_required');

}

function validarContrasena(objPass){

    // set password variable
    var pswd = $(objPass).val();
    var error = false;

    //validate the length
    if ( pswd.length < 8 ) {
        $('#length').removeClass('valid').addClass('invalid');
        error = true;
    } else {
        $('#length').removeClass('invalid').addClass('valid');
    }

    //validate letter
    if ( pswd.match(/[A-z]/) ) {
        $('#letter').removeClass('invalid').addClass('valid');
    } else {
        $('#letter').removeClass('valid').addClass('invalid');
        error = true;
    }

    //validate capital letter
    if ( pswd.match(/[A-Z]/) ) {
        $('#capital').removeClass('invalid').addClass('valid');
    } else {
        $('#capital').removeClass('valid').addClass('invalid');
        error = true;
    }

    //validate number
    if ( pswd.match(/\d/) ) {
        $('#number').removeClass('invalid').addClass('valid');
    } else {
        $('#number').removeClass('valid').addClass('invalid');
        error = true;
    }

    $("#errorPass").val(error);

    if (error == true)
        $(objPass).removeClass('valid').addClass("invalid");
    else
        $(objPass).removeClass('invalid').addClass("valid");


}

function delAll(selOrigen, selDestino) {

    obj1 = document.getElementById(selOrigen);
    obj2 = document.getElementById(selDestino);

    var len = obj2.length - 1;
    for (i = len; i >= 0; i--) {
        if (obj2.item(i).value != "")
            obj1.appendChild(obj2.item(i));
    }

}

function addAll(selOrigen, selDestino) {

    obj1 = document.getElementById(selOrigen);
    obj2 = document.getElementById(selDestino);

    var len = obj1.length - 1;
    for (i = len; i >= 0; i--) {
        if (obj1.item(i).value != "")
            obj2.appendChild(obj1.item(i));
    }
}

function addGrupo(selOrigen, selDestino) {

    obj1 = document.getElementById(selOrigen);
    obj2 = document.getElementById(selDestino);

    var addIndex = obj1.selectedIndex;
    if (addIndex < 0)
        return;

    valor = obj1.options.item(addIndex).value; // almacenar value
    obj2.appendChild(obj1.options.item(addIndex));

}

function delGrupo(selOrigen, selDestino) {

    obj1 = document.getElementById(selOrigen);
    obj2 = document.getElementById(selDestino);

    var selIndex = obj2.selectedIndex;
    if (selIndex < 0)
        return;

    valor = obj2.options.item(selIndex).value; // almacenar value
    obj1.appendChild(obj2.options.item(selIndex));

}

function selectedInfo(obj) {

    var selectedList = document.getElementById(obj);
    var optionList = selectedList.options;
    var len = optionList.length;

    for (i = 0; i < len; i++) {
        optionList.item(i).selected = true;
    }

}

function limitAttach(tField, iType) {

    file = tField.value;

    if (iType == 1) {
        extArray = new Array(".gif", ".jpg", ".png", ".jpeg");
    }
    if (iType == 2) {
        extArray = new Array(".swf");
    }
    if (iType == 3) {
        extArray = new Array(".exe", ".sit", ".zip", ".tar", ".swf", ".mov", ".hqx", ".ra", ".wmf", ".mp3", ".qt", ".med", ".et");
    }
    if (iType == 4) {
        extArray = new Array(".mov", ".ra", ".wmf", ".mp3", ".qt", ".med", ".et", ".wav");
    }
    if (iType == 5) {
        extArray = new Array(".html", ".htm", ".shtml");
    }
    if (iType == 6) {
        extArray = new Array(".doc", ".xls", ".ppt");
    }
    if (iType == 7) {
        extArray = new Array(".gif", ".jpg", ".png", ".jpeg",".tif",".pdf");
    }
    if (iType == 8) {
        extArray = new Array(".xls", ".xlsx");
    }
    if (iType == 9) {
        extArray = new Array(".xls");
    }
    if (iType == 10) {
        extArray = new Array(".gif", ".jpg", ".png", ".jpeg");
    }

    allowSubmit = false;
    if (!file)
        return false;

    //PERMITE CARGAR TODOS LOS TIPOS DE ARCHIVO
    if (iType == -1)
        allowSubmit = true;
    else {
        while (file.indexOf("\\") != -1) file = file.slice(file.indexOf("\\") + 1);
        ext = file.slice(file.indexOf(".")).toLowerCase();

        for (var i = 0; i < extArray.length; i++) {
            if (extArray[i] == ext) {
                allowSubmit = true;
                return true;
                break;
            }
        }
    }

    if (allowSubmit) {

        var size = parseInt(tField.size);

        //DETERMINA SI HAY TAMAÑO PARA VALIDAR
        if (size > 0) {
            var sizeByte = tField.files[0].size;
            var siezekiloByte = parseInt(sizeByte / 1024);
            if (siezekiloByte > size) {
                tField.value = "";
                showError('El tamaño del archivo supera el limite permitido. Máximo(' + size + 'KB).');
                tField.focus();
                return false;
            }
        }

    } else {
        tField.value = "";
        showError("Usted sólo puede subir archivos con extensiones " + (extArray.join(" ")) + "\nPor favor seleccione un nuevo archivo.");
        tField.focus();
        return false;
    }
}

function validarRegistrosSeleccionados(objCheck) {

    var idRegistroEditar = 0;
    var totalSeleccionados = 0;
    $("input[name=" + objCheck + "]").each(function () {

        if (this.checked) {
            idRegistroEditar = this.value;
            totalSeleccionados++;
        }
    });

    var objData = {
        idRegistroSeleccionado: idRegistroEditar,
        totalSeleccionados: totalSeleccionados
    }

    return objData;
}

function formReadonly(form) {
    $("#" + form + " input").attr("readonly", "readonly");
    $("#" + form + " select").attr("disabled", "disabled");
    $("#" + form + " textarea").attr("readonly", "readonly");
    $("#" + form + " input:radio").attr("disabled", "disabled");
    $("#" + form + " input:checkbox").attr("disabled", "disabled");

    //EL NOMBRE DEL BOTON DEBE TENER LA CLASE btnSave
    $("." + form + "_btnSave").hide();
}

var DateDiff = {

    inMinutes: function (d1, d2) {
        var t2 = d2.getTime();
        var t1 = d1.getTime();
        return Math.ceil((t2 - t1) / (60000));
    },

    inDays: function (d1, d2) {
        var t2 = d2.getTime();
        var t1 = d1.getTime();

        return parseInt((t2 - t1) / (24 * 3600 * 1000));
    },

    inWeeks: function (d1, d2) {
        var t2 = d2.getTime();
        var t1 = d1.getTime();

        return parseInt((t2 - t1) / (24 * 3600 * 1000 * 7));
    },

    inMonths: function (d1, d2) {
        var d1Y = d1.getFullYear();
        var d2Y = d2.getFullYear();
        var d1M = d1.getMonth();
        var d2M = d2.getMonth();

        return (d2M + 12 * d2Y) - (d1M + 12 * d1Y);
    },

    inYears: function (d1, d2) {
        return d2.getFullYear() - d1.getFullYear();
    }
}

function dateAdd(date, interval, units) {

    var ret = new Date(date); //don't change original date
    switch (interval.toLowerCase()) {
        case 'year': ret.setFullYear(ret.getFullYear() + units); break;
        case 'quarter': ret.setMonth(ret.getMonth() + 3 * units); break;
        case 'month': ret.setMonth(ret.getMonth() + units); break;
        case 'week': ret.setDate(ret.getDate() + 7 * units); break;
        case 'day': ret.setDate(ret.getDate() + units); break;
        case 'hour': ret.setTime(ret.getTime() + units * 3600000); break;
        case 'minute': ret.setTime(ret.getTime() + units * 60000); break;
        case 'second': ret.setTime(ret.getTime() + units * 1000); break;
        default: ret = undefined; break;
    }

    return ret;
}

function createCookie(name, value, days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        var expires = "; expires=" + date.toGMTString();
    }
    else var expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function eraseCookie(name) {
    createCookie(name, "", -1);
}

function getByValue(arr, value) {

    for (var i = 0; i < arr.length; i++) {
        if (arr[i] === value)
            return true;
    }

    return false;
}

function removeItemArray(arr, value) {
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] == value) {
            arr.splice(i, 1);
            return;
        }
    }
}

function readForm(idForm) {

    var dataInfo = "";
    $("#" + idForm + " input, #" + idForm + " select").each(function () {
        var objeto = this;

        var name = this.id;
        var type = this.type;

        var value = this.value;
        if (type == "select")
            value = $("#" + this.id + " option:selected").text();

        if (value != "")
            dataInfo += name + ": " + value + "#";
    });

    return dataInfo;
}

function displayDateTime(wrapper, horaServidor) {

    var now = new Date();

    if (horaServidor != "")
        now = horaServidor;

    var months = new Array('Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre');
    var days = new Array('Domingo', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado');

    var date = now.getDate();
    var year = now.getFullYear();
    var month = now.getMonth();
    var day = now.getDay();

    var hour = now.getHours();
    var minute = now.getMinutes();
    var second = now.getSeconds();

    hour = (hour < 10) ? "0" + hour : hour;
    minute = (minute < 10) ? "0" + minute : minute;
    second = (second < 10) ? "0" + second : second;

    var datetime = days[day] + ' ' + date + ' de ' + months[month] + ' de ' + year + ' Hora: ' + hour + ':' + minute + ':' + second;
    $("#" + wrapper).text(datetime);
    window.setTimeout(function () {
        now = dateAdd(now, 'second', 1);
        displayDateTime(wrapper, now);
    }, 1000);
}

function limpiarForm(objForm) {
    $(".select2-hidden-accessible").val("").change();
    document.getElementById(objForm).reset();
}

function closeBootbox() {
    bootbox.hideAll();
}

function selectAllCheckboxType(obj) {


    var checked_status = obj.checked;
    $("input[rel='checkbox_data']").each(function () {
        this.checked = checked_status;
    });
}

function goObjHtml(obj, height, time) {

    time = time || 0;
    window.setTimeout(function () {
        $('html, body').animate({
            scrollTop: $("#" + obj).offset().top - height
        }, 100);
    }, time);
}

function deleteFieldFile(objFile, listFiles) {
    $("#" + objFile).val("");
    $("#" + listFiles).html("");
}