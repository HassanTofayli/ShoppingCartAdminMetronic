$('.product-buy').click(function () {
    // Find the closest '.product-bottom' element relative to the clicked icon and add the class.
    $(this).closest('.product-bottom').addClass("product-clicked");

    // Your JavaScript to call the Add action
    let productId = $(this).data("id"); // assuming that you have data-id attribute set on your .product-buy element
    $.ajax({
        url: `/Cart/Add?id=${productId}`,
        type: 'POST',
        success: function (response) {
            // Handle the response
            console.log('Product added');
        },
        error: function (err) {
            console.log('Error:', err);
        }
    });
});

$('.product-remove').click(function () {
    // Find the closest '.product-bottom' element relative to the clicked remove icon and remove the class.
    $(this).closest('.product-bottom').removeClass("product-clicked");

    // Your JavaScript to call the Remove action
    let productId = $(this).data("id"); // assuming that you have data-id attribute set on your .product-remove element
    $.ajax({
        url: `/Cart/Remove?id=${productId}`,
        type: 'POST',
        success: function (response) {
            // Handle the response
            console.log('Product removed');
        },
        error: function (err) {
            console.log('Error:', err);
        }
    });
});
