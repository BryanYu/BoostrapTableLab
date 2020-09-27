$(function () {

    var table = $('#table');

    function operateFormatter(value, row, index) {
        return [
            '<a class="edit" href="javascript:void(0)" title="Edit">',
            '<i class="fa fa-pen"></i>',
            '</a>',
            ' ',
            '<a class="remove" href="javascript:void(0)" title="Remove">',
            '<i class="fa fa-trash"></i>',
            '</a>'
        ].join('')
    }
    var operateEvents = {
        'click .remove': Remove,
        'click .edit': Edit
    };

    table.bootstrapTable({
        columns: [
            {
                field: 'Id',
                title: '編號'
            }, {
                field: 'Name',
                title: '名稱',
            }, {
                field: 'TypeName',
                title: '類型',
            }, {
                field: 'operate',
                formatter: operateFormatter,
                events: operateEvents
            }
        ],
        url: "/Home/Get",
        clickToSelect: true
    });

    function Remove(e, value, row, index) {
        if (confirm("Are you sure delete this row?")) {
            $.ajax({
                url: '/Home/Delete',
                data: {
                    id: row.Id
                },
                method: 'post',
                success: function(data, textStatus, jqXHR) {
                    if (data.status === 1) {
                        alert("Delete OK");
                        table.bootstrapTable('refresh');
                    }
                }
            });
        }
    }

    function Edit(e, value, row, index) {
        window.location.href = "/Home/Edit?id=" + row.Id;
    }
});
    