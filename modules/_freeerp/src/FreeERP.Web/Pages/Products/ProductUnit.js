
$(function () {
    var l = abp.localization.getResource("FreeERP");

    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Products/ProductUnitCreateModal",
        modalClass: 'ProductUnitCreateModal'
    });
    var updateModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Products/ProductUnitUpdateModal",
        modalClass: 'ProductUnitUpdateModal'
    });

    var ProductUnitService = freeERP.products.productUnit;

    var filterForm = $('#ProductUnitFilterForm');
    var getFilter = function () {
        var filterObj = filterForm.serializeFormToObject();
        filterObj.pid = filterObj.productUnitId;
        return filterObj;
    };

    var dataTable = $("#ProductUnitTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollCollapse: true,
        scrollX: true,
        ordering: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(ProductUnitService.getList, getFilter),
        columnDefs: [
            {
                title: l("Actions"),
                targets: 0,
                rowAction: {
                    items: [
                        {
                            text: l('Edit'),
                            visible: abp.auth.isGranted('FreeERP.Products.ProductUnits.Update'),
                            action: function (data) {
                                updateModal.open({ id: data.record.id });
                            }
                        },
                        {
                            text: l('Delete'),
                            visible: abp.auth.isGranted('FreeERP.Products.ProductUnits.Delete'),
                            confirmMessage: function (data) {
                                return l("ProductUnitDeletionConfirmationMessage", data.record.name)
                            },
                            action: function (data) {
                                ProductUnitService
                                    .delete(data.record.id)
                                    .then(function () {
                                        dataTable.ajax.reload();
                                        abp.notify.success(l('SuccessfullyDeleted'));
                                    });
                            }
                        }
                    ]
                }
            },
            {
                title: l("Sort"),
                orderable: true,
                data: "sort"
            },
            {
                title: l("Name"),
                orderable: true,
                data: "name"
            },
            {
                title: l("Description"),
                orderable: true,
                data: "description"
            },
            {
                title: l("RatioCount"),
                orderable: true,
                data: "ratioCount"
            }
        ]
    }));

    $('#AbpContentToolbar button[name=CreateProductUnit]').on('click', function (e) {
        e.preventDefault();
        createModal.open();
    });

    createModal.onResult(function () {
        location.reload();
        //dataTable.ajax.reload();
    });

    updateModal.onResult(function () {
        //dataTable.ajax.reload();
        location.reload();
    });

    filterForm.submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reload();
    });
});