jQuery.noConflict();
jQuery(function() {
    jQuery('.menu').on('click', '.nav-click', function(){
        jQuery(this).siblings('.menu__second-level').toggle();
        jQuery(this).children('.nav-arrow').toggleClass('nav-rotate');
    });
});