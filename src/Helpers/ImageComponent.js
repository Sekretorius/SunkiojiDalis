"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ImageRenderer = void 0;
var ImageRenderer = /** @class */ (function () {
    function ImageRenderer(imageData, sFrameX, sFrameY, renderPosition) {
        this.imageData = imageData;
        this.sFrameX = sFrameX;
        this.sFrameY = sFrameY;
        this.renderPosition = renderPosition;
    }
    ImageRenderer.prototype.DrawImage = function (context) {
        if (context !== undefined && this.imageData !== undefined) {
            context.drawImage(this.imageData.image, this.imageData.sWidth * this.sFrameX, this.imageData.sHeight * this.sFrameY, this.imageData.sWidth, this.imageData.sHeight, this.renderPosition.x, this.renderPosition.y, this.imageData.sWidth, this.imageData.sHeight);
        }
    };
    return ImageRenderer;
}());
exports.ImageRenderer = ImageRenderer;
