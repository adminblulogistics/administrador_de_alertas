var segundosID = null;
var idIntervalSession = null;
var idActivarSessionAuto = null;

$(document).ready(function () {
    idIntervalSession = window.setInterval("validarInactividad()", 60003);
});

function validarInactividad() {

    var now = new Date();
    var minutesDiff = DateDiff.inMinutes(now, utcTimeExpireSession);
    console.log(now + " - " + utcTimeExpireSession + " - " + minutesDiff);
    if (minutesDiff <= 0) {
        window.clearInterval(idIntervalSession);
        window.clearTimeout(segundosID);
        $("#msj_session").fadeOut(500, function () {
            showLoading("Cerrando su sesión. Espere por favor...");
            var stUrl = pathToAction() + '/Home/LogoutAuto?expired=true';
            window.location.href = stUrl;
        });
    }

    if (minutesDiff == 1) {
        $("#segundos").text(60);
        $("#msj_session").fadeIn(1000);
        mostrarSegundosInactividad();
    }

}

function activarSession(general) {

    if (general == 0) {
        window.clearInterval(idIntervalSession);
        window.clearTimeout(segundosID);
    }

    var stUrl = pathToAction() + '/Base/ActualizarSession';
    $.ajax({
        type: 'POST',
        data: {},
        url: stUrl,
        success: function (response) {
            if (response.success) {
                utcTimeExpireSession = new Date(response.anio, (response.mes - 1), response.dia, response.hora, response.minutos);
                $("#segundos").text(60);
                $("#msj_session").fadeOut(800);
                if (general == 0) {
                    idIntervalSession = window.setInterval("validarInactividad()", 60003);
                    console.log("Session active auto");
                }
            }
        }
    });
}

function mostrarSegundosInactividad() {

    var segundos = $("#segundos");

    if (parseInt(segundos.text()) <= 0) {
        window.clearTimeout(segundosID);
        showLoading("Cerrando su sesión. Espere por favor...");
        $("#msj_session").fadeOut(500, function () {            
            var stUrl = pathToAction() + '/Home/LogoutAuto?expired=true';
            window.location.href = stUrl;
        });
    }
    else
        segundos.text(parseInt(segundos.text()) - 1);

    segundosID = window.setTimeout("mostrarSegundosInactividad()", 1000);
    return true;
}

function obtenerHoraServidor() {

    var utcServer;
    var stUrl = pathToAction() + '/Base/ActualizarSession';
    $.ajax({
        type: 'POST',
        data: {},
        url: stUrl,
        success: function (response) {
            utcServer = new Date(response.anio, (response.mes - 1), response.dia, response.hora, response.minutos, response.segundos);
            displayDateTime('hora', utcServer);
        }
    });
    return true;
}


