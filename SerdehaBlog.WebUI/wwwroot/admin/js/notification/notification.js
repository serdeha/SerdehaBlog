const table = $('#notification-table').DataTable({
    "language": {
        "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Turkish.json"
    }
});

function RefreshNavigationBar() {
    $.ajax({
        url: '/Admin/Notification/RefreshNavigationBar/',
        type: 'GET',
        success: function (result) {

            $('#navBarResult').html(result);
        },
        error: function (xhr, status, error) {

            console.error(xhr.responseText);
        }
    });
}

$(function () {
    $.ajax({
        url: '/Admin/Notification/GetNotifications/',
        type: 'GET',
        dataType: 'json',
        beforeSend: function () {
            $('#spinner-data').show();
            $('#notificationTable-div').hide();
        },
        success: function (response) {

            const parsedData = JSON.parse(response);

            if (parsedData.ResultStatus === false) {
                $('#notificationTable-div').hide();
                $('#spinnerButton').text('Henüz bildirim yok');
            } else {
                table.clear();
                $.each(parsedData.Data.$values, (index, value) => {

                    const newTableRow = table.row.add([
                        value.Title,
                        moment(value.CreatedDate).fromNow(),
                        `<span class='badge badge-pill badge-${value.IsRead ? "success" : "warning"} text-white'>${value.IsRead ? "Okundu" : "Okunmadı"}</span>`,
                        `
                            ${value.IsRead ? '<a class="btn btn-info btn-sm m-1 text-white statusNotification" data-status="' + (value.IsRead ? true : false) + '" data-notificationId="' + value.Id + '" data-title="' + value.Title + '"><i class="fa fa-times"></i></a>' : '<a class="btn btn-success btn-sm m-1 text-white statusNotification" data-status="' + (value.IsRead ? true : false) + '" data-notificationId="' + value.Id + '" data-title="' + value.Title + '"><i class="fa fa-check"></i></a>'}                            
                             <a class="btn btn-danger btn-sm m-1 deleteNotification text-white" data-notificationId="${value.Id}" data-title="${value.Title}">
                                        <i class="fa fa-trash-o"></i>
                             </a>
                        `
                    ]).node();


                    const jqueryTableRow = $(newTableRow);
                    jqueryTableRow.attr('name', `${value.Id}`);
                });
                table.draw();
                $('#spinner-data').hide();
                $('#notificationTable-div').show();
            }
        },
        error: function (err) {
            toastr.error(`İşlem tamamlanırken bir hata oluştu. Hata kodu : ${err.status}`, 'İşlem Başarısız!');
            $('#notificationTable-div').hide();
            $('#spinnerButton').text(err.statusText)
        }
    })
})

