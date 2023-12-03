window.player = {
    play: function (source, id) {
        let player = document.createElement('audio');
        let svg = document.getElementById(id);
        svg.style.filter = 'invert(46%) sepia(71%) saturate(1775%) hue-rotate(360deg) brightness(101%) contrast(106%)';
        player.src = source;
        document.body.appendChild(player);
        player.load();
        player.play();
        player.addEventListener("ended", function () {
                svg.style.filter = 'invert(4%) sepia(4%) saturate(7492%) hue-rotate(169deg) brightness(95%) contrast(77%)';
                player.currentTime = 0;
                player.removeAttribute('src')
                document.body.removeChild(player)
            }, true
        );
    },
    recording: function (dotnetRef, id) {
        const startButton = document.getElementById(id + 'start');
        const stopButton = document.getElementById(id + 'stop');
        const playButton = document.getElementById(id + 'play');
        let audioRecorder;
        let audioChunks = [];
        navigator.mediaDevices.getUserMedia({audio: true})
            .then(stream => {
                // Initialize the media recorder object
                audioRecorder = new MediaRecorder(stream);

                // dataavailable event is fired when the recording is stopped
                audioRecorder.addEventListener('dataavailable', e => {
                    audioChunks.push(e.data);
                });

                // start recording when the start button is clicked
                startButton.addEventListener('click', () => {
                    audioChunks = [];
                    audioRecorder.start();
                });

                // stop recording when the stop button is clicked
                stopButton.addEventListener('click', () => {
                    audioRecorder.stop();
                });

                // play the recorded audio when the play button is clicked
                playButton.addEventListener('click', () => {
                    const blobObj = new Blob(audioChunks, {type: 'audio/wav'});
                    const audioUrl = URL.createObjectURL(blobObj);
                    const audio = new Audio(audioUrl);
                    audio.play();
                });
            }).catch(err => {
            // If the user denies permission to record audio, then display an error.
            // invoke dotnetRef method
            //console.log('Error: ' + err);
        });
    }
}