document.getElementById("canvas").disabled = true;
const canvas = document.getElementById('canvas');
const context = canvas.getContext('2d');
canvas.width = 800;
canvas.height = 500;

const keys = [];
const allPlayers = [];

const player = {
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
  connection.invoke("JoinGame", JSON.stringify(player)).catch(function (err) {
    return console.error(err.toString());
  });
}

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
connection.start().then(function () {
  console.log("Connected.")
  joinGame();
  document.getElementById("canvas").disabled = false;
}).catch(function (err) {
  return console.error(err.toString());
});

connection.on("AllPlayers", function (players) {
  allPlayers = JSON.parse(players);
});

const playerSprite = new Image();
playerSprite.src = player.sprite;
const background = new Image();
background.src = "resources/backgrounds/grass_background.png";

function drawSprite(img, sX, sY, sW, sH, dX, dY, dW, dH) {
  context.drawImage(img, sX, sY, sW, sH, dX, dY, dW, dH);
}

window.addEventListener("keydown", function(e) {
  keys[e.key] = true;
  player.moving = true;
});

window.addEventListener("keyup", function(e) {
  delete keys[e.key];
  player.moving = false;
});

function movePlayer() {
  if(keys["ArrowUp"] && player.y > 0) {
    player.y -= player.speed;
    player.frameY = 3;
    player.moving = true;
  }
  if(keys["ArrowLeft"] && player.x > 0) {
    player.x -= player.speed;
    player.frameY = 1;
    player.moving = true;
  }
  if(keys["ArrowDown"] && player.y < canvas.height - player.height) {
    player.y += player.speed;
    player.frameY = 0;
    player.moving = true;
  }
  if(keys["ArrowRight"] && player.x < canvas.width - player.width) {
    player.x += player.speed;
    player.frameY = 2;
    player.moving = true;
  }
}

function handlePlayerFrame() {
  if(player.frameX < 3 && player.moving) player.frameX++;
  else player.frameX = 0;
}

let fps, fpsInterval, startTime, now, then, elapsed;

function startAnimating(fps) {
  fpsInterval = 1000 / fps;
  then = Date.now();
  startTime = then;
  animate();
}

function animate() {
  requestAnimationFrame(animate);
  now = Date.now();
  elapsed = now - then;
  if(elapsed > fpsInterval) {
    then = now - (elapsed % fpsInterval);
    context.clearRect(0, 0, canvas.width, canvas.height)
    context.drawImage(background, 0, 0, canvas.width, canvas.height);
    for(var el in allPlayers) {
      drawSprite(el.sprite,
        el.width * el.frameX,
        el.height * el.frameY,
        el.width,
        el.height,
        el.x,
        el.y,
        el.width,
        el.height);
    }
    movePlayer();
    handlePlayerFrame();
    requestAnimationFrame(animate);
  }
}

startAnimating(30);