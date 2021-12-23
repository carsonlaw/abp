
$(function () {

    $(".category .categoryitem").on('click',
        function () {
            var curritem = $(this);
            var currcateid = curritem.attr('categoryid');
            var widget = $(curritem.parents("div.category")[0]);
            widget.find('.categoryinput').val(currcateid);
            var items = curritem.parents('div.dropdown-submenu').children('.categoryitem');
            var bread = '';
            items.each(function () {
                bread += '<li class="breadcrumb-item " aria-current="page">' + $(this).find('span').text() + '</li>'
            });
            widget.find('nav ol').empty();
            widget.find('nav ol').append(bread);
            widget.find('nav ol').append('<span class="badge bg-secondary categoryReset" style="cursor:pointer">清除</span>');
            widget.find('.divselect').hide();
            widget.find('.divbread').show();
        });

    $('.category').on('click', '.categoryReset',
        function () {
            var curritem = $(this);
            var widget = $(curritem.parents("div.category")[0]);
            widget.find('.categoryinput').val('');
            widget.find('.divbread').hide();
            widget.find('.divselect').show();
        });

})