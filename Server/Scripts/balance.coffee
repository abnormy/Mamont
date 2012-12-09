GetBalanceSuccess = (value) ->
    if value?
        $('#balance_value').text value
    else
        alert "GetBalance failed!"

GetBalanceError = () ->
    alert "GetBalance failed!"




GetTaxesSuccess = (value) ->
    if value?
        rows = for tax in value
                "<tr><td>#{tax.Name}</td><td>#{tax.Cost}</td><td><a class='btn btn-link' href='#''><i class='' icon-pencil'></i></a><a class='btn btn-link' href='#'><i class='icon-trash'></i></a></td></tr>"
        $("#taxesTable").append(rows.join(""))
    else
        alert "GetTaxes failed!"

GetLogSuccess = (value) ->
    if value?
        rows = for log in value
                "<tr><td>#{log.Date}</td><td>#{log.Comment}</td><td class='log_value log_positive'>#{log.Amount}</td></tr>"
        $("#logsTable").append(rows.join(""))
    else
        alert "GetLogs failed!"

GetBalance = () ->
    SendAjax("/api/ballance", "", GetBalanceSuccess, GetBalanceError, "GET")

GetTaxes = () ->
    SendAjax("/api/taxes", null, GetTaxesSuccess, null, "GET")

GetLog = () ->
    SendAjax("/api/log", null, GetLogSuccess, null, "GET")

$ ->
    GetBalance()
    GetTaxes()
    GetLog()
