export class ImageSharedData
{
    public Image: any;
    public Sprite : string;
    public SWidth: number = 0;
    public SHeight: number = 0;

    constructor(sprite: any, sWidth: any, sHeight: any){
        this.Sprite = sprite;

        this.Image = new Image();
        this.Image.src = sprite;

        var callback = (w, h) => { this.SWidth = w; this.SHeight =h };

        if(sWidth === undefined || sHeight === undefined)
        {
            this.Image.onload=function()
            {
                callback(this.width, this.height);
            };
        }
        else
        {
            this.SWidth = sWidth;
            this.SHeight = sHeight;
        }
    }
}