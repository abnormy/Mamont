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
                "<tr><td>#{tax.Name}</td><td>#{tax.Cost}</td><td><a class='btn btn-link' href='#''><i class='' icon-pencil'></i></a><a class='btn btn-link' href='#'><i class='icon-trash' data-name='#{tax.Name}'></i></a></td></tr>"
        $("#taxesTable tbody").html("")
        $("#taxesTable").append(rows.join(""))
    else
        alert "GetTaxes failed!"

GetLogSuccess = (value) ->
    if value?
        rows = for log in value
            date = new Date(parseInt(/\d+/g.exec("/Date(1355063352862)/")[0]))
            valueClass = if log.Amount > 0 then "log_positive" else "log_negative"
            dateString  = date.getDate() + "." + (date.getMonth() + 1) + "." + date.getFullYear() + " " + date.getHours() + ":" + date.getMinutes()
            "<tr><td>#{dateString}</td><td>#{log.Comment}</td><td class='log_value #{valueClass}'>#{log.Amount}</td></tr>"
        $("#logsTable tbody").html("")
        $("#logsTable").append(rows.join(""))
    else
        alert "GetLogs failed!"

GetBalance = () ->
    SendAjax("/api/ballance", "", GetBalanceSuccess, GetBalanceError, "GET")

GetTaxes = () ->
    SendAjax("/api/taxes", null, GetTaxesSuccess, null, "GET")

AddBalanceSuccess = (value) ->
    GetBalance()
    GetLog()

PayAllSuccess = (value) ->
    GetBalance()
    GetLog()

AddTaxesSuccess = (value) ->
    GetTaxes()

DeleteTaxSuccess = (value) ->
    GetTaxes()

AddBalance = () ->
    data =
        Diff: $("#addAmount").val()
        Comment: $("#addComment").val()
    SendAjax("/api/ballance", data, AddBalanceSuccess, null, "POST")

AddTaxes = () ->
    data =
        Name: $("#taxesName").val()
        Cost: $("#taxesValue").val()
    SendAjax("/api/taxes", data, AddTaxesSuccess, null, "PUT")

PayAll = () ->
    SendAjax("/api/TaxProcessing", null, PayAllSuccess, null, "GET")

DeleteTaxes = (element) ->
    #alert()
     data =
         Name: $(element).data("name")
     SendAjax("/api/taxes", data, DeleteTaxSuccess, null, "DELETE")

GetLog = () ->
    SendAjax("/api/log", null, GetLogSuccess, null, "GET")

$ ->
    $('#addBalance').bind 'click', (event) -> 
        event.preventDefault()
        AddBalance()
    $('#addTax').bind 'click', (event) -> 
        event.preventDefault()
        AddTaxes()
    $('.icon-trash').live 'click', (event) -> 
        event.preventDefault()
        DeleteTaxes($(this))
    $('#payAll').bind 'click', (event) -> 
        event.preventDefault()
        PayAll()
    GetBalance()
    GetTaxes()
    GetLog()
