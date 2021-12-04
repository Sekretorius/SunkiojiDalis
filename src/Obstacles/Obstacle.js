"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Obstacle = void 0;
var ImageComponent_1 = require("../Helpers/ImageComponent");
var Vector2D_1 = require("../Helpers/Vector2D");
var Obstacle = /** @class */ (function () {
    function Obstacle(guid, itemData, imageSharedData) {
        this.guid = guid;
        this.Id = itemData.id;
        this.Position = new Vector2D_1.Vector2D(parseFloat(itemData.x), parseFloat(itemData.y));
        this.ImageRenderer = new ImageComponent_1.ImageRenderer(imageSharedData, 0, 0, this.Position);
    }
    Obstacle.prototype.getId = function () {
        return this.Id;
    };
    return Obstacle;
}());
exports.Obstacle = Obstacle;
