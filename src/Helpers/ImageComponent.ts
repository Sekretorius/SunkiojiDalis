import { ImageSharedData } from "./ImageData";
import { Vector2D } from "./Vector2D";


export class ImageRenderer
{
    imageData: ImageSharedData;

    sFrameX: any;
    sFrameY: any;

    renderPosition: Vector2D;

    constructor(imageData: ImageSharedData, sFrameX: any, sFrameY: any, renderPosition: Vector2D){
        this.imageData = imageData;
        this.sFrameX = sFrameX;
        this.sFrameY = sFrameY;
        this.renderPosition = renderPosition;
    }

    DrawImage(context: any) 
    {
        if(context !== undefined && this.imageData !== undefined){
            context.drawImage(this.imageData.image, 
                this.imageData.sWidth * this.sFrameX,
                this.imageData.sHeight * this.sFrameY, 
                this.imageData.sWidth, 
                this.imageData.sHeight, 
                this.renderPosition.x, 
                this.renderPosition.y, 
                this.imageData.sWidth, 
                this.imageData.sHeight);
        }
    }
}
