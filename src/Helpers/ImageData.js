"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ImageSharedData = void 0;
var ImageSharedData = /** @class */ (function () {
    function ImageSharedData(sprite, sWidth, sHeight) {
        this.sprite = sprite;
        this.sWidth = sWidth;
        this.sHeight = sHeight;
        this.image = new Image();
        this.image.src = sprite;
    }
    return ImageSharedData;
}());
exports.ImageSharedData = ImageSharedData;
