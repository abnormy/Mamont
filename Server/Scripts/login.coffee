LoginSuccess = (authkey) ->
    if authkey?
        SetCookie "sessionId", authkey
        location.replace("main.html")
    else
        $('#showError').append('<p class="error_message">Incorrect email or password,<br> Please try again</p>')

LoginError = () ->
    $('#showError').append('<p class="error_message">Incorrect email or password,<br> Please try again</p>')

$ ->
    $('#signin').bind 'click', (event) -> 
        event.preventDefault()
        $('.error_message').remove()
        data =
            email: $("#inputEmail").val()
            password: $("#inputPassword").val()
        SendAjax("/api/signin", data, LoginSuccess, LoginError, "POST")
    $('#signup').bind 'click', (event) -> 
        event.preventDefault()
        $('.error_message').remove()
        data =
            email: $("#inputEmail").val()
            password: $("#inputPassword").val()
        SendAjax("/api/signup", data, LoginSuccess, LoginError, "POST")