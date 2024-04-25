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
    $(document).on('click', '#readContact', function (event) {
        event.stopPropagation();
        event.preventDefault();

        const id = $(this).data('contactid');

        $.ajax({
            url: '/Admin/Contact/Read/',
            type: 'GET',
            dataType: 'json',
            data: { contactId: id },
            success: function (response) {
                const parsedData = JSON.parse(response);

                if (parsedData.ResultStatus === false) {
                    toastr.error('Okundu olarak işaretlenirken bir sorun oluştu.', 'Onaylanamadı!');
                    return;
                } else {
                    toastr.success(`${parsedData.Data.Name} kişinin mesajı başarıyla okundu.`, 'Mesaj Başarıyla Okundu!');
                    RefreshNavigationBar();
                    $('#readContact').fadeOut(400);
                }
            }
        })

    });
})