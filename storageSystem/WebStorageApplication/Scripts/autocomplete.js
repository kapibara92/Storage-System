function addMethod(data) {
    var cache = {};
    var drew = false;


    $("#delivery").on("keyup", function () {
        var query = $("#search").val()

        if ($("#delivery").val().length >= 1) {

            //Check if we've searched for this term before
            if (query in cache) {
                results = cache[query];
            }
            else {
                //Case insensitive search for our data array
                var results = $.grep(data, function (item) {
                    return item.search(RegExp(query, "i")) != -1;
                });

                //Add results to cache
                cache[query] = results;
            }

            //First search
            if (drew == false) {
                //Create list for results
                $("#delivery").after('<ul id="res"></ul>');

                //Prevent redrawing/binding of list
                drew = true;
                $("#res").mouseover(function () {
                    $(this).css('cursor', 'pointer');
                })
                //Bind click event to list elements in results
                $("#res").on("click", "li", function () {
                    $("#delivery").val($(this).text());
                    $("#res").empty();
                });
            }
                //Clear old results
            else {
                $("#res").empty();
            }

            //Add results to the list
            for (term in results) {
                $("#res").append("<li>" + results[term] + "</li>");
            }
        }
            //Handle backspace/delete so results don't remain with less than 3 characters
        else if (drew) {
            $("#res").empty();
        }
    });
}