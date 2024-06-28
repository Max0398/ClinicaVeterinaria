function toggleLoginMenu() {
    var menu = document.getElementById('loginMenu');
    menu.classList.toggle('show');
}

// Cerrar el menú si se hace clic fuera de él
window.onclick = function (event) {
    if (!event.target.matches('.login-icon') && !event.target.closest('.login-menu')) {
        var dropdowns = document.getElementsByClassName("login-menu");
        for (var i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
    }
};

// Función para ocultar el menú después de iniciar sesión
function hideLoginMenu() {
    var menu = document.getElementById('loginMenu');
    menu.classList.remove('show');
}
