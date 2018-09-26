$(document).ready(function() {
    $('.selectpicker').selectpicker({
        style: 'btn-default',
        dropupAuto: false,
        selectOnTab: true,
        iconBase: 'fa',
        tickIcon: 'fa-check'
    });

    $('.datetimepicker').datetimepicker({
        format: 'DD-MM-YYYY HH:mm:ss'
    });
});
