window.playAudio = (source, id) => {
    let player= document.createElement('audio');
    let word = document.getElementById(id);
    word.style.color = '#FF8C00FF';
    player.src = source;
    document.body.appendChild(player);
    player.load();
    player.play();
    player.addEventListener("ended", function (){
        word.style.color = 'black';
        player.currentTime = 0;
        player.removeAttribute('src')
        document.body.removeChild(player)
    },true);
}
    
