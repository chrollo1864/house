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



var scrollingWrapper = new Swiper('#scrollingWrapper', {
    autoplay: {
        delay: 5000,
        disableOnInteraction: false,
        pauseOnMouseEnter: true
    },
    grabCursor: true,
    preloadImages: false,
    lazy: true,
    spaceBetween: 10,
    slidesPerView: 1,
    breakpoints: {
        576: { slidesPerView: 1 },
        768: { slidesPerView: 2 },
        992: { slidesPerView: 3 },
        1200: { slidesPerView: 4 }
    },
    navigation: {
        nextEl: '#btnRight',
        prevEl: '#btnLeft'
    },
    on: {
        slideChange: function () {
            var progress = (this.activeIndex + 1) / this.slides.length * 100;
            document.getElementById('progressBar').style.width = progress + '%';
        },
        init: function () {
            document.getElementById('progressBar').style.width = '0%';
        }
    }
});