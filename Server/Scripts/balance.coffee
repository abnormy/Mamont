GetBalanceSuccess = (value) ->
    if value?
        $('#balance_value').val(value)
    else
        alert "GetBalance failed!"

GetBalanceError = () ->
    alert "GetBalance failed!"

GetBalance = () ->
    SendAjax("/api/balance", "", GetBalanceSuccess, GetBalanceError, "GET")



