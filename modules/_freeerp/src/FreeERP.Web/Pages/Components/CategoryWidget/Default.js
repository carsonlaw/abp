
$(function () {

    $(".category .categoryitem").on('click',
        function () {
            $('#CategoryId').val($(this).attr('categoryid'));
            $('.category nav ol').empty();

            var item = '<li class="breadcrumb-item " aria-current="page">' + $(this).text() + '</li>'
            $('.category nav ol').append(item);
            $('.category nav ol').append('<li class="breadcrumb-item categoryReset" href="javascript:void()" aria-current="page">X</li>');
            $('.category .dropdown').hide();
            $('.category nav').show();
        });

    $('.category').on('click', '.categoryReset',
        function () {
            $('#CategoryId').val('');
            $('.category nav').hide();
            $('.category .dropdown').show();
        });

})