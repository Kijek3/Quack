function redirect(url) {
    window.location.href = url;
}

var images = document.getElementsByClassName("slick-slide");

function changeColor(color) {
    for (var i = 0; i < images.length; i++) {
        images[i].style.backgroundColor = color;
    }
}