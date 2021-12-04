import { ImageSharedData } from "./ImageData";
import { Vector2D } from "./Vector2D";


export class ImageRenderer
{
    public ImageData: ImageSharedData;

    public SFrameX: any;
    public SFrameY: any;

    public RenderPosition: Vector2D;

    constructor(imageData: ImageSharedData, sFrameX: any, sFrameY: any, renderPosition: Vector2D){
        this.ImageData = imageData;
        this.SFrameX = sFrameX;
        this.SFrameY = sFrameY;
        this.RenderPosition = renderPosition;
    }

    DrawImage(context: any) 
    {
        if(context !== undefined && this.ImageData !== undefined){
            context.drawImage(this.ImageData.Image, 
                this.ImageData.SWidth * this.SFrameX,
                this.ImageData.SHeight * this.SFrameY, 
                this.ImageData.SWidth, 
                this.ImageData.SHeight, 
                this.RenderPosition.X, 
                this.RenderPosition.Y, 
                this.ImageData.SWidth, 
                this.ImageData.SHeight);
        }
    }
}
