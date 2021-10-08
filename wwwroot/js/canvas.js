"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.connection = void 0;
var signalR = require("../wwwroot/js/signalr/dist/browser/signalR");
document.getElementById("canvas").disabled = true;
var canvas = document.getElementById('canvas');
var context = canvas.getContext('2d');
canvas.width = 800;
canvas.height = 500;
var keys = [];
var otherPlayers = [];
var items = [];
var player = {
    id: -1,
    x: 200,
    y: 200,
    width: 32,
    height: 48,
    frameX: 0,
    frameY: 0,
    speed: 5,
    moving: false,
    sprite: "resources/characters/player-red.png"
};
function joinGame() {
    exports.connection.invoke("JoinGame", JSON.stringify(player)).catch(function (err) {
        return console.error(err.toString());
    });
}
function getItems() {
    exports.connection.invoke("SendItemsListToPlayers").catch(function (err) {
        return console.error(err.toString());
    });
}
exports.connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").withAutomaticReconnect().build();
exports.connection.on("RecieveInfoAboutOtherPlayers", function (newPlayersList) {
    otherPlayers = JSON.parse(newPlayersList);
    //to do: check coordinates with current player - take server coordinates
    for (var _i = 0, otherPlayers_1 = otherPlayers; _i < otherPlayers_1.length; _i++) {
        var element = otherPlayers_1[_i];
        if (element.id === player.id) {
            player.id = element.id;
            player.x = element.x;
            player.y = element.y;
            break;
        }
    }
});
exports.connection.on("RecieveItemInfo", function (newItems) {
    items = JSON.parse(newItems);
});
exports.connection.on("RecieveId", function (id) {
    player.id = id;
});
exports.connection.start().then(function () {
    joinGame();
    document.getElementById("canvas").disabled = false;
    startAnimating(30);
}).catch(function (err) {
    //to do: add notification for user 
    return console.error(err.toString());
});
var background = new Image();
background.src = "resources/backgrounds/grass_background.png";
function drawSprite(img, sX, sY, sW, sH, dX, dY, dW, dH) {
    var playerSprite = new Image();
    playerSprite.src = img;
    context.drawImage(playerSprite, sX, sY, sW, sH, dX, dY, dW, dH);
}
window.addEventListener("keydown", function (e) {
    keys[e.key] = true;
    player.moving = true;
});
window.addEventListener("keyup", function (e) {
    delete keys[e.key];
    player.moving = false;
});
function movePlayer() {
    if (keys["ArrowUp"] && player.y > 0) {
        player.y -= player.speed;
        player.frameY = 3;
        player.moving = true;
    }
    if (keys["ArrowLeft"] && player.x > 0) {
        player.x -= player.speed;
        player.frameY = 1;
        player.moving = true;
    }
    if (keys["ArrowDown"] && player.y < canvas.height - player.height) {
        player.y += player.speed;
        player.frameY = 0;
        player.moving = true;
    }
    if (keys["ArrowRight"] && player.x < canvas.width - player.width) {
        player.x += player.speed;
        player.frameY = 2;
        player.moving = true;
    }
}
function handlePlayerFrame() {
    if (player.frameX < 3 && player.moving)
        player.frameX++;
    else
        player.frameX = 0;
}
var fps, fpsInterval, startTime, now, then, elapsed;
function startAnimating(fps) {
    fpsInterval = 1000 / fps;
    then = Date.now();
    startTime = then;
    animate();
}
function sendPlayerInfoToServer() {
    exports.connection.invoke("UpdatePlayerInfo", JSON.stringify(player)).catch(function (err) {
        return console.error(err.toString());
    });
}
function animate() {
    requestAnimationFrame(animate);
    now = Date.now();
    elapsed = now - then;
    if (elapsed > fpsInterval) {
        then = now - (elapsed % fpsInterval);
        context.clearRect(0, 0, canvas.width, canvas.height);
        context.drawImage(background, 0, 0, canvas.width, canvas.height);
        if (otherPlayers.length > 0) {
            for (var _i = 0, otherPlayers_2 = otherPlayers; _i < otherPlayers_2.length; _i++) {
                var el = otherPlayers_2[_i];
                drawSprite(el.sprite, el.width * el.frameX, el.height * el.frameY, el.width, el.height, el.x, el.y, el.width, el.height);
            }
        }
        if (items.length > 0) {
            for (var _a = 0, items_1 = items; _a < items_1.length; _a++) {
                var el = items_1[_a];
                var img = new Image();
                img.src = el.Sprite;
                context.drawImage(img, el.X, el.Y);
            }
        }
        movePlayer();
        handlePlayerFrame();
        //to do: send/update player info to server when it is needed
        if (player.id !== -1) {
            sendPlayerInfoToServer();
            getItems();
        }
        requestAnimationFrame(animate);
    }
}
//# sourceMappingURL=canvas.js.map