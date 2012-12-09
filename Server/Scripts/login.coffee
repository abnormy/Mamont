LoginSuccess = (authkey) ->
    if authkey?
        SetCookie "sessionId", authkey
        location.replace("main.html")
    else
        alert "Login incorrect!"

LoginError = () ->
    alert "Login failed!"

$ ->
    $('#signin').bind 'click', (event) -> 
        event.preventDefault()
        data =
            login: $("#inputEmail").val()
            password: $("#inputPassword").val()
        SendAjax("/api/signin", data, LoginSuccess, LoginError, "POST")
    $('#signup').bind 'click', (event) -> 
        event.preventDefault()
        data =
            login: $("#inputEmail").val()
            password: $("#inputPassword").val()
        SendAjax("/api/signup", data, LoginSuccess, LoginError, "POST")