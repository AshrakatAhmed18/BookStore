(function ($) {
  "use strict";
  $(".owl-men-item").owlCarousel({
    items: 5,
    loop: false,
    dots: true,
    nav: true,
    margin: 30,
    responsive: {
      0: {
        items: 1,
      },
      600: {
        items: 2,
      },
      1000: {
        items: 3,
      },
    },
  });

  $(".owl-women-item").owlCarousel({
    items: 5,
    loop: false,
    dots: true,
    nav: true,
    margin: 30,
    responsive: {
      0: {
        items: 1,
      },
      600: {
        items: 2,
      },
      1000: {
        items: 3,
      },
    },
  });

  $(".owl-kid-item").owlCarousel({
    items: 5,
    loop: false,
    dots: true,
    nav: true,
    margin: 30,
    responsive: {
      0: {
        items: 1,
      },
      600: {
        items: 2,
      },
      1000: {
        items: 3,
      },
    },
  });

  $(window).scroll(function () {
    var scroll = $(window).scrollTop();
    var box = $("#top").height();
    var header = $("header").height();

    if (scroll >= box - header) {
      $("header").addClass("background-header");
    } else {
      $("header").removeClass("background-header");
    }
  });

  // Window Resize Mobile Menu Fix
  mobileNav();

  // Scroll animation init
  window.sr = new scrollReveal();

  // Menu Dropdown Toggle
  if ($(".menu-trigger").length) {
    $(".menu-trigger").on("click", function () {
      $(this).toggleClass("active");
      $(".header-area .nav").slideToggle(200);
    });
  }





  // Page loading animation
  $(window).on("load", function () {
    if ($(".cover").length) {
      $(".cover").parallax({
        imageSrc: $(".cover").data("image"),
        zIndex: "1",
      });
    }

    $("#preloader").animate(
      {
        opacity: "0",
      },
      600,
      function () {
        setTimeout(function () {
          $("#preloader").css("visibility", "hidden").fadeOut();
        }, 300);
      }
    );
  });

  // Window Resize Mobile Menu Fix
  $(window).on("resize", function () {
    mobileNav();
  });

  // Window Resize Mobile Menu Fix
  function mobileNav() {
    var width = $(window).width();
    $(".submenu").on("click", function () {
      if (width < 767) {
        $(".submenu ul").removeClass("active");
        $(this).find("ul").toggleClass("active");
      }
    });
  }

  function imagesHover() {
    if ($("#product") && $("#product .left-images")) {
	  let resetClasses = () => {
		$("#product #small-imgs").children().children('img').removeClass('active');
	}
	resetClasses();
	$("#product #small-imgs").children().children('img').eq(0).addClass('active');
	  $("#product #small-imgs").children().children('img').on('mousemove', (e) =>{
		  $("#product #NZoomImg").attr('src', e.target.src);
		  resetClasses();
		  e.target.classList.toggle('active');

	  })


    }
  }

  $(window).on("load", function () {
    imagesHover();
  });
})(window.jQuery);
