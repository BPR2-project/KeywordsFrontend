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
    recording: async function (dotnetRef, id) {
        let audioRecorder;
        let blob;

        window.fileDataStream = async function (){            
            const x = await blob.arrayBuffer();
            return new Uint8Array(x);
        }
        
        navigator.getUserMedia = navigator.getUserMedia || navigator.mozGetUserMedia || navigator.webkitGetUserMedia;
        navigator.mediaDevices.getUserMedia({audio: true})
            .then(stream => {
                
                audioRecorder = new RecordRTC(stream, {
                    type: 'audio',
                    mimeType: 'audio/wav',
                    recorderType: StereoAudioRecorder,
                    audioBitsPerSecond: 256000,
                    desiredSampRate: 16000,
                    numberOfAudioChannels: 1,
                })

                audioRecorder.startRecording();
                
                setTimeout(() =>{
                    audioRecorder.stopRecording(async function(){
                        blob = audioRecorder.getBlob();
                        await dotnetRef.invokeMethodAsync('Receive', id);
                    });
                },3000);

            }).catch(err => {
            // pushErrorToBlazor(err);
        });
    }
    // recording: async function (dotnetRef, id) {
    //           
    //     const startButton = document.getElementById(String(id + 'start'));
    //     const playButton = document.getElementById(String(id + 'play'));
    //     let audioRecorder;
    //     let audioChunks = [];
    //    
    //     window.fileDataStream = async function (){
    //         const blobObj = new Blob(audioChunks, {type: 'audio/wav'});
    //         const x = await blobObj.arrayBuffer();
    //         return new Uint8Array(x);
    //     }
    //     async function startRecording(){
    //         audioChunks = [];
    //         audioRecorder.start();
    //         setTimeout(() =>{
    //             audioRecorder.stop();
    //         },3000);
    //     }
    //    
    //     // async function pushErrorToBlazor(err){
    //     //     await dotnetRef.invokeMethodAsync();
    //     // }
    //    
    //     navigator.mediaDevices.getUserMedia({audio: true})
    //         .then(stream => {
    //             // Initialize the media recorder object
    //             audioRecorder = new MediaRecorder(stream);
    //            
    //             startRecording();
    //            
    //             // dataavailable event is fired when the recording is stopped
    //             audioRecorder.ondataavailable = async function (e) {
    //                 audioChunks.push(e.data);
    //             }
    //            
    //             audioRecorder.onstop = async function (e ){
    //                 await dotnetRef.invokeMethodAsync('Receive', id);
    //             }
    //             /*
    //             // play the recorded audio when the play button is clicked
    //             playButton.addEventListener('click', () => {
    //                 const blobObj = new Blob(audioChunks, {type: 'audio/webm'});
    //                 const audioUrl = URL.createObjectURL(blobObj);
    //                 const audio = new Audio(audioUrl);
    //                 audio.play();
    //             }); */
    //         }).catch(err => {
    //             // pushErrorToBlazor(err);
    //     });
    // }
}