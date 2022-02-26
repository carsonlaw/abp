
$(function () {
    var l = abp.localization.getResource("FreeERP");

    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Customers/CustomerCreateModal",
        modalClass: 'CustomerCreateModal'
    });
    var updateModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Customers/CustomerUpdateModal",
        modalClass: 'CustomerUpdateModal'
    });

    var CustomerService = freeERP.customers.customer;

    var filterForm = $('#CustomerFilterForm');
    var getFilter = function () {
        var filterObj = filterForm.serializeFormToObject();
        filterObj.pid = filterObj.CustomerId;
        return filterObj;
    };

    var dataTable = $("#CustomerTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollCollapse: true,
        scrollX: true,
        ordering: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(CustomerService.getList, getFilter),
        columnDefs: [
            {
                title: l("Actions"),
                targets: 0,
                rowAction: {
                    items: [
                        {
                            text: l('Edit'),
                            visible: abp.auth.isGranted('FreeERP.Sales.Customers.Update'),
                            action: function (data) {
                                updateModal.open({ id: data.record.id });
                            }
                        },
                        {
                            text: l('Delete'),
                            visible: abp.auth.isGranted('FreeERP.Sales.Customers.Delete'),
                            confirmMessage: function (data) {
                                return l("CustomerDeletionConfirmationMessage", data.record.name)
                            },
                            action: function (data) {
                                CustomerService
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

    $('#AbpContentToolbar button[name=CreateCustomer]').on('click', function (e) {
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