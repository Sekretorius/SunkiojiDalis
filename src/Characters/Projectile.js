"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Projectile = void 0;
var ImageComponent_1 = require("../Helpers/ImageComponent");
var Vector2D_1 = require("../Helpers/Vector2D");
var ClientEngine_1 = require("../Managers/ClientEngine");
var Projectile = /** @class */ (function () {
    function Projectile(guid, projectileData, imageSharedData) {
        this.Guid = guid;
        this.Position = new Vector2D_1.Vector2D(parseFloat(projectileData.x), parseFloat(projectileData.y));
        this.Width = parseInt(projectileData.width);
        this.Height = parseInt(projectileData.height);
        this.Speed = parseFloat(projectileData.speed);
        this.TargetPosition = new Vector2D_1.Vector2D(parseFloat(projectileData.x), parseFloat(projectileData.y));
        this.OriginPosition = new Vector2D_1.Vector2D(parseFloat(projectileData.x), parseFloat(projectileData.y));
        this.ImageRenderer = new ImageComponent_1.ImageRenderer(imageSharedData, 0, 0, this.Position);
    }
    Projectile.prototype.SyncPosition = function (syncData) {
        this.Position.X = this.TargetPosition.X;
        this.Position.Y = this.TargetPosition.Y;
        this.TargetPosition = new Vector2D_1.Vector2D(parseFloat(syncData.RequestData.x), parseFloat(syncData.RequestData.y));
    };
    Projectile.prototype.Destroy = function (data) {
        (0, ClientEngine_1.DestroyObject)(this.Guid);
    };
    return Projectile;
}());
exports.Projectile = Projectile;
