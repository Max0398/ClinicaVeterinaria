$(document).ready(function () {
    // Añadir transiciones suaves al abrir y cerrar los dropdowns
    $('.dropdown').on('show.bs.dropdown', function () {
        $(this).find('.dropdown-menu').first().stop(true, true).slideDown(150);
    });

    // Solución para mantener abierto el menú desplegable al hacer clic en un enlace dentro del menú
    $('.dropdown').on('click', function (e) {
        if ($(this).hasClass('show')) {
            $(this).find('.dropdown-menu').first().stop(true, true).slideUp(150);
        } else {
            $(this).find('.dropdown-menu').first().stop(true, true).slideDown(150);
        }
        $(this).toggleClass('show');
    });

    // Añadir clase activa al elemento de menú seleccionado
    var currentLocation = location.pathname;
    $('.navbar-nav a').each(function () {
        var link = $(this).attr('href');
        if (currentLocation.indexOf(link) !== -1) {
            $(this).closest('li').addClass('active');
            if ($(this).closest('.dropdown-menu').length) {
                $(this).closest('.dropdown').addClass('active');
                $(this).closest('.dropdown').addClass('show'); // Mostrar el menú desplegable activo
            }
        }
    });
});