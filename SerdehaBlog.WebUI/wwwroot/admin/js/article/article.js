const table = $('#article-table').DataTable({
    "language": {
        "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Turkish.json"
    }
});

$(function () {

    $.ajax({
        url: '/Admin/Article/GetAllArticles/',
        type: 'GET',
        dataType: 'json',
        beforeSend: function () {
            $('#spinner-data').show();
            $('#article-table').hide();
        },
        success: function (response) {
            const parsedData = JSON.parse(response);
            if (parsedData.ResultStatus === false) {
                $('#article-table').hide();
                $('#spinnerButton').text('Henüz bir makale eklenilmemiş');
            } else {
                table.clear();
                $.each(parsedData.Data.$values, (index, value) => {

                    const newTableRow = table.row.add([
                        `
                            <a class="fancybox" href="/admin/img/blog/${value.ThumbnailPath}" data-fancybox="gallery">
                                <img src="/admin/img/blog/${value.ThumbnailPath}" width="50" height="50" class="rounded ml-3 shadow" alt="${value.Title}">
                            </a>
                        `,
                        value.Title,
                        value.CategoryName,
                        moment(value.Date).format('LL'),
                        `<span class="badge badge-pill badge-${value.IsActive ? "success" : "danger"} text-white">${value.IsActive ? "Paylaşıldı" : "Taslak"}</span>`,
                        `<span class="badge badge-pill badge-${value.IsCarousel ? "success" : "danger"} text-white">${value.IsCarousel ? "Evet" : "Hayır"}</span>`,
                        `
                             <a class="btn btn-warning btn-sm m-1 text-white" href="/Admin/Article/Update?articleId=${value.Id}">
                                        <i class="fa fa-edit"></i>
                                    </a>
                                    <a class="btn btn-danger btn-sm m-1 deleteArticle text-white" data-articleId="${value.Id}" data-title="${value.Title}">
                                        <i class="fa fa-trash-o"></i>
                             </a>
                        `
                    ]).node();


                    const jqueryTableRow = $(newTableRow);
                    jqueryTableRow.attr('name', `${value.Id}`);
                });
                table.draw();
                $('#spinner-data').hide();
                $('#article-table').show();

                $
            }
        },
        error: function (err) {
            toastr.error(`İşlem tamamlanırken bir hata oluştu. Hata kodu : ${err.status}`, 'İşlem Başarısız!');
        }
    })
})


$(function () {
    $('.fancybox').fancybox();
})

$(function () {
    $(document).on('click', '.deleteArticle', function (event) {
        event.preventDefault();
        event.stopPropagation();

        const title = $(this).data('title');

        Swal.fire({
            title: `${title} Silinsin Mi ?`,
            text: `${title} isimli makale silinecektir.`,
            type: "warning",
            showCancelButton: true,
            confirmButtonText: "Sil",
            confirmButtonColor: "#e00434",
            cancelButtonText: "Vazgeç",
            cancelButtonColor: "#48cc44"
        }).then((result) => {
            if (result.value === true) {

                const id = $(this).data('articleid');

                $.ajax({
                    url: '/Admin/Article/Delete/',
                    type: 'GET',
                    dataType: 'json',
                    data: { articleId: id },
                    success: function (response) {

                        const parsedData = JSON.parse(response);

                        if (parsedData.ResultStatus === false) {
                            toastr.error('Makale silinirken bir hata oluştu.', 'Makale Silinemedi!');
                            return;
                        } else {
                            const tableRow = $(`[name="${id}"]`);
                            table.row(tableRow).remove().draw();

                            toastr.success(`${parsedData.Data.Title} başarıyla silindi.`, 'Makale Başarıyla Silindi!');
                        }
                    },
                    error: function (err) {
                        toastr.error(`Makale silinirken bir hata oluştu. ${err.responseText}`, 'Makale Silinemedi!');
                    }
                });
            }
        });
    });
})