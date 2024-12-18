import $ from 'jquery'
import './ScrollTopButton.scss'
import { useEffect } from 'react'
import { faAngleUp } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
 
const ScrollTopButton = () => {
 
    useEffect(()=> {
        $(window).on('scroll', function () {
            var scroll = $(window).scrollTop();
 
            if (scroll != null)
            if (scroll < 445) {
                $("#sticky-header").removeClass("sticky-menu");
                $('.scroll-to-target').removeClass('open');
       
            } else {
                $("#sticky-header").addClass("sticky-menu");
                $('.scroll-to-target').addClass('open');
            }
        });
 
        if ($('.scroll-to-target').length) {
            $(".scroll-to-target").on('click', function () {
                var target = $(this).attr('data-target');
 
                if (target != null) {
                    $('html, body').animate({
                        scrollTop: $(target).offset().top
                    }, 300);
                }
         
            });
        }
    })
 
    return (
        <button className="scroll-top scroll-to-target" data-target="html">
          <FontAwesomeIcon icon={faAngleUp}></FontAwesomeIcon>
      </button>
    )
}
 
export default ScrollTopButton