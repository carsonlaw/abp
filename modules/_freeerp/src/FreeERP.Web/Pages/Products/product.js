
$(function () {
    var l = abp.localization.getResource("FreeERP");

    var createModal = new abp.ModalManager({ viewUrl: abp.appPath + "Products/ProductCreateModal", modalClass: 'ProductCreateModal' });
    var updateModal = new abp.ModalManager({ viewUrl: abp.appPath + "Products/ProductUpdateModal", modalClass: 'ProductUpdateModal' });

    var productService = freeERP.products.product;

    var filterForm = $('#ProductFilterForm');
    var getFilter = function () {
        var filterObj = filterForm.serializeFormToObject();
        return filterObj;
    };

    var dataTable = $("#ProductTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollCollapse: true,
        scrollX: true,
        ordering: true,
        order: [[1, "desc"]],
        ajax: abp.libs.datatables.createAjax(productService.getList, getFilter),
        columnDefs: [
            {
                title: l("Details"),
                targets: 0,
                rowAction: {
                    items: [
                        {
                            text: l('Edit'),
                            visible: abp.auth.isGranted('CmsKit.Blogs.Update'),
                            action: function (data) {
                                updateModal.open({ id: data.record.id });
                            }
                        },
                        {
                            text: l('Delete'),
                            visible: abp.auth.isGranted('CmsKit.Blogs.Delete'),
                            confirmMessage: function (data) {
                                return l("BlogDeletionConfirmationMessage", data.record.name)
                            },
                            action: function (data) {
                                productService
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
                title: l("Name"),
                orderable: true,
                data: "name"
            }
        ]
    }));

    $('#AbpContentToolbar button[name=CreateProduct]').on('click', function (e) {
        e.preventDefault();
        createModal.open();
    });

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    updateModal.onResult(function () {
        dataTable.ajax.reload();
    });
});