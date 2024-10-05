
var prevScrollpos = window.scrollY;

window.onscroll = function () {
    var currentScrollPos = window.scrollY;
    var header = document.querySelector('header');

    // Kiểm tra vị trí cuộn
    console.log("Vị trí cuộn trước:", prevScrollpos, "Vị trí cuộn hiện tại:", currentScrollPos);

    if (prevScrollpos > currentScrollPos) {
        header.style.top = "0"; // Hiện header khi cuộn lên
    } else {
        header.style.top = "-150px"; // Ẩn header khi cuộn xuống
    }
    prevScrollpos = currentScrollPos; // Cập nhật vị trí cuộn
}
