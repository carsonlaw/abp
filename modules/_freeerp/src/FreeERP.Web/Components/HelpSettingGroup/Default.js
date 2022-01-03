(function ($) {
    debugger;
    $(function () {

        var l = abp.localization.getResource('AbpSettingManagement');

        $("#HelpSettingsForm").on('submit', function (event) {
            event.preventDefault();
            var form = $(this).serializeFormToObject();
            debugger;
            volo.abp.settingManagement.emailSettings.update(form).then(function (result) {
                $(document).trigger("AbpSettingSaved");
            });

        });


    });

})(jQuery);
