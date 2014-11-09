/*------------------------------------------------------------------
Project:    Paperclip
Author:     Yevgeny S.
URL:        https://twitter.com/YevSim
Version:    1.0
Created:        11/03/2014
Last change:    01/04/2014
-------------------------------------------------------------------*/

// Isotop Gallery 
// ==============

var $container = $('#isotope-container');
    $container.isotope({
    itemSelector : '.isotope-item',
});
$('#filters a').click(function(){
    var selector = $(this).attr('data-filter');
    $container.isotope({ filter: selector });
    return false;
});