//Ẩn và hiện header khi cuộn trang
var prevScrollpos = window.scrollY;

window.onscroll = function () {
    var currentScrollPos = window.scrollY;
    var header = document.querySelector('header');

    // Kiểm tra vị trí cuộn
    if (prevScrollpos > currentScrollPos) {
        header.style.top = "0"; // Hiện header khi cuộn lên
    } else {
        header.style.top = "-125.16px"; // Ẩn header khi cuộn xuống
    }
    prevScrollpos = currentScrollPos; // Cập nhật vị trí cuộn
}

//Ẩn hiện phần gợi ý tìm kiếm khi nhấn vào thanh tìm kiếm
var searchBar = document.getElementsByClassName("searchbar")[0]; // Lấy phần tử tìm kiếm đầu tiên
var searchBoxHidden = document.getElementsByClassName("search-box-hidden")[0]; // Lấy phần tử gợi ý đầu tiên

searchBar.onclick = function () {
    if (searchBoxHidden.style.display === "none" || searchBoxHidden.style.display === "") {
        searchBoxHidden.style.display = "flex"; // Chuyển sang display: flex
    } else {
        searchBoxHidden.style.display = "none"; // Chuyển sang display: none
    }
};
