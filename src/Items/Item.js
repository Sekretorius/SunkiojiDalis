"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Item = void 0;
var ImageComponent_1 = require("../Helpers/ImageComponent");
var Vector2D_1 = require("../Helpers/Vector2D");
var Item = /** @class */ (function () {
    function Item(guid, itemData, imageSharedData) {
        this.Guid = guid;
        this.Id = itemData.id;
        this.Name = itemData.name;
        this.Weight = itemData.weight;
        this.Quantity = itemData.quantity;
        this.BelongsTo = itemData.belongsTo;
        this.Position = new Vector2D_1.Vector2D(parseFloat(itemData.x), parseFloat(itemData.y));
        this.ImageRenderer = new ImageComponent_1.ImageRenderer(imageSharedData, 0, 0, this.Position);
    }
    return Item;
}());
exports.Item = Item;
