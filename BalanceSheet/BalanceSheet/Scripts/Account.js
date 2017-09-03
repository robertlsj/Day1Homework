;
$(function () {
    AccountDateTime();
});

function AccountDateTime() {
    var $inputPicker = $('[data-datetimepicker]');
    $inputPicker.datetimepicker({
        format: 'YYYY-MM-DD',
        locale: 'zh-TW'
    });
}