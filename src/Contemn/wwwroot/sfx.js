let isMuted = false;
const EVENT_PLAY_SFX = "PlaySfx";
function playSfx(sfx) {
    if (isMuted) {
        return;
    }
    try {
        let audio = document.getElementById(sfx);
        audio.currentTime = 0;
        audio.play();
    } catch (e) {
        //nom!
    }
}
function handleEvent(parameters) {
    try {
        if (parameters[0] == EVENT_PLAY_SFX) {
            playSfx(parameters[1]);
        }
    } catch (e) {
        //nom!
    }
}
function toggleMute() {
    isMuted = !isMuted;
}