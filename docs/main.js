// Coming soon in a few different languages.
const messages = [
    'Coming Soon',
    '近日公開',
    'Kommer Snart',
    'ކަމިންގ ސޫން',
    'आउदैछ।',
    'Yeroo Dhiyootti',
    'விரைவில்',
    'Vini byento.',
    '即将推出',
    'Mox Adventu',
    'Тун удахгүй',
    'جلد آرہا ہے۔',
    'Yakında Gelecek',
    'เร็วๆ นี้',
    'త్వరలో'
];

// Capture the UI elements.
const mainElement = document.getElementById('main');
const messageElement = document.getElementById('message');

// Change the message now.
changeMessage();

// Change the message every three seconds.
setInterval(changeMessage, 3000);
function changeMessage() {
    mainElement.className = 'is-loading';
    setTimeout(removeLoadingClass, 1000);
}

// Remove the loading class.
function removeLoadingClass() {
    mainElement.className = '';
    messageElement.innerHTML = getRandomMessage();
}

// Get a random message.
function getRandomMessage() {
    let index = Math.floor(Math.random() * messages.length);
    return messages[index];
}