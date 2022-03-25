$(function () {

    var l = abp.localization.getResource("FreeERP");

    var $fileInput = $('#ProductImage');
    var $buttonSubmit = $("button");
    var $formCreate = $("form");
    var $MediaId = $('#ViewModel_MediaId');
    var $tbProductCode = $('#tbProductCode');
    var UPPY_FILE_ID = "uppy-upload-file";
    var dataTable;

    var fileUploadUri = "/api/app/media/product";

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
            }]
        }));
    }

    function submitCoverImage() {
        abp.ui.setBusy();

        var UPPY_OPTIONS = {
            endpoint: fileUploadUri,
            formData: true,
            fieldName: "file",
            method: "post",
            headers: getUppyHeaders()
        };

        var UPPY = Uppy.Core().use(Uppy.XHRUpload, UPPY_OPTIONS);

        UPPY.reset();

        var file = $fileInput[0].files[0];

        if (file) {

            UPPY.addFile({
                id: UPPY_FILE_ID,
                name: file.name, // file name
                type: file.type, // file type
                data: file, // file
            });

            UPPY.upload().then((result) => {
                if (result.failed.length > 0) {
                    abp.message.error(l("UploadFailedMessage"));
                    abp.ui.clearBusy();
                } else {
                    $MediaId.val(result.successful[0].response.body.id);

                    $formCreate.submit();
                }
            });
        }
        else {
            $formCreate.submit();
        }
    }

    $formCreate.on('submit', function (e) {
        e.preventDefault();

        if ($formCreate.valid()) {
            if (!$('#ProductCreateCate').val()) {
                abp.notify.error(l('NotBeNull', l('CategoryName')));
                abp.ui.clearBusy();
                return false;
            }
            if (!$('#ProductCreateUnit').val()) {
                abp.notify.error(l('NotBeNull', l('ProductUnit')));
                abp.ui.clearBusy();
                return false;
            }

            $formCreate.ajaxSubmit({
                success: function (result) {
                    abp.notify.success(l('SuccessfullySaved'));
                    abp.ui.clearBusy();
                    location.href = "/Products/Product";
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

    function getUppyHeaders() {
        var headers = {};
        headers[abp.security.antiForgery.tokenHeaderName] = abp.security.antiForgery.getToken();

        return headers;
    }

    $buttonSubmit.click(function (e) {
        e.preventDefault();
        submitCoverImage();
    });
    $tbProductCode.on("keypress", function (e) {
        if (e.keyCode == "13") {
            var code = $tbProductCode.val();
            $tbProductCode.val('');
            freeERP.products.product.getProductDOrSKUByCode(code)
                .then(function (r) {
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

    InitTable();
})