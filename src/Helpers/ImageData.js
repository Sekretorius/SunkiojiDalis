"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ImageSharedData = void 0;
var ImageSharedData = /** @class */ (function () {
    function ImageSharedData(sprite, sWidth, sHeight) {
        var _this = this;
        this.SWidth = 0;
        this.SHeight = 0;
        this.Sprite = sprite;
        this.Image = new Image();
        this.Image.src = sprite;
        var callback = function (w, h) { _this.SWidth = w; _this.SHeight = h; };
        if (sWidth === undefined || sHeight === undefined) {
            this.Image.onload = function () {
                callback(this.width, this.height);
            };
        }
        else {
            this.SWidth = sWidth;
            this.SHeight = sHeight;
        }
    }
    return ImageSharedData;
}());
exports.ImageSharedData = ImageSharedData;