$(function () {

    $(document).on('click', '.statusNotification', function (event) {

        event.preventDefault();
        event.stopPropagation();

        const title = $(this).data('title');
        const status = $(this).data('status');

        if (!status) {
            Swal.fire({
                title: `${title} Onaylansın Mı ?`,
                text: `${title} isimli bildirim onaylanacaktır.`,
                type: "success",
                showCancelButton: true,
                confirmButtonText: "Onayla",
                confirmButtonColor: "#009000",
                cancelButtonText: "Vazgeç",
                cancelButtonColor: "#FF0000"
            }).then((result) => {
                if (result.value === true) {

                    const id = $(this).data('notificationid');

                    $.ajax({
                        url: '/Admin/Notification/Confirm/',
                        type: 'GET',
                        dataType: 'json',
                        data: { notificationId: id },
                        success: function (response) {

                            const parsedData = JSON.parse(response);

                            if (parsedData.ResultStatus === false) {
                                toastr.error('Bildirim onaylanırken bir hata oluştu.', 'Bildirim Onaylanamadı!');
                                return;
                            } else {
                                const tableRow = $(`[name="${id}"]`);
                                const updatedTableData = [
                                    parsedData.Data.Title,
                                    moment(parsedData.Data.CreatedDate).fromNow(),
                                    `<span class='badge badge-pill badge-${parsedData.Data.IsRead ? "success" : "warning"} text-white'>${parsedData.Data.IsRead ? "Okundu" : "Okunmadı"}</span>`,
                                    `
                                        ${parsedData.Data.IsRead ? '<a class="btn btn-info btn-sm m-1 text-white statusNotification" data-status="' + (parsedData.Data.IsRead ? true : false) + '" data-notificationId="' + parsedData.Data.Id + '" data-title="' + parsedData.Data.Title + '"><i class="fa fa-times"></i></a>' : '<a class="btn btn-success btn-sm m-1 text-white statusNotification" data-status="' + (parsedData.Data.IsRead ? true : false) + '" data-notificationId="' + parsedData.Data.Id + '" data-title="' + parsedData.Data.Title + '"><i class="fa fa-check"></i></a>'}                            
                                         <a class="btn btn-danger btn-sm m-1 deleteNotification text-white" data-notificationId="${parsedData.Data.Id}" data-title="${parsedData.Data.Title}">
                                                    <i class="fa fa-trash-o"></i>
                                         </a>
                                    `
                                ];

                                table.row(tableRow).data(updatedTableData).draw();

                                RefreshNavigationBar();

                                toastr.success(`${parsedData.Data.Title} bildirimi başarıyla onaylandı.`, 'Bildirim Başarıyla Onaylandı!');
                            }
                        },
                        error: function (err) {
                            toastr.error(`Bildirim onaylanırken bir hata oluştu. ${err.responseText}`, 'Bildirim Onaylanamadı!');
                        }
                    });
                }
            });
        } else {

            Swal.fire({
                title: `Bildirim Durumu Değişecek, Emin misin ?`,
                text: `${title} bildirim durumu değişecektir.`,
                type: "success",
                showCancelButton: true,
                confirmButtonText: "Onayla",
                confirmButtonColor: "#009000",
                cancelButtonText: "Vazgeç",
                cancelButtonColor: "#FF0000"
            }).then((result) => {
                if (result.value === true) {

                    const id = $(this).data('notificationid');

                    $.ajax({
                        url: '/Admin/Notification/UnConfirm/',
                        type: 'GET',
                        dataType: 'json',
                        data: { notificationId: id },
                        success: function (response) {

                            const parsedData = JSON.parse(response);

                            if (parsedData.ResultStatus === false) {
                                toastr.error('Bildirim durumu değişirken bir hata oluştu.', 'Bildirim Durumu Değiştirlemedi!');
                                return;
                            } else {
                                const tableRow = $(`[name="${id}"]`);
                                const updatedTableData = [
                                    parsedData.Data.Title,
                                    moment(parsedData.Data.CreatedDate).fromNow(),
                                    `<span class='badge badge-pill badge-${parsedData.Data.IsRead ? "success" : "warning"} text-white'>${parsedData.Data.IsRead ? "Okundu" : "Okunmadı"}</span>`,
                                    `
                                        ${parsedData.Data.IsRead ? '<a class="btn btn-info btn-sm m-1 text-white statusNotification" data-status="' + (parsedData.Data.IsRead ? true : false) + '" data-notificationId="' + parsedData.Data.Id + '" data-title="' + parsedData.Data.Title + '"><i class="fa fa-times"></i></a>' : '<a class="btn btn-success btn-sm m-1 text-white statusNotification" data-status="' + (parsedData.Data.IsRead ? true : false) + '" data-notificationId="' + parsedData.Data.Id + '" data-title="' + parsedData.Data.Title + '"><i class="fa fa-check"></i></a>'}                            
                                         <a class="btn btn-danger btn-sm m-1 deleteNotification text-white" data-notificationId="${parsedData.Data.Id}" data-title="${parsedData.Data.Title}">
                                                    <i class="fa fa-trash-o"></i>
                                         </a>
                                    `
                                ];

                                table.row(tableRow).data(updatedTableData).draw();

                                RefreshNavigationBar();

                                toastr.success(`${parsedData.Data.Title} bildirim durumu başarıyla değişti.`, 'Bildirim Durumu Değişti!');                                
                            }
                        },
                        error: function (err) {
                            toastr.error(`Bildirim durumu değiştirilirken bir hata oluştu. ${err.responseText}`, 'Bildirim Durumu Değiştirilemedi!');
                        }
                    });
                }
            });

        }
    })
});


$(function () {
    $(document).on('click', '.deleteNotification', function (event) {
        event.preventDefault();
        event.stopPropagation();

        const title = $(this).data('title');

        Swal.fire({
            title: `${title} Bildirimi Silinsin Mi ?`,
            text: `${title} isimli bildirim silinecektir.`,
            type: "warning",
            showCancelButton: true,
            confirmButtonText: "Sil",
            confirmButtonColor: "#e00434",
            cancelButtonText: "Vazgeç",
            cancelButtonColor: "#48cc44"
        }).then((result) => {
            if (result.value === true) {

                const id = $(this).data('notificationid');

                $.ajax({
                    url: '/Admin/Notification/Delete/',
                    type: 'GET',
                    dataType: 'json',
                    data: { notificationId: id },
                    success: function (response) {

                        const parsedData = JSON.parse(response);

                        if (parsedData.ResultStatus === false) {
                            toastr.error('Bildirim silinirken bir hata oluştu.', 'Bildirim Silinemedi!');
                            return;
                        } else {
                            const tableRow = $(`[name="${id}"]`);
                            table.row(tableRow).remove().draw();

                            toastr.success(`${parsedData.Data.Title} isimli bildirim başarıyla silindi.`, 'Bildirim Silindi!');
                        }
                    },
                    error: function (err) {
                        toastr.error(`Bildirim silinirken bir hata oluştu. ${err.responseText}`, 'Bildirim Silinemedi!');
                    }
                });
            }
        });
    });
})
