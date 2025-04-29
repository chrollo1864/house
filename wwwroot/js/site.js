// Show password complexity requirements when password field is focused
document.addEventListener('DOMContentLoaded', function () {
    const passwordFields = document.querySelectorAll('input[type="password"]');

    passwordFields.forEach(field => {
        const hint = field.parentElement.querySelector('.form-text');
        if (hint) {
            field.addEventListener('focus', () => {
                hint.style.display = 'block';
            });

            field.addEventListener('blur', () => {
                if (!field.value) {
                    hint.style.display = 'none';
                }
            });
        }
    });
});

// Auto-dismiss alerts after 5 seconds
document.addEventListener('DOMContentLoaded', function () {
    const alerts = document.querySelectorAll('.alert');

    alerts.forEach(alert => {
        setTimeout(() => {
            const bsAlert = new bootstrap.Alert(alert);
            bsAlert.close();
        }, 5000);
    });
});

// Preview image before upload
document.addEventListener('DOMContentLoaded', function () {
    const imageInput = document.querySelector('input[type="file"][accept="image/*"]');
    const profileImage = document.querySelector('.profile-image');

    if (imageInput && profileImage) {
        imageInput.addEventListener('change', function () {
            const file = this.files[0];
            if (file) {
                const reader = new FileReader();
                reader.onload = function (e) {
                    profileImage.src = e.target.result;
                };
                reader.readAsDataURL(file);
            }
        });
    }
});

// Toggle password visibility
document.addEventListener('DOMContentLoaded', function () {
    const toggleButtons = document.querySelectorAll('.toggle-password');

    toggleButtons.forEach(button => {
        button.addEventListener('click', function () {
            const input = this.previousElementSibling;
            const type = input.getAttribute('type') === 'password' ? 'text' : 'password';
            input.setAttribute('type', type);

            const icon = this.querySelector('i');
            icon.classList.toggle('fa-eye');
            icon.classList.toggle('fa-eye-slash');
        });
    });
});

// Form validation
document.addEventListener('DOMContentLoaded', function () {
    const forms = document.querySelectorAll('form');

    forms.forEach(form => {
        form.addEventListener('submit', function (event) {
            if (!form.checkValidity()) {
                event.preventDefault();
                event.stopPropagation();
            }
            form.classList.add('was-validated');
        });
    });
});

// Dropdown menu hover effect
document.addEventListener('DOMContentLoaded', function () {
    const dropdowns = document.querySelectorAll('.dropdown');

    dropdowns.forEach(dropdown => {
        dropdown.addEventListener('mouseenter', function () {
            if (window.innerWidth >= 992) {
                const dropdownMenu = this.querySelector('.dropdown-menu');
                new bootstrap.Dropdown(this.querySelector('.dropdown-toggle')).show();
            }
        });

        dropdown.addEventListener('mouseleave', function () {
            if (window.innerWidth >= 992) {
                const dropdownMenu = this.querySelector('.dropdown-menu');
                new bootstrap.Dropdown(this.querySelector('.dropdown-toggle')).hide();
            }
        });
    });
});



document.addEventListener('DOMContentLoaded', function () {
    const scrollingWrapper = document.getElementById('scrollingWrapper');
    const progressBar = document.getElementById('progressBar');
    const btnLeft = document.getElementById('btnLeft');
    const btnRight = document.getElementById('btnRight');

    // Define the scroll width for each slide
    const slideWidth = 320; // You can adjust this value as needed
    const maxScroll = scrollingWrapper.scrollWidth - scrollingWrapper.clientWidth;
    const progressBarMaxWidth = 100; // 100% width for the progress bar

    // Function to update the progress bar
    function updateProgressBar() {
        const scrollLeft = scrollingWrapper.scrollLeft;
        const scrollPercentage = (scrollLeft / maxScroll) * progressBarMaxWidth;
        progressBar.style.transition = 'width 0.5s ease'; // Smooth transition
        progressBar.style.width = `${scrollPercentage}%`;
    }

    // Move the slide right
    function moveSlide() {
        scrollingWrapper.scrollBy({
            left: slideWidth, // move 320px each time
            behavior: 'smooth'
        });
    }

    // Move the slide left
    function moveSlideLeft() {
        scrollingWrapper.scrollBy({
            left: -slideWidth,
            behavior: 'smooth'
        });
    }

    // Loop the slides back to the beginning when the end is reached
    function loopSlides() {
        scrollingWrapper.scrollTo({
            left: 0,
            behavior: 'smooth'
        });
    }

    // Update progress bar on scroll event for real-time sync
    scrollingWrapper.addEventListener('scroll', () => {
        updateProgressBar();

        // If scrolled to or past maxScroll, loop back to start
        if (scrollingWrapper.scrollLeft >= maxScroll - 1) {
            loopSlides();
        }
    });

    // Auto move every 3s
    setInterval(() => {
        if (scrollingWrapper.scrollLeft < maxScroll - 1) { // Only move if not at the end
            moveSlide();
        } else {
            loopSlides(); // Loop to the first slide when the end is reached
        }
    }, 3000);

    // Button Controls for manual scroll
    btnRight.addEventListener('click', () => {
        moveSlide();
    });

    btnLeft.addEventListener('click', () => {
        moveSlideLeft();
    });

    // Swipe support variables
    let touchStartX = 0;
    let touchEndX = 0;
    const swipeThreshold = 50; // Minimum distance for swipe

    // Touch start event
    scrollingWrapper.addEventListener('touchstart', (e) => {
        touchStartX = e.changedTouches[0].screenX;
        touchStartY = e.changedTouches[0].screenY;
        isSwiping = false;
    });

    // Touch move event to detect horizontal swipe and prevent vertical scroll
    scrollingWrapper.addEventListener('touchmove', (e) => {
        const touchCurrentX = e.changedTouches[0].screenX;
        const touchCurrentY = e.changedTouches[0].screenY;
        const diffX = Math.abs(touchCurrentX - touchStartX);
        const diffY = Math.abs(touchCurrentY - touchStartY);

        // If horizontal movement is greater than vertical, consider it a swipe and prevent default scrolling
        if (diffX > diffY) {
            e.preventDefault();
            isSwiping = true;
        }
    }, { passive: false });

    // Touch end event
    scrollingWrapper.addEventListener('touchend', (e) => {
        touchEndX = e.changedTouches[0].screenX;
        if (isSwiping) {
            handleSwipeGesture();
        }
    });

    // Handle swipe gesture
    function handleSwipeGesture() {
        const swipeDistance = touchEndX - touchStartX;
        if (Math.abs(swipeDistance) > swipeThreshold) {
            if (swipeDistance > 0) {
                // Swipe right - move slide left
                moveSlideLeft();
            } else {
                // Swipe left - move slide right
                moveSlide();
            }
        }
    }

    // Initial progress bar update
    updateProgressBar();
});
