"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Vector2D = void 0;
var Vector2D = /** @class */ (function () {
    function Vector2D(x, y) {
        this.x = x;
        this.y = y;
    }
    Vector2D.prototype.GetMagnidute = function () {
        return Math.sqrt(Math.pow(this.x, 2) + Math.pow(this.y, 2));
    };
    Vector2D.prototype.Normalize = function () {
        var magnitude = this.GetMagnidute();
        return new Vector2D(this.x / magnitude, this.y / magnitude);
    };
    Vector2D.prototype.DirectionTo = function (v) {
        return new Vector2D(v.x - this.x, v.y - this.y);
    };
    Vector2D.prototype.Lerp = function (origin, target, t) {
        var direction = origin.Direction(target);
        return new Vector2D(origin.x + direction.x * t, origin.y + direction.y * t);
    };
    Vector2D.prototype.ProjectOn = function (v) {
        var normaizedV = v.Normalize();
        var dotProduct = normaizedV.x * this.x + normaizedV.y * this.y;
        return new Vector2D(normaizedV.x * dotProduct, normaizedV.y * dotProduct);
    };
    Vector2D.prototype.Equals = function (v) {
        return this.x == v.x && this.y == v.y;
    };
    return Vector2D;
}());
exports.Vector2D = Vector2D;
