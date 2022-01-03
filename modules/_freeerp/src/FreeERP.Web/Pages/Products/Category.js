
$(function () {
    var l = abp.localization.getResource("FreeERP");
    var help = abp.setting.getBoolean("FreeERP.HelpSetting");

    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Products/CategoryCreateModal",
        //scriptUrl: abp.appPath + 'Pages/Components/CategoryWidget/Default.js',
        modalClass: 'CategoryCreateModal'
    });
    var updateModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Products/CategoryUpdateModal",
        //scriptUrl: abp.appPath + 'Pages/Components/CategoryWidget/Default.js',
        modalClass: 'CategoryUpdateModal'
    });

    var categoryService = freeERP.products.category;

    var filterForm = $('#CategoryFilterForm');
    var getFilter = function () {
        var filterObj = filterForm.serializeFormToObject();
        filterObj.pid = filterObj.categoryId;
        return filterObj;
    };

    var dataTable = $("#CategoryTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollCollapse: true,
        scrollX: true,
        ordering: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(categoryService.getList, getFilter),
        columnDefs: [
            {
                title: l("Actions"),
                targets: 0,
                rowAction: {
                    items: [
                        {
                            text: l('Edit'),
                            visible: abp.auth.isGranted('FreeERP.Products.Categories.Update'),
                            action: function (data) {
                                updateModal.open({ id: data.record.id });
                            }
                        },
                        {
                            text: l('Delete'),
                            visible: abp.auth.isGranted('FreeERP.Products.Categories.Delete'),
                            confirmMessage: function (data) {
                                return l("CategoryDeletionConfirmationMessage", data.record.name)
                            },
                            action: function (data) {
                                categoryService
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
                title: l("Slug"),
                orderable: true,
                data: "slug"
            }
        ]
    }));

    $('#AbpContentToolbar button[name=CreateCategory]').on('click', function (e) {
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