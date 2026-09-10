window.playNotificationSound = function (soundFilePath) {
    const audio = new Audio(soundFilePath);
    audio.play();
}