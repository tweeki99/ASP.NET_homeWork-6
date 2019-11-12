$("#button").on("click", function () {
    $.ajax({
        type: "Post",
        url: "Create",
        data: { name: $("#name").val(), description: $("#description").val(), price: $("#price").val() }
    });
});