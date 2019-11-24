
    var source = '/home/repos';
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: source,
        success: displayPage,
        error: errorOnAjax
    });

    function displayPage(data) {
        console.log(data);
        $('#message').text(data["user"]);
        $("#my_image").attr("src", data["avatarurl"]);
        $('#bio').text(data["bio"]);
       // console.log(data["user"]);
        for (i = 0; i < data["repoNameList"].length; i++)
        {
            $('#repoList').append("<button type='button' class='btn btn - primary btn - lg'>"+data["repoNameList"][i]+"</button>");

        }
    }


function errorOnAjax() {
    console.log('Error on AJAX return');
}