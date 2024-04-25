const table = $('#comment-table').DataTable({
    "language": {
        "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Turkish.json"
    }
});

$(function () {
    $.ajax({
        url: '/Admin/Comment/GetComments/',
        type: 'GET',
        dataType: 'json',
        beforeSend: function () {
            $('#spinner-data').show();
            $('.commentTableDiv').hide();
        },
        success: function (response) {
            const parsedData = JSON.parse(response);
            if (parsedData.ResultStatus === false) {
                $('.commentTableDiv').hide();
                $('#spinnerButton').text('Henüz yorum yapılmamış');
            } else {
                table.clear();
                $.each(parsedData.Data.$values, (index, value) => {

                    const newTableRow = table.row.add([
                        value.CreatedByName,
                        moment(value.CreatedDate).fromNow(),
                        value.ArticleTitle,
                        `<span class='badge badge-pill badge-${value.ReplyCommentCount > 0 ? "success" : "warning"} text-white'>${value.ReplyCommentCount}</span>`,
                        `<span class='badge badge-pill badge-${value.IsActive ? "success" : "warning"} text-white'>${value.IsActive ? "Onaylanmış" : "İncelemede"}</span>`,
                        `
                            ${value.IsActive ? '<a class="btn btn-info btn-sm m-1 text-white statusComment" data-status="' + (value.IsActive ? true : false) + '" data-commentId="' + value.Id + '" data-title="' + value.CreatedByName + '"><i class="fa fa-times"></i></a>' : '<a class="btn btn-success btn-sm m-1 text-white statusComment" data-status="' + (value.IsActive ? true : false) + '" data-commentId="' + value.Id + '" data-title="' + value.CreatedByName + '"><i class="fa fa-check"></i></a>'}
                             <a class="btn btn-warning btn-sm m-1 text-white" href="/Admin/Comment/Detail?commentId=${value.Id}">
                                        <i class="fa fa-edit"></i>
                             </a>
                             <a class="btn btn-danger btn-sm m-1 deleteComment text-white" data-commentId="${value.Id}" data-title="${value.CreatedByName}">
                                        <i class="fa fa-trash-o"></i>
                             </a>
                        `
                    ]).node();


                    const jqueryTableRow = $(newTableRow);
                    jqueryTableRow.attr('name', `${value.Id}`);
                });
                table.draw();
                $('#spinner-data').hide();
                $('.commentTableDiv').show();
            }
        },
        error: function (err) {
            toastr.error(`İşlem tamamlanırken bir hata oluştu. Hata kodu : ${err.status}`, 'İşlem Başarısız!');
            $('#commentTableDiv').hide();
            $('#spinnerButton').text(err.statusText)
        }
    })
})

$(function () {

    $(document).on('click', '.statusComment', function (event) {

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

                    const id = $(this).data('commentid');

                    $.ajax({
                        url: '/Admin/Comment/Confirm/',
                        type: 'GET',
                        dataType: 'json',
                        data: { commentId: id },
                        success: function (response) {

                            const parsedData = JSON.parse(response);

                            if (parsedData.ResultStatus === false) {
                                toastr.error('Yorum onaylanırken bir hata oluştu.', 'Yorum Onaylanamadı!');
                                return;
                            } else {
                                const tableRow = $(`[name="${id}"]`);
                                const updatedTableData = [
                                    parsedData.Data.CreatedByName,
                                    moment(parsedData.Data.CreatedDate).fromNow(),
                                    parsedData.Data.ArticleTitle,
                                    `<span class='badge badge-pill badge-${parsedData.Data.ReplyCommentCount > 0 ? "success" : "warning"} text-white'>${parsedData.Data.ReplyCommentCount}</span>`,
                                    `<span class='badge badge-pill badge-${parsedData.Data.IsActive ? "success" : "warning"} text-white'>${parsedData.Data.IsActive ? "Onaylanmış" : "İncelemede"}</span>`,
                                    `
                                    ${parsedData.Data.IsActive ? '<a class="btn btn-info btn-sm m-1 text-white statusComment" data-status="' + (parsedData.Data.IsActive ? true : false) + '" data-commentId="' + parsedData.Data.Id + '" data-title="' + parsedData.Data.CreatedByName + '"><i class="fa fa-times"></i></a>' : '<a class="btn btn-success btn-sm m-1 text-white statusComment" data-status="' + (parsedData.Data.IsActive ? true : false) + '" data-commentId="' + parsedData.Data.Id + '" data-title="' + parsedData.Data.CreatedByName + '"><i class="fa fa-check"></i></a>'}
                                     <a class="btn btn-warning btn-sm m-1 text-white" href="/Admin/Comment/Detail?commentId=${parsedData.Data.Id}">
                                                <i class="fa fa-edit"></i>
                                     </a>
                                     <a class="btn btn-danger btn-sm m-1 deleteComment text-white" data-commentId="${parsedData.Data.Id}" data-title="${parsedData.Data.CreatedByName}">
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

                    const id = $(this).data('commentid');

                    $.ajax({
                        url: '/Admin/Comment/UnConfirm/',
                        type: 'GET',
                        dataType: 'json',
                        data: { commentId: id },
                        success: function (response) {

                            const parsedData = JSON.parse(response);

                            if (parsedData.ResultStatus === false) {
                                toastr.error('Yorum kaldırılırken bir hata oluştu.', 'Yorum Onaylanamadı!');
                                return;
                            } else {
                                const tableRow = $(`[name="${id}"]`);
                                const updatedTableData = [
                                    parsedData.Data.CreatedByName,
                                    moment(parsedData.Data.CreatedDate).fromNow(),
                                    parsedData.Data.ArticleTitle,
                                    `<span class='badge badge-pill badge-${parsedData.Data.ReplyCommentCount > 0 ? "success" : "warning"} text-white'>${parsedData.Data.ReplyCommentCount}</span>`,
                                    `<span class='badge badge-pill badge-${parsedData.Data.IsActive ? "success" : "warning"} text-white'>${parsedData.Data.IsActive ? "Onaylanmış" : "İncelemede"}</span>`,
                                    `
                                    ${parsedData.Data.IsActive ? '<a class="btn btn-info btn-sm m-1 text-white statusComment" data-status="' + (parsedData.Data.IsActive ? true : false) + '" data-commentId="' + parsedData.Data.Id + '" data-title="' + parsedData.Data.CreatedByName + '"><i class="fa fa-times"></i></a>' : '<a class="btn btn-success btn-sm m-1 text-white statusComment" data-status="' + (parsedData.Data.IsActive ? true : false) + '" data-commentId="' + parsedData.Data.Id + '" data-title="' + parsedData.Data.CreatedByName + '"><i class="fa fa-check"></i></a>'}
                                     <a class="btn btn-warning btn-sm m-1 text-white" href="/Admin/Comment/Detail?commentId=${parsedData.Data.Id}">
                                                <i class="fa fa-edit"></i>
                                     </a>
                                     <a class="btn btn-danger btn-sm m-1 deleteComment text-white" data-commentId="${parsedData.Data.Id}" data-title="${parsedData.Data.CreatedByName}">
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
    $(document).on('click', '.deleteComment', function (event) {
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

                const id = $(this).data('commentid');

                $.ajax({
                    url: '/Admin/Comment/Delete/',
                    type: 'GET',
                    dataType: 'json',
                    data: { commentId: id },
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