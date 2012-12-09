$(function(){
    var data = {
        login : "vasya",
        password : "pass"
    }

    $.ajax({ 
       type: "POST",
       dataType: "json",
       url: "/api/usercontroller/signin",
       headers: {
        AuthKey: 'trololrolro'
       },
       data: data,
       success: function(data){        
         alert(data);
       }
    });
});