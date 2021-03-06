"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
exports.PassableObstacle = void 0;
var Obstacle_1 = require("./Obstacle");
var PassableObstacle = /** @class */ (function (_super) {
    __extends(PassableObstacle, _super);
    function PassableObstacle(guid, characterData, imageSharedData) {
        var _this = _super.call(this, guid, characterData, imageSharedData) || this;
        _this.Type = characterData.type;
        return _this;
    }
    return PassableObstacle;
}(Obstacle_1.Obstacle));
exports.PassableObstacle = PassableObstacle;
