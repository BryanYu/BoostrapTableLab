$(function () {
    InitialTypes();
    
    $('#Insert').click(function () {
        var name = $('#Name').val();
        var type = $('#Type').val();
        $.ajax({
            url: '/Home/Insert',
            data: { name: name, type: type },
            method: 'post',
            success: SuccessCallBack
        });
    });
    $('#Cancel').click(function() {
        window.location.href = "/Home/Index";
    });

    function InitialTypes() {
        $.ajax({
            url: '/Home/GetSampleTypeList',
            method:'get',
            success: InitialTypesSuccessCallBack
        });
    }
    function InitialTypesSuccessCallBack(data, textStatus, jqXHR) {
        if (data.status === 1) {
            var types = $('#Type');
            data.data.forEach(item => {
                types.append("<option value='" + item.Value + "'>" + item.Text + "</option>");
            });   
        }
    }
    function SuccessCallBack(data, textStatus, jqXHR) {
        if (data.status === 1) {
            alert('Insert Success');
            window.location.href = "/Home/Index";
        }
    }
});