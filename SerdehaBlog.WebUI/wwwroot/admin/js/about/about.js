$(function () {
    ClassicEditor
        .create(document.querySelector("#aboutEditor"))
        .catch(error => {
            console.error(error);
        });
})

$(function () {
    $('.dropify').dropify();
    $('.fancybox').fancybox();
})