const table = $('#category-table').DataTable({
    "language": {
        "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Turkish.json"
    }
});

$(function () {

    $.ajax({
        url: '/Admin/Category/GetAllCategories/',
        type: 'GET',
        dataType: 'json',
        beforeSend: function () {
            $('#spinner-data').show();
            $('#category-table').hide();
        },
        success: function (response) {
            const parsedData = JSON.parse(response);
            console.log(parsedData);
            if (parsedData.ResultStatus === false) {
                $('#category-table').hide();
                $('#spinnerButton').text('Henüz kategori eklenilmemiş');
            } else {
                table.clear();
                $.each(parsedData.Data.$values, (index, value) => {

                    const newTableRow = table.row.add([
                        value.Name,
                        `<span class='badge badge-${value.ArticleCount <= 0 ? "danger" : "success"} text-white'>${value.ArticleCount}</span>`,
                        `<span class='badge badge-pill badge-${value.IsActive ? "success" : "danger"} text-white'>${value.IsActive ? "Aktif" : "Pasif"}</span>`,
                        `
                             <a class="btn btn-warning btn-sm m-1 text-white" href="/Admin/Category/Update?categoryId=${value.Id}">
                                        <i class="fa fa-edit"></i>
                                    </a>
                                    <a class="btn btn-danger btn-sm m-1 deleteCategory text-white" data-categoryId="${value.Id}" data-title="${value.Name}">
                                        <i class="fa fa-trash-o"></i>
                             </a>
                        `
                    ]).node();


                    const jqueryTableRow = $(newTableRow);
                    jqueryTableRow.attr('name', `${value.Id}`);
                });
                table.draw();
                $('#spinner-data').hide();
                $('#category-table').show();
            }
        },
        error: function (err) {
            toastr.error(`İşlem tamamlanırken bir hata oluştu. Hata kodu : ${err.status}`, 'İşlem Başarısız!');
        }
    })
})

$(function () {
    $(document).on('click', '.deleteCategory', function (event) {
        event.preventDefault();
        event.stopPropagation();

        const title = $(this).data('title');

        Swal.fire({
            title: `${title} Silinsin Mi ?`,
            text: `${title} isimli kategori silinecektir.`,
            type: "warning",
            showCancelButton: true,
            confirmButtonText: "Sil",
            confirmButtonColor: "#e00434",
            cancelButtonText: "Vazgeç",
            cancelButtonColor: "#48cc44"
        }).then((result) => {
            if (result.value === true) {

                const id = $(this).data('categoryid');

                $.ajax({
                    url: '/Admin/Category/Delete/',
                    type: 'GET',
                    dataType: 'json',
                    data: { categoryId: id },
                    success: function (response) {

                        const parsedData = JSON.parse(response);

                        if (parsedData.ResultStatus === false) {
                            toastr.error('Kategori silinirken bir hata oluştu.', 'Kategori Silinemedi!');
                            return;
                        } else {
                            const tableRow = $(`[name="${id}"]`);
                            table.row(tableRow).remove().draw();

                            toastr.success(`${parsedData.Data.Name} başarıyla silindi.`, 'Kategori Başarıyla Silindi!');
                        }
                    },
                    error: function (err) {
                        toastr.error(`Kategori silinirken bir hata oluştu. ${err.responseText}`, 'Kategori Silinemedi!');
                    }
                });
            }
        });
    });
})