export class Vector2D{
    public X: number;
    public Y: number;

    constructor(x: number, y: number){
        this.X = x;
        this.Y = y;
    }

    GetMagnidute(): number {
        return Math.sqrt(this.X ** 2 + this.Y ** 2);
    }

    Normalize(): Vector2D {
        let magnitude = this.GetMagnidute();
        return new Vector2D(this.X / magnitude, this.Y / magnitude);
    }

    DirectionTo(to: Vector2D): Vector2D {
        return Vector2D.Subtract(to, this);
    }
    
    static Lerp(origin: Vector2D, target: Vector2D, t: number): Vector2D {
        let direction = origin.DirectionTo(target);
        return new Vector2D(origin.X + direction.X * t, origin.Y + direction.Y * t);
    }

    static ProjectOn(vector: Vector2D, prjectionVector: Vector2D): Vector2D {
        let normaizedV = prjectionVector.Normalize();
        let dotProduct = Vector2D.DotProduct(vector, normaizedV);
        return Vector2D.Multiply(normaizedV, dotProduct);
    }

    static DotProduct(v1: Vector2D, v2: Vector2D): number {
        return v1.X * v2.X + v1.Y * v2.Y;
    }

    static Equals(v1: Vector2D, v2: Vector2D): boolean {
        return v1.X === v2.X && v1.Y === v2.Y;
    }

    static Add(v1: Vector2D, v2: Vector2D): Vector2D{
        return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
    }

    static Subtract(v1: Vector2D, v2: Vector2D){
        return new Vector2D(v1.X - v2.X, v1.Y - v2.Y);
    }

    static Multiply(v: Vector2D, num: number){
        return new Vector2D(v.X * num, v.Y * num);
    }
    
    static Divide(v: Vector2D, num: number){
        return new Vector2D(v.X / num, v.Y / num);
    }
}