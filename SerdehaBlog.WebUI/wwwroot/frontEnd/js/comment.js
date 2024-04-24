$(function () {
    $('#buttonBlock').html(`
        <button type="button" id="btnSendComment" class="btn btn-default">Yorum Yap</button>
    `);
})


$(document).on('click', '#btnSendComment', function (event) {
    event.preventDefault();
    event.stopPropagation();

    const comment = {
        CreatedByName: $('#CreatedByName').val(),
        Text: $('#Text').val(),
        ArticleId: $('#articleNumber').val()
    }

    if (comment.ArticleId > 0 && comment.Text.length != 0 && comment.CreatedByName.length != 0) {
        $.ajax({
            type: 'POST',
            url: '/Comment/Add/',
            data: { addCommentDto: comment },
            dataType: 'json',
            success: function (response) {

                if (response.resultStatus === false) {
                    Swal.fire({
                        title: "Lütfen Boş Alanları Doldurunuz.",
                        html: `<p class='text text-danger'>${response.errorMessages}<p>`,
                        icon: "error",
                        color: '#000000',
                        iconColor: 'rgb(254,107,120)',
                        confirmButtonColor: 'rgb(254,107,120)'
                    });

                    return;
                }


                Swal.fire({
                    title: "Yorumunuz Başarıyla İletildi.",
                    text: `Sn. ${response.Data.CreatedByName} yorumunuz başarıyla iletilmiştir. Onay işleminden sonra mesajınız görüntülenebilecektir.`,
                    icon: "success",
                    color: '#000000',
                    iconColor: 'rgb(254,107,120)',
                    confirmButtonColor: 'rgb(254,107,120)'
                });

                $('#comment-form').trigger('reset');

                const newComment = `
                    <li class="comment rounded bg-light">
                        <div class="thumb">
                            <img src="/blog/images/other/comment-1.png" alt="${response.Data.CreatedByName}">
                        </div>
                        <div class="details">
                            <div class="row">
                                <div class="col-md-10">
                                    <h4 class="name"><a href="javascript:void(0)">${response.Data.CreatedByName}</a></h4>
                                </div>
                                <div class="col-md-2">
                                    <b>İncelemede</b>
                                </div>
                            </div>  
                            <span class="date">${moment(response.Data.CreatedDate).format('LL')}</span>
                            <p>${response.Data.Text}</p>
                        </div>
                    </li>
                `;
                $('#commentList').append(newComment);
            },
            error: function (err) {
                Swal.fire({
                    title: "Bir Hata Oluştu!",
                    text: `Hata detayları : ${err.responseText}`,
                    icon: "error",
                    color: '#000000',
                    iconColor: 'rgb(254,107,120)',
                    confirmButtonColor: 'rgb(254,107,120)'
                });
            }
        })
    } else {

        Swal.fire({
            title: "Boş Alanları Doldurunuz!",
            text: `Lütfen tüm alanları doldurduğunuzdan emin olunuz.`,
            icon: "error",
            color: '#000000',
            iconColor: 'rgb(254,107,120)',
            confirmButtonColor: 'rgb(254,107,120)'
        });
    }    
})


$(document).on('click', '#replyComment', function (event) {
    event.preventDefault();
    event.stopPropagation();    

    $('#buttonBlock').html(`
        <button type="button" data-commentid="${$(this).data('commentid')}" id="btnReplyComment" class="btn btn-default">Cevap Ver</button>
    `);

    $('#btnSendComment').fadeOut(100);
    $('#btnReplyComment').fadeIn(100);
    $('#replyCommentNameDiv').fadeIn(1500);
    $('#replyCommentName').text(`Cevaplanıyor : ${$(this).data('name')}`);
})

$(document).on('click', '#removeReplyUser', function (event) {
    event.preventDefault();
    event.stopPropagation();

    $('#btnReplyComment').fadeOut(100);
    $('#replyCommentNameDiv').fadeOut();
    $('#replyCommentName').text("");
    $('#buttonBlock').html(`
        <button type="button" id="btnSendComment" class="btn btn-default">Yorum Yap</button>
    `);   
})


$(document).on('click', '#btnReplyComment', function (event) {
    event.preventDefault();
    event.stopPropagation();

    const replyComment = {
        CreatedByName: $('#CreatedByName').val(),
        Text: $('#Text').val(),
        CommentId: $(this).data('commentid')
    }

    if (replyComment.CreatedByName.length != 0 && replyComment.CommentId > 0 && replyComment.Text.length != 0) {

        $.ajax({
            type: 'POST',
            url: '/Comment/ReplyComment',
            data: { addReplyCommentDto: replyComment },
            dataType: 'json',
            success: function (response) {

                if (response.resultStatus === false) {
                    Swal.fire({
                        title: "Lütfen Boş Alanları Doldurunuz.",
                        html: `<p class='text text-danger'>${response.errorMessages}<p>`,
                        icon: "error",
                        color: '#000000',
                        iconColor: 'rgb(254,107,120)',
                        confirmButtonColor: 'rgb(254,107,120)'
                    });

                    return;
                }

                Swal.fire({
                    title: "Yanıtınız Başarıyla İletildi.",
                    text: `Sn. ${response.Data.Text} yanıtınız başarıyla iletilmiştir. Onay işleminden sonra yanıtınız görüntülenebilecektir.`,
                    icon: "success",
                    color: '#000000',
                    iconColor: 'rgb(254,107,120)',
                    confirmButtonColor: 'rgb(254,107,120)'
                });

                $('#comment-form').trigger('reset');
            },
            error: function (err) {
                Swal.fire({
                    title: "Bir Hata Oluştu!",
                    text: `Hata detayları : ${err.responseText}`,
                    icon: "error",
                    color: '#000000',
                    iconColor: 'rgb(254,107,120)',
                    confirmButtonColor: 'rgb(254,107,120)'
                });
            }

        })
    } else {
        Swal.fire({
            title: "Boş Alanları Doldurunuz!",
            text: `Lütfen tüm alanları doldurduğunuzdan emin olunuz.`,
            icon: "error",
            color: '#000000',
            iconColor: 'rgb(254,107,120)',
            confirmButtonColor: 'rgb(254,107,120)'
        });
    }
})