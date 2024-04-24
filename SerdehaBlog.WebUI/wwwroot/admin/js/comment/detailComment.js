const table = $('#replyComment-table').DataTable({
    "language": {
        "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Turkish.json"
    }
});

$(function () {
    $.ajax({
        url: '/Admin/ReplyComment/GetReplyComments/',
        type: 'GET',
        dataType: 'json',
        beforeSend: function () {
            $('#spinner-data').show();
            $('.replyComment').hide();
        },
        success: function (response) {
            const parsedData = JSON.parse(response);
            if (parsedData.ResultStatus === false) {
                $('#replyCommentDiv').hide();
                $('#replyCommentTitle').hide();
                $('#spinnerButton').text('Henüz yorum yapılmamış');
            } else {
                table.clear();
                $.each(parsedData.Data.$values, (index, value) => {

                    const newTableRow = table.row.add([
                        value.CommentName,
                        value.CreatedByName,
                        moment(value.CreatedDate).fromNow(),
                        `<span class='badge badge-pill badge-${value.IsActive ? "success" : "warning"} text-white'>${value.IsActive ? "Onaylanmış" : "İncelemede"}</span>`,
                        `
                            ${value.IsActive ? '<a class="btn btn-info btn-sm m-1 text-white statusReplyComment" data-status="' + (value.IsActive ? true : false) + '" data-replyCommentId="' + value.Id + '" data-title="' + value.CreatedByName + '"><i class="fa fa-times"></i></a>' : '<a class="btn btn-success btn-sm m-1 text-white statusReplyComment" data-status="' + (value.IsActive ? true : false) + '" data-replyCommentId="' + value.Id + '" data-title="' + value.CreatedByName + '"><i class="fa fa-check"></i></a>'}
                             <a class="btn btn-warning btn-sm m-1 text-white" href="/Admin/ReplyComment/Detail?replyCommentId=${value.Id}">
                                        <i class="fa fa-edit"></i>
                             </a>
                             <a class="btn btn-danger btn-sm m-1 deleteReplyComment text-white" data-ReplyCommentId="${value.Id}" data-title="${value.CreatedByName}">
                                        <i class="fa fa-trash-o"></i>
                             </a>
                        `
                    ]).node();


                    const jqueryTableRow = $(newTableRow);
                    jqueryTableRow.attr('name', `${value.Id}`);
                });
                table.draw();
                $('#spinner-data').hide();
                $('.replyComment').show();
            }
        },
        error: function (err) {
            toastr.error(`İşlem tamamlanırken bir hata oluştu. Hata kodu : ${err.status}`, 'İşlem Başarısız!');
            $('#replyCommentDiv').hide();
            $('#spinnerButton').text(err.statusText)
        }
    })
})

