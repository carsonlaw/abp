
$(function () {
    $(document).on('click', '.categoryitem',
        function () {
            var curritem = $(this);
            var currcateid = curritem.attr('categoryid');
            var widget = $(curritem.parents("div.category")[0]);
            widget.find('.categoryinput').val(currcateid);
            var items = curritem.parents('div.dropdown-submenu').children('.categoryitem');
            var bread = '';
            items.each(function () {
                bread = '<li class="breadcrumb-item " aria-current="page">' + $(this).find('span').text() + '</li>' + bread;
            });
            widget.find('nav ol li').remove();
            widget.find('nav ol').prepend(bread);
            //widget.find('nav ol').append('<button class="btn categoryReset" aria-label="清除" />');
            widget.find('.divselect').hide();
            widget.find('.divbread').show();
        });

    $(document).on('click', '.categoryReset',
        function (e) {
            //debugger;
            //e.preventDefault();
            var curritem = $(this);
            var widget = $(curritem.parents("div.category")[0]);
            widget.find('.categoryinput').val('');
            widget.find('.divbread').hide();
            widget.find('.divselect').show();
        });

})