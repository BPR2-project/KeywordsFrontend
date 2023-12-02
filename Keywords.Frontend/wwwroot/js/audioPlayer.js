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
    }
}

    
