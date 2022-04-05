$(document).ready(function () {
    const dataTable = $('#examsTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Sınav Oluştur',
                attr: {
                    id: "btnAddExam",
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {
                }
            }
        ]

    });

});