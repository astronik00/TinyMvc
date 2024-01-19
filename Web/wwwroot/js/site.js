// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function openReadModal(cityFrom, cityTo, recAddress, sendAddress, weight, recDate) {
    const myModal = new bootstrap.Modal(document.getElementById('readModal'), {});

    document.getElementById('cityFrom').textContent = cityFrom;
    document.getElementById('cityTo').textContent = cityTo;
    document.getElementById('recAddress').textContent = recAddress;
    document.getElementById('sendAddress').textContent = sendAddress;
    document.getElementById('weight').textContent = weight;
    document.getElementById('recDate').textContent = recDate;
    myModal.show();
}

function openSaveModal() {
    const myModal = new bootstrap.Modal(document.getElementById('saveModal'), {});
    myModal.show();
}