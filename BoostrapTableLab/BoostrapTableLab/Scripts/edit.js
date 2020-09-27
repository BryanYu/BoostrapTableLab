$(function () {

    var params = new URLSearchParams(window.location.search);
    var id = params.get('id');
    var editType = "";
    InitEditPage();
    InitialEditTypes();

    $('#Update').click(function() {
        var name = $('#Name').val();
        var type = $('#Type').val();
        $.ajax({
            url: '/Home/Update',
            data: { id: id, name: name, type: type },
            method: 'post',
            success: UpdateSuccessCallBack
        });
    });
    $('#Cancel').click(function() {
        window.location.href = '/Home/Index';
    });

    function InitEditPage() {
        
        $.ajax({
            url: '/Home/GetEditData?id=' + id,
            method: 'get',
            success: GetSuccessCallBack
        });
    }
    function InitialEditTypes() {
        $.ajax({
            url: '/Home/GetSampleTypeList',
            method: 'get',
            success: InitialTypesSuccessCallBack
        });
    }
    function InitialTypesSuccessCallBack(data, textStatus, jqXHR) {
        if (data.status === 1) {
            var types = $('#Type');
            data.data.forEach(item => {
                var selected = item.Value === editType ? "selected" : "";
                types.append("<option " + selected + " value='" + item.Value + "'>" + item.Text + "</option>");
            });
        }
    }
    function GetSuccessCallBack(data, textStatus, jqXHR) {
        if (data.status === 1) {
            $('#Name').val(data.data.Name);
            editType = data.data.Type;
        }
    }
    function UpdateSuccessCallBack(data, textStauts, jqXHR) {
        if (data.status === 1) {
            alert('Update OK');
            window.location.href = '/Home/Index';
        }
    }
})