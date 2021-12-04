export class ImageSharedData
{
    image: any;
    sprite : string;
    sWidth: any;
    sHeight: any;

    constructor(sprite: any, sWidth: any, sHeight: any){
        this.sprite = sprite;
        this.sWidth = sWidth;
        this.sHeight = sHeight;

        this.image = new Image();
        this.image.src = sprite;
    }
}