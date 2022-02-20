
$(function () {
    var l = abp.localization.getResource("FreeERP");

    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Stories/StoreCreateModal",
        modalClass: 'StoreCreateModal'
    });
    var updateModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Stories/StoreUpdateModal",
        modalClass: 'StoreUpdateModal'
    });

    var StoreService = freeERP.stories.store;

    var filterForm = $('#StoreFilterForm');
    var getFilter = function () {
        var filterObj = filterForm.serializeFormToObject();
        filterObj.pid = filterObj.StoreId;
        return filterObj;
    };

    var dataTable = $("#StoreTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollCollapse: true,
        scrollX: true,
        ordering: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(StoreService.getList, getFilter),
        columnDefs: [
            {
                title: l("Actions"),
                targets: 0,
                rowAction: {
                    items: [
                        {
                            text: l('Edit'),
                            visible: abp.auth.isGranted('FreeERP.Stories.Stories.Update'),
                            action: function (data) {
                                updateModal.open({ id: data.record.id });
                            }
                        },
                        {
                            text: l('Delete'),
                            visible: abp.auth.isGranted('FreeERP.Stories.Stories.Delete'),
                            confirmMessage: function (data) {
                                return l("StoreDeletionConfirmationMessage", data.record.name)
                            },
                            action: function (data) {
                                StoreService
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

    $('#AbpContentToolbar button[name=CreateStore]').on('click', function (e) {
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