function confirmDelete(uniqueId, isDeleteClicked) {
    var deleteSpan = 'deleteSpan_' + uniqueId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}

//$(document).ready(function () {
//    var touch = $('#resp-menu');
//    var menu = $('.menu');

//    $(touch).on('click', function (e) {
//        e.preventDefault();
//        menu.slideToggle();
//    });

//    $(window).resize(function () {
//        var w = $(window).width();
//        if (w > 767 && menu.is(':hidden')) {
//            menu.removeAttr('style');
//        }
//    });

//});