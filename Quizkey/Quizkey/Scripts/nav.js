const navSlide = () => {
  const burger = document.querySelector(".burger");
  const nav = document.querySelector(".nav-links");
  const navLinks = document.querySelectorAll(".nav-links li");
  //toogle nav
  burger.addEventListener("click", () => {
    nav.classList.toggle("nav-active");

    navLinks.forEach((link, index) => {
      if (link.style.animation) {
        //animation reseter
        link.style.animation = "";
      } else {
        link.style.animation = `navLinkFade 0.2s ease forwards ${
          index / 7 + 0.2
        }s`;
      }
    });
    //burger animation
    burger.classList.toggle("toggle");
  });
  //animate links
};

navSlide();
