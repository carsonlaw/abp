
$(function () {
    var l = abp.localization.getResource("FreeERP");

    //var createModal = new abp.ModalManager({ viewUrl: abp.appPath + "PurchaseOrders/PurchaseOrderCreateModal", modalClass: 'PurchaseOrderCreateModal', scriptUrl: abp.appPath + "Components/PurchaseOrderUnitWidget/Default.js" });
    //var updateModal = new abp.ModalManager({ viewUrl: abp.appPath + "PurchaseOrders/PurchaseOrderUpdateModal", modalClass: 'PurchaseOrderUpdateModal' });

    var purchaseOrderService = freeERP.purchases.purchaseOrder;

    var filterForm = $('#PurchaseOrderFilterForm');
    var getFilter = function () {
        var filterObj = filterForm.serializeFormToObject();
        return filterObj;
    };

    var dataTable = $("#PurchaseOrderTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollCollapse: true,
        scrollX: true,
        ordering: true,
        //order: [[2, "desc"]],
        ajax: abp.libs.datatables.createAjax(purchaseOrderService.getList, getFilter),
        columnDefs: [
            {
                title: l("Actions"),
                targets: 0,
                rowAction: {
                    items: [
                        {
                            text: l('Edit'),
                            visible: abp.auth.isGranted('FreeERP.Purchases.PurchaseOrders.Update'),
                            action: function (data) {
                                //updateModal.open({ id: data.record.id });
                                location.href = "/Purchases/PurchaseOrderUpdate/" + data.record.id
                            }
                        },
                        {
                            text: l('Delete'),
                            visible: abp.auth.isGranted('FreeERP.Purchases.PurchaseOrders.Delete'),
                            confirmMessage: function (data) {
                                return l("PurchaseOrderDeletionConfirmationMessage", data.record.name)
                            },
                            action: function (data) {
                                purchaseOrderService
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
                title: l("orderNo"),
                orderable: true,
                data: "orderNo"
            },
            {
                title: l("description"),
                orderable: true,
                data: "description"
            },
            {
                title: l("orderTime"),
                orderable: true,
                data: "orderTime"
            },
            {
                title: l("price"),
                orderable: true,
                data: "price"
            },
        ]
    }));

    $('#AbpContentToolbar button[name=CreatePurchaseOrder]').on('click', function (e) {
        e.preventDefault();
        window.location.href = "/Purchases/PurchaseOrderCreate"
    });


    filterForm.submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reload();
    });
});