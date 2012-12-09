# GetName = $.getJSON '/api/values', (data) => $('#hellospan').text(data)

@GetCookie = (name) ->
    pattern = "(?:; )?" + name + "=([^;]*);?"
    regexp  = new RegExp(pattern)
    return decodeURIComponent(RegExp["$1"]) if regexp.test(document.cookie)
    return false

@SetCookie = (name, value) ->
    return false if not name or not value
    str = name + '=' + encodeURIComponent value
    document.cookie = str
    return true

@SendAjax = (controller, data, success, error, type) ->
    params = 
        type: type
        dataType: "json"
        url: controller
        data: data
        headers:
            AuthKey: GetCookie "sessionId"
        success: (data) => success data
        error: (data) => error data
    $.ajax params