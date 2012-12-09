// Generated by CoffeeScript 1.4.0
(function() {
  var LoginError, LoginSuccess;

  LoginSuccess = function(authkey) {
    if (authkey != null) {
      SetCookie("sessionId", authkey);
      return location.replace("main.html");
    } else {
      return alert("Login incorrect!");
    }
  };

  LoginError = function() {
    return alert("Login failed!");
  };

  $(function() {
    $('#signin').bind('click', function(event) {
      var data;
      event.preventDefault();
      data = {
        login: $("#inputEmail").val(),
        password: $("#inputPassword").val()
      };
      return SendAjax("/api/signin", data, LoginSuccess, LoginError, "POST");
    });
    return $('#signup').bind('click', function(event) {
      var data;
      event.preventDefault();
      data = {
        login: $("#inputEmail").val(),
        password: $("#inputPassword").val()
      };
      return SendAjax("/api/signup", data, LoginSuccess, LoginError, "POST");
    });
  });

}).call(this);
