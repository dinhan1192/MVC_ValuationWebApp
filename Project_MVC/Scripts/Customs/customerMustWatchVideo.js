﻿var video = document.getElementById("video");

var timeStarted = -1;
var timePlayed = 0;
var duration = 0;
//var currentTime = 0;
// If video metadata is laoded get duration
if (video.readyState > 0)
    getDuration.call(video);
//If metadata not loaded, use event to get it
else {
    video.addEventListener('loadedmetadata', getDuration);
}

// remember time user started the video
function videoStartedPlaying() {
    timeStarted = new Date().getTime() / 1000;
}
function videoStoppedPlaying(event) {
    // Start time less then zero means stop event was fired vidout start event
    if (timeStarted > 0) {
        var playedFor = new Date().getTime() / 1000 - timeStarted;
        timeStarted = -1;
        // add the new ammount of seconds played
        timePlayed += playedFor;
    }
    document.getElementById("played").innerHTML = Math.round(timePlayed) + "";
    // Count as complete only if end of video was reached

    var timeToPass = duration * 3 / 4;

    if (this.currentTime >= timeToPass) {
        document.getElementById("nextVideo").style.visibility = "visible";
    }

    if (timePlayed >= duration && event.type == "ended") {
        //document.getElementById("status").className = "complete";
        document.getElementById("nextVideo").style.visibility = "visible";
    }
}

function getDuration() {
    duration = video.duration;
    document.getElementById("duration").appendChild(new Text(Math.round(duration) + ""));
    console.log("Duration: ", duration);
}

//function getCurrentTime() {
//    currentTime = video.currentTime;
//}

video.addEventListener("play", videoStartedPlaying);
video.addEventListener("playing", videoStartedPlaying);

video.addEventListener("ended", videoStoppedPlaying);
video.addEventListener("pause", videoStoppedPlaying);