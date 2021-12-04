"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ImageRenderer = void 0;
var ImageRenderer = /** @class */ (function () {
    function ImageRenderer(imageData, sFrameX, sFrameY, renderPosition) {
        this.ImageData = imageData;
        this.SFrameX = sFrameX;
        this.SFrameY = sFrameY;
        this.RenderPosition = renderPosition;
    }
    ImageRenderer.prototype.DrawImage = function (context) {
        if (context !== undefined && this.ImageData !== undefined) {
            context.drawImage(this.ImageData.Image, this.ImageData.SWidth * this.SFrameX, this.ImageData.SHeight * this.SFrameY, this.ImageData.SWidth, this.ImageData.SHeight, this.RenderPosition.X, this.RenderPosition.Y, this.ImageData.SWidth, this.ImageData.SHeight);
        }
    };
    return ImageRenderer;
}());
exports.ImageRenderer = ImageRenderer;
