
$(function () {
    $(document).on('click', '.productUnititem',
        function () {
            var curritem = $(this);
            var currcateid = curritem.attr('productUnitid');
            var widget = $(curritem.parents("div.productUnit")[0]);
            widget.find('.productUnitinput').val(currcateid);
            var items = curritem.parents('div.dropdown-submenu').children('.productUnititem');
            var bread = '';
            items.each(function () {
                bread = '<li class="breadcrumb-item " aria-current="page">' + $(this).find('span').text() + '</li>' + bread;
            });
            widget.find('nav ol li').remove();
            widget.find('nav ol').prepend(bread);
            //widget.find('nav ol').append('<button class="btn productUnitReset" aria-label="清除" />');
            widget.find('.divselect').hide();
            widget.find('.divbread').show();
        });

    $(document).on('click', '.productUnitReset',
        function (e) {
            //debugger;
            //e.preventDefault();
            var curritem = $(this);
            var widget = $(curritem.parents("div.productUnit")[0]);
            widget.find('.productUnitinput').val('');
            widget.find('.divbread').hide();
            widget.find('.divselect').show();
        });

})