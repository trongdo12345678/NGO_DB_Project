const container = document.getElementById('container');
const registerBtn = document.getElementById('register');
const loginBtn = document.getElementById('login');
const successMessage = document.getElementById('successMessage');

registerBtn.addEventListener('click', () => {
    container.classList.add("active");
});

loginBtn.addEventListener('click', () => {
    container.classList.remove("active");
});

var redirectToRegister = container.getAttribute('data-redirect-to-register');

if (redirectToRegister === "true") {
    container.classList.add("active");
}

