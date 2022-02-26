
$(function () {
    var l = abp.localization.getResource("FreeERP");

    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Suppliers/SupplierCreateModal",
        modalClass: 'SupplierCreateModal'
    });
    var updateModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Suppliers/SupplierUpdateModal",
        modalClass: 'SupplierUpdateModal'
    });

    var SupplierService = freeERP.suppliers.supplier;

    var filterForm = $('#SupplierFilterForm');
    var getFilter = function () {
        var filterObj = filterForm.serializeFormToObject();
        filterObj.pid = filterObj.SupplierId;
        return filterObj;
    };

    var dataTable = $("#SupplierTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollCollapse: true,
        scrollX: true,
        ordering: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(SupplierService.getList, getFilter),
        columnDefs: [
            {
                title: l("Actions"),
                targets: 0,
                rowAction: {
                    items: [
                        {
                            text: l('Edit'),
                            visible: abp.auth.isGranted('FreeERP.Purchases.Suppliers.Update'),
                            action: function (data) {
                                updateModal.open({ id: data.record.id });
                            }
                        },
                        {
                            text: l('Delete'),
                            visible: abp.auth.isGranted('FreeERP.Purchases.Suppliers.Delete'),
                            confirmMessage: function (data) {
                                return l("SupplierDeletionConfirmationMessage", data.record.name)
                            },
                            action: function (data) {
                                SupplierService
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
            }
        ]
    }));

    $('#AbpContentToolbar button[name=CreateSupplier]').on('click', function (e) {
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