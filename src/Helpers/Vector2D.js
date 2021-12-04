"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Vector2D = void 0;
var Vector2D = /** @class */ (function () {
    function Vector2D(x, y) {
        this.X = x;
        this.Y = y;
    }
    Vector2D.prototype.GetMagnidute = function () {
        return Math.sqrt(Math.pow(this.X, 2) + Math.pow(this.Y, 2));
    };
    Vector2D.prototype.Normalize = function () {
        var magnitude = this.GetMagnidute();
        return new Vector2D(this.X / magnitude, this.Y / magnitude);
    };
    Vector2D.prototype.DirectionTo = function (to) {
        return Vector2D.Subtract(to, this);
    };
    Vector2D.Lerp = function (origin, target, t) {
        var direction = origin.DirectionTo(target);
        return new Vector2D(origin.X + direction.X * t, origin.Y + direction.Y * t);
    };
    Vector2D.ProjectOn = function (vector, prjectionVector) {
        var normaizedV = prjectionVector.Normalize();
        var dotProduct = Vector2D.DotProduct(vector, normaizedV);
        return Vector2D.Multiply(normaizedV, dotProduct);
    };
    Vector2D.DotProduct = function (v1, v2) {
        return v1.X * v2.X + v1.Y * v2.Y;
    };
    Vector2D.Equals = function (v1, v2) {
        return v1.X === v2.X && v1.Y === v2.Y;
    };
    Vector2D.Add = function (v1, v2) {
        return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
    };
    Vector2D.Subtract = function (v1, v2) {
        return new Vector2D(v1.X - v2.X, v1.Y - v2.Y);
    };
    Vector2D.Multiply = function (v, num) {
        return new Vector2D(v.X * num, v.Y * num);
    };
    Vector2D.Divide = function (v, num) {
        return new Vector2D(v.X / num, v.Y / num);
    };
    return Vector2D;
}());
exports.Vector2D = Vector2D;
