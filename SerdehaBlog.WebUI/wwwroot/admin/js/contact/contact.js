const table = $('#contact-table').DataTable({
    "language": {
        "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Turkish.json"
    }
});

$(function () {

    $.ajax({
        url: '/Admin/Contact/GetContacts/',
        type: 'GET',
        dataType: 'json',
        beforeSend: function () {
            $('#spinner-data').show();
            $('#contact-table').hide();
        },
        success: function (response) {
            const parsedData = JSON.parse(response);
            console.log(parsedData);
            if (parsedData.ResultStatus === false) {
                $('#contact-table').hide();
                $('#spinnerButton').text('Henüz kimse mesaj iletmemiş.');
            } else {
                table.clear();
                $.each(parsedData.Data.$values, (index, value) => {

                    const newTableRow = table.row.add([
                        value.Name,
                        value.Subject,
                        value.Email,
                        `<span class='badge badge-pill badge-${value.IsRead ? "success" : "danger"} text-white'>${value.IsRead ? "Okundu" : "Okunmadı"}</span>`,
                        moment(value.CreatedDate).fromNow(),
                        `
                             <a class="btn btn-warning btn-sm m-1 text-white" href="/Admin/Iletisim/Detay?contactId=${value.Id}">
                                        <i class="fa fa-edit"></i>
                                    </a>
                                    <a class="btn btn-danger btn-sm m-1 deleteContact text-white" data-contactId="${value.Id}" data-title="${value.Name}">
                                        <i class="fa fa-trash-o"></i>
                             </a>
                        `
                    ]).node();


                    const jqueryTableRow = $(newTableRow);
                    jqueryTableRow.attr('name', `${value.Id}`);
                });
                table.draw();
                $('#spinner-data').hide();
                $('#contact-table').show();
            }
        },
        error: function (err) {
            toastr.error(`İşlem tamamlanırken bir hata oluştu. Hata kodu : ${err.status}`, 'İşlem Başarısız!');
        }
    })
})

$(function () {
    $(document).on('click', '.deleteContact', function (event) {
        event.preventDefault();
        event.stopPropagation();

        const title = $(this).data('title');

        Swal.fire({
            title: `${title} Mesajı Silinsin Mi ?`,
            text: `${title} isimli kişinin mesajı silinecektir.`,
            type: "warning",
            showCancelButton: true,
            confirmButtonText: "Sil",
            confirmButtonColor: "#e00434",
            cancelButtonText: "Vazgeç",
            cancelButtonColor: "#48cc44"
        }).then((result) => {
            if (result.value === true) {

                const id = $(this).data('contactid');

                $.ajax({
                    url: '/Admin/Contact/Delete/',
                    type: 'GET',
                    dataType: 'json',
                    data: { contactId: id },
                    success: function (response) {

                        const parsedData = JSON.parse(response);

                        if (parsedData.ResultStatus === false) {
                            toastr.error('Mesaj silinirken bir hata oluştu.', 'Mesaj Silinemedi!');
                            return;
                        } else {
                            const tableRow = $(`[name="${id}"]`);
                            table.row(tableRow).remove().draw();

                            toastr.success(`${parsedData.Data.Name} başarıyla silindi.`, 'Mesaj Başarıyla Silindi!');
                        }
                    },
                    error: function (err) {
                        toastr.error(`Mesaj silinirken bir hata oluştu. ${err.responseText}`, 'Mesaj Silinemedi!');
                    }
                });
            }
        });
    });
})