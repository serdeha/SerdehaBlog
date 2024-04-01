$(document).on('click', '#sendContact', function (event) {
    event.preventDefault();
    event.stopPropagation();

    const contact = {
        Name: $('#name').val(),
        Email: $('#email').val(),
        Subject: $('#subject').val(),
        Text: $('#text').val()
    }

    if (contact.Name.length != 0 && contact.Email.length != 0 && contact.Subject.length != 0 && contact.Text.length != 0) {

        $.ajax({
            type: 'POST',
            url: '/Contact/Add/',
            data: { addContactDto: contact },
            dataType: 'json',
            success: function (response) {

                console.log(response);

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
                    title: "Mesajınız Başarıyla İletildi.",
                    text: `Sn. ${response.Data.Name} mesajınız başarıyla iletilmiştir. En kısa sürede geri dönüş yapacağımdan emin olabilirsiniz.`,
                    icon: "success",
                    color: '#000000',
                    iconColor: 'rgb(254,107,120)',
                    confirmButtonColor: 'rgb(254,107,120)'
                });

                $('#contact-form').trigger('reset');
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