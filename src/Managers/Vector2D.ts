export class Vector2D{
    x: number;
    y: number;

    constructor(x: number, y: number){
        this.x = x;
        this.y = y;
    }

    GetMagnidute(): number {
        return Math.sqrt(this.x ** 2 + this.y ** 2);
    }

    Normalize(): Vector2D {
        let magnitude = this.GetMagnidute();
        return new Vector2D(this.x / magnitude, this.y / magnitude);
    }

    DirectionTo(v: Vector2D): Vector2D {
        return new Vector2D(v.x - this.x, v.y - this.y);
    }
    
    Lerp(origin, target, t): Vector2D {
        let direction = origin.Direction(target);
        return new Vector2D(origin.x + direction.x * t, origin.y + direction.y * t);
    }

    ProjectOn(v: Vector2D): Vector2D {
        let normaizedV = v.Normalize();
        let dotProduct = normaizedV.x * this.x + normaizedV.y * this.y;
        return new Vector2D(normaizedV.x * dotProduct, normaizedV.y * dotProduct);
    }
    Equals(v: Vector2D): boolean {
        return this.x == v.x && this.y == v.y;
    }
}