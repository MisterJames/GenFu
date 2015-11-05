/*------------------------------------------------------------------
Project:    Paperclip
Author:     Yevgeny S.
URL:        https://twitter.com/YevSim
Version:    1.0
Created:        11/03/2014
Last change:    01/04/2014
-------------------------------------------------------------------*/

/* ===== Tooltips ===== */

$('.tooltip-test > button').tooltip();

/* ===== Popovers ===== */

$('.popover-test > button').popover();

/* ===== Smooth Scrolling ===== */

$(document).ready(function(){
    $('a[href*=#typography],a[href*=#buttons], a[href*=#navs], a[href*=#pagination], a[href*=#tooltips], a[href*=#popovers], a[href*=#panels], a[href*=#accordion], a[href*=#carousel], a[href*=#info-boards], a[href*=#social-links], a[href*=#responsive-iframes]').bind("click", function(e){
      var anchor = $(this);
      $('html, body').stop().animate({
        scrollTop: $(anchor.attr('href')).offset().top
      }, 1000);
      e.preventDefault();
    });
   return false;
});
