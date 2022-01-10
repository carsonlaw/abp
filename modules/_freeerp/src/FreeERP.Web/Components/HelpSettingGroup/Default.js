(function ($) {
    $(function () {

        var l = abp.localization.getResource('AbpSettingManagement');

        $("#HelpSettingsForm").on('submit', function (event) {

            event.preventDefault();
            //$('#HelpSettingsForm button').setBusy();
            var form = $(this).serializeFormToObject();
            console.log(form);
            freeERP.settings.helpSetting.update(form).then(function (result) {
                $(document).trigger("AbpSettingSaved");
            });

        });


    });

})(jQuery);
