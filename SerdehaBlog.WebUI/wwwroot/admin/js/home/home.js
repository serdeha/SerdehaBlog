$(function () {
    $.ajax({
        type: 'GET',
        url: '/Admin/Home/GetChartData',
        contextType: 'application/json',
        dataType: 'json',
        success: function (response) {
            const parsedData = JSON.parse(response);
            if (parsedData.ResultStatus === false) {
                console.log('false');
                return;
            } else {
                const ctx = document.getElementById('categoryChart');
                const chartLabels = [];
                const chartData = [];

                $.each(parsedData.Data.$values, function (index, value) {
                    chartLabels.push(value.CategoryName);
                    chartData.push(value.ArticleCount);
                });


                new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: chartLabels,
                        defaultFontFamily: 'Montserrat',
                        datasets: [{
                            label: 'Makale Sayısı',
                            data: chartData,
                            borderWidth: 0,
                            borderColor: ['rgba(117, 113, 249, 0.9)', 'rgba(144,	104,	190,0.9)'],
                            backgroundColor: ['rgba(117, 113, 249, 0.5)', 'rgba(144,	104,	190,0.7)']
                        }]
                    },
                    options: {
                        scales: {
                            yAxes: [{
                                ticks: {
                                    beginAtZero: true,
                                    precision: 0
                                }
                            }]
                        }
                    }
                });
            }

        },
        error: function (err) {
            console.log('Hata : ' + err.responseText);
        }
    })
});