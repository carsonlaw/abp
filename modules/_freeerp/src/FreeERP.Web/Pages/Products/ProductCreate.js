$(function () {

    var l = abp.localization.getResource("FreeERP");

    var $fileInput = $('#ProductImage');
    var $buttonSubmit = $("button");
    var $formCreate = $("form");
    var $MediaId = $('#ViewModel_MediaId');
    var UPPY_FILE_ID = "uppy-upload-file";

    var fileUploadUri = "/api/app/media/product";

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


})