$(function () {

    $(document).on('click', '.statusReplyComment', function (event) {

        event.preventDefault();
        event.stopPropagation();

        const title = $(this).data('title');
        const status = $(this).data('status');

        if (!status) {
            Swal.fire({
                title: `${title} Onaylansın Mı ?`,
                text: `${title} isimli yorum onaylanacaktır.`,
                type: "success",
                showCancelButton: true,
                confirmButtonText: "Onayla",
                confirmButtonColor: "#009000",
                cancelButtonText: "Vazgeç",
                cancelButtonColor: "#FF0000"
            }).then((result) => {
                if (result.value === true) {

                    const id = $(this).data('replycommentid');

                    $.ajax({
                        url: '/Admin/ReplyComment/Confirm/',
                        type: 'GET',
                        dataType: 'json',
                        data: { replyCommentId: id },
                        success: function (response) {

                            const parsedData = JSON.parse(response);

                            if (parsedData.ResultStatus === false) {
                                toastr.error('Yorum onaylanırken bir hata oluştu.', 'Yorum Onaylanamadı!');
                                return;
                            } else {
                                const tableRow = $(`[name="${id}"]`);
                                const updatedTableData = [
                                    parsedData.Data.CommentName,
                                    parsedData.Data.CreatedByName,
                                    moment(parsedData.Data.CreatedDate).fromNow(),                                    
                                    `<span class='badge badge-pill badge-${parsedData.Data.IsActive ? "success" : "warning"} text-white'>${parsedData.Data.IsActive ? "Onaylanmış" : "İncelemede"}</span>`,
                                    `
                                    ${parsedData.Data.IsActive ? '<a class="btn btn-info btn-sm m-1 text-white statusReplyComment" data-status="' + (parsedData.Data.IsActive ? true : false) + '" data-replyCommentId="' + parsedData.Data.Id + '" data-title="' + parsedData.Data.CreatedByName + '"><i class="fa fa-times"></i></a>' : '<a class="btn btn-success btn-sm m-1 text-white statusReplyComment" data-status="' + (parsedData.Data.IsActive ? true : false) + '" data-replyCommentId="' + parsedData.Data.Id + '" data-title="' + parsedData.Data.CreatedByName + '"><i class="fa fa-check"></i></a>'}
                                     <a class="btn btn-warning btn-sm m-1 text-white" href="/Admin/ReplyComment/Detail?replyCommentId=${parsedData.Data.Id}">
                                                <i class="fa fa-edit"></i>
                                     </a>
                                     <a class="btn btn-danger btn-sm m-1 deleteReplyComment text-white" data-replyCommentId="${parsedData.Data.Id}" data-title="${parsedData.Data.CreatedByName}">
                                                <i class="fa fa-trash-o"></i>
                                     </a>
                                `
                                ];

                                table.row(tableRow).data(updatedTableData).draw();

                                toastr.success(`${parsedData.Data.CreatedByName} kişinin yorumu başarıyla onaylandı.`, 'Yorum Başarıyla Onaylandı!');
                            }
                        },
                        error: function (err) {
                            toastr.error(`Yorum onaylanırken bir hata oluştu. ${err.responseText}`, 'Yorum Onaylanamadı!');
                        }
                    });
                }
            });
        } else {

            Swal.fire({
                title: `${title} Yorum Kaldırılsın Mı ?`,
                text: `${title} isimli yorum onayı kaldırılacaktır.`,
                type: "success",
                showCancelButton: true,
                confirmButtonText: "Onayla",
                confirmButtonColor: "#009000",
                cancelButtonText: "Vazgeç",
                cancelButtonColor: "#FF0000"
            }).then((result) => {
                if (result.value === true) {

                    const id = $(this).data('replycommentid');

                    $.ajax({
                        url: '/Admin/ReplyComment/UnConfirm/',
                        type: 'GET',
                        dataType: 'json',
                        data: { replyCommentId: id },
                        success: function (response) {

                            const parsedData = JSON.parse(response);

                            if (parsedData.ResultStatus === false) {
                                toastr.error('Yorum kaldırılırken ona bir hata oluştu.', 'Yorum Onaylanamadı!');
                                return;
                            } else {
                                const tableRow = $(`[name="${id}"]`);
                                const updatedTableData = [
                                    parsedData.Data.CommentName,
                                    parsedData.Data.CreatedByName,
                                    moment(parsedData.Data.CreatedDate).fromNow(),
                                    `<span class='badge badge-pill badge-${parsedData.Data.IsActive ? "success" : "warning"} text-white'>${parsedData.Data.IsActive ? "Onaylanmış" : "İncelemede"}</span>`,
                                    `
                                    ${parsedData.Data.IsActive ? '<a class="btn btn-info btn-sm m-1 text-white statusReplyComment" data-status="' + (parsedData.Data.IsActive ? true : false) + '" data-replyCommentId="' + parsedData.Data.Id + '" data-title="' + parsedData.Data.CreatedByName + '"><i class="fa fa-times"></i></a>' : '<a class="btn btn-success btn-sm m-1 text-white statusReplyComment" data-status="' + (parsedData.Data.IsActive ? true : false) + '" data-replyCommentId="' + parsedData.Data.Id + '" data-title="' + parsedData.Data.CreatedByName + '"><i class="fa fa-check"></i></a>'}
                                     <a class="btn btn-warning btn-sm m-1 text-white" href="/Admin/ReplyComment/Detail?replyCommentId=${parsedData.Data.Id}">
                                                <i class="fa fa-edit"></i>
                                     </a>
                                     <a class="btn btn-danger btn-sm m-1 deleteReplyComment text-white" data-replyCommentId="${parsedData.Data.Id}" data-title="${parsedData.Data.CreatedByName}">
                                                <i class="fa fa-trash-o"></i>
                                     </a>
                                `
                                ];

                                table.row(tableRow).data(updatedTableData).draw();

                                toastr.success(`${parsedData.Data.CreatedByName} kişinin yorumu başarıyla kaldırıldı.`, 'Yorum Başarıyla Kaldırıldı!');
                            }
                        },
                        error: function (err) {
                            toastr.error(`Yorum kaldırılırken bir hata oluştu. ${err.responseText}`, 'Yorum Kaldırılamadı!');
                        }
                    });
                }
            });
        }
    })
});

$(function () {
    $(document).on('click', '.deleteReplyComment', function (event) {
        event.preventDefault();
        event.stopPropagation();

        const title = $(this).data('title');

        Swal.fire({
            title: `${title} Silinsin Mi ?`,
            text: `${title} isimli yorum silinecektir.`,
            type: "warning",
            showCancelButton: true,
            confirmButtonText: "Sil",
            confirmButtonColor: "#e00434",
            cancelButtonText: "Vazgeç",
            cancelButtonColor: "#48cc44"
        }).then((result) => {
            if (result.value === true) {

                const id = $(this).data('replycommentid');

                $.ajax({
                    url: '/Admin/ReplyComment/Delete/',
                    type: 'GET',
                    dataType: 'json',
                    data: { replyCommentId: id },
                    success: function (response) {

                        const parsedData = JSON.parse(response);

                        if (parsedData.ResultStatus === false) {
                            toastr.error('Yorum silinirken bir hata oluştu.', 'Yorum Silinemedi!');
                            return;
                        } else {
                            const tableRow = $(`[name="${id}"]`);
                            table.row(tableRow).remove().draw();

                            toastr.success(`${parsedData.Data.CreatedByName} isimli kişinin yorumu başarıyla silindi.`, 'Yorum Başarıyla Silindi!');
                        }
                    },
                    error: function (err) {
                        toastr.error(`Yorum silinirken bir hata oluştu. ${err.responseText}`, 'Yorum Silinemedi!');
                    }
                });
            }
        });
    });
})