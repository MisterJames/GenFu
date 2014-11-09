/*------------------------------------------------------------------
Project:    Paperclip
Author:     Yevgeny S.
URL:        https://twitter.com/YevSim
Version:    1.0
Created:        11/03/2014
Last change:    01/04/2014
-------------------------------------------------------------------*/

/* ===== Navbar Search ===== */

$('#navbar-search > a').on('click', function() {
    $('#navbar-search > a > i').toggleClass('fa-search fa-times');
    $("#navbar-search-box").toggleClass('show hidden animated fadeInUp');
    return false;
});

/*===== Pricing Bonus ===== */

$('#bonus .pricing-number > .fa-scissors').on('click', function() {
    $(this).css('left', '100%');    /* Cutting */
    setTimeout(function(){          /* Removing the scissors */
        $('#bonus .pricing-number > .fa-scissors').addClass('hidden');
        $('#bonus .pricing-body ul').addClass('animated fadeOutDown');
    }, 2000);
    return false;
});

/* ===== Lost password form ===== */

$('.pwd-lost > .pwd-lost-q > a').on('click', function() {
    $(".pwd-lost > .pwd-lost-q").toggleClass("show hidden");
    $(".pwd-lost > .pwd-lost-f").toggleClass("hidden show animated fadeIn");
    return false;
});

/* ===== Thumbs rating ===== */

$('.rating .voteup').on('click', function () {
    var up = $(this).closest('div').find('.up');
    up.text(parseInt(up.text(),10) + 1);
    return false;
});
$('.rating .votedown').on('click', function () {
    var down = $(this).closest('div').find('.down');
    down.text(parseInt(down.text(),10) + 1);
    return false;
});

/* ===== Responsive Showcase ===== */

$('.responsive-showcase ul > li > i').on('click', function() {
    var device = $(this).data('device');
    $('.responsive-showcase ul > li > i').addClass("inactive");
    $(this).removeClass("inactive");
    $('.responsive-showcase img').removeClass("show");
    $('.responsive-showcase img').addClass("hidden");
    $('.responsive-showcase img' + device).toggleClass("hidden show");
    $('.responsive-showcase img' + device).addClass("animated fadeIn");
    return false;
});

/* ===== Services ===== */

$('.service-item').hover (function() {
    $(this).children("i").toggleClass("fa-rotate-90");
    return false;
});
