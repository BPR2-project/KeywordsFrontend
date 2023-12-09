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
    changeButton: function (id) {
        var recordingSpan = document.createElement('span');
        recordingSpan.setAttribute('class', 'spinner-grow spinner-grow-sm');
        recordingSpan.setAttribute('id', 'recording-spinner')

        var wrapper = document.getElementById(id + 'start');
        wrapper.appendChild(recordingSpan);
    },
    recording: async function (dotnetRef, id) {
        this.changeButton(id);
        let audioRecorder;
        let blob;

        const playButton = document.getElementById(String(id + 'play'));
        const startButton = document.getElementById(String(id + 'start'));

        var recordingSpan = document.getElementById('recording-spinner')
        var button = document.getElementById("recording-button");
        
        window.fileDataStream = async function () {
            let x = await blob.arrayBuffer();
            return new Uint8Array(x);
        }
        playButton.addEventListener('click', () => {
            const audioUrl = URL.createObjectURL(blob);
            const audio = new Audio(audioUrl);
            audio.play();
        });

        startButton.addEventListener('click', () => {
            StartRecording();
        })

        async function StartRecording() {
            navigator.getUserMedia = navigator.getUserMedia || navigator.mozGetUserMedia || navigator.webkitGetUserMedia;
            navigator.mediaDevices.getUserMedia({audio: true})
                .then(stream => {
                    window.streamReference = stream;

                    audioRecorder = new RecordRTC(stream, {
                        type: 'audio',
                        mimeType: 'audio/wav',
                        recorderType: StereoAudioRecorder,
                        audioBitsPerSecond: 256000,
                        desiredSampRate: 16000,
                        numberOfAudioChannels: 1,
                    })

                    blob = new Blob();
                    startButton.appendChild(recordingSpan);

                    audioRecorder.reset();

                    audioRecorder.setRecordingDuration(3000, async function () {
                        blob = audioRecorder.getBlob();
                        await dotnetRef.invokeMethodAsync('Receive', id);
                        startButton.removeChild(recordingSpan);
                        StopRecordingStream();
                    });
                    
                    audioRecorder.startRecording();
                }).catch(err => {
                // pushErrorToBlazor(err);
            });
        }
        function StopRecordingStream () {
            if (!window.streamReference) return;

            window.streamReference.getAudioTracks().forEach(function (track) {
                track.stop();
            });

            window.streamReference = null;
        }

        await StartRecording();
    }
}