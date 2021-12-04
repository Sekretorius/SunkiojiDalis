"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Character = void 0;
var ImageComponent_1 = require("../Helpers/ImageComponent");
var Vector2D_1 = require("../Helpers/Vector2D");
var ClientEngine_1 = require("../Managers/ClientEngine");
var Character = /** @class */ (function () {
    function Character(guid, characterData, imageSharedData) {
        this.Guid = guid;
        this.Name = characterData.name;
        this.Health = parseFloat(characterData.health);
        this.AreaId = characterData.areaId;
        this.Position = new Vector2D_1.Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));
        this.ImageRenderer = new ImageComponent_1.ImageRenderer(imageSharedData, parseInt(characterData.frameX), parseInt(characterData.frameY), this.Position);
        this.Speed = parseFloat(characterData.speed);
        this.TargetPosition = new Vector2D_1.Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));
        this.OriginPosition = new Vector2D_1.Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));
    }
    Character.prototype.GetAttackAlgorithm = function () {
        //maybe use this for visual showing
    };
    Character.prototype.GetMoveAlgorithm = function () {
        //maybe use this for visual showing
    };
    Character.prototype.Attack = function () {
    };
    Character.prototype.Move = function () {
    };
    Character.prototype.Die = function () {
    };
    Character.prototype.Destroy = function (data) {
        (0, ClientEngine_1.DestroyObject)(this.Guid);
    };
    return Character;
}());
exports.Character = Character;
