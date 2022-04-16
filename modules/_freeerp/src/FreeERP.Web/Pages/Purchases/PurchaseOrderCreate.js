$(function () {

    var l = abp.localization.getResource("FreeERP");

    var $buttonSubmit = $("button");
    var $formCreate = $("form");
    var $tbProductCode = $('#tbProductCode');
    var dataTable;
    var storeSelect;

    function InitTable() {
        dataTable = $("#OrderLineTable").DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: false,
            paging: false,
            searching: false,
            scrollCollapse: true,
            scrollX: true,
            ordering: false,
            columnDefs: [{
                title: l("CategoryName"),
                data: "categoryName"
            }, {
                title: l("Name"),
                orderable: true,
                data: "name"
            },
            {
                title: l("Code"),
                orderable: true,
                data: "code"
            },
            {
                title: l("StockNum"),
                orderable: true,
                data: "stockNum"
            },
            {
                title: l("ProductUnit"),
                orderable: true,
                data: "unitName"
            },
            {
                title: l("Description"),
                orderable: true,
                data: "description"
            },
            {
                title: l("ProductNum"),
                render: function (d, t, r, i) {
                    return '<input type="hidden" name="ViewModel.Lines[' + i.row + '].ProductId" value="' + r.id + '">'
                        + '<input type="hidden" name="ViewModel.Lines[' + i.row + '].ProductSkuId" value="">'
                        + '<input type="number" data-val="true" data-val-digits="" data-val-range-min="1" class="form-control" name="ViewModel.Lines[' + i.row + '].Number" value="0"></input>'
                }
            },
            {
                title: l("ProductPrice"),
                render: function (d, t, r, i) {
                    return '<input type="number" data-val="true" class="form-control" name="ViewModel.Lines[' + i.row + '].UnitPrice" value="0"></input>'
                }
            },
            {
                title: l("ProductStore"),
                render: function (d, t, r, i) {
                    return getStoreHtml(storeSelect, i);
                }
            }]
        }));
    }

    function getStoreHtml(data, i) {
        var html = '<select name="ViewModel.Lines[' + i.row + '].StoreId" class="form-control">'
        data.forEach(item => {
            html += '<option value="' + item.id + '">' + item.name + '</option>';
        });
        html += '</select>'
        return html
    }

    function InitStoreSelect() {
        return freeERP.stories.store.getSelectData()
            .then(function (r) {
                storeSelect = r;
                console.log(r);
            })
    }


    $formCreate.on('submit', function (e) {
        e.preventDefault();

        if ($formCreate.valid()) {

            $formCreate.ajaxSubmit({
                success: function (result) {
                    abp.notify.success(l('SuccessfullySaved'));
                    abp.ui.clearBusy();
                    location.href = "/Purchases/PurchaseOrder";
                },
                error: function (result) {
                    abp.notify.error(result.responseJSON.error.message);
                    abp.ui.clearBusy();
                }
            });
        }
        else {
            abp.ui.clearBusy();
        }
    });

    $buttonSubmit.click(function (e) {
        e.preventDefault();
        //submitCoverImage();
        $formCreate.submit();
    });
    $tbProductCode.on("keypress", function (e) {
        if (e.keyCode == "13") {
            abp.ui.setBusy();
            var code = $tbProductCode.val();
            $tbProductCode.val('');
            freeERP.products.product.getProductDOrSKUByCode(code)
                .then(function (r) {
                    abp.ui.clearBusy();
                    if (!r) {
                        abp.notify.warn(l('NoProductByCode'));
                        return;
                    }
                    var data = dataTable.data();
                    var added = false;
                    $.each(data, function (i, v) {
                        if (r.id == v.id) {
                            added = true;
                            return false;
                        }
                    });
                    if (added) {
                        abp.notify.warn(l('ProductAdded'));
                        return;
                    }
                    dataTable.row.add(r).draw(false);
                })
        }
    })
    InitStoreSelect()
        .then(function () {
            InitTable();
        });
})