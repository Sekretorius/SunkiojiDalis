"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CalculateTravelTime = exports.Interpolate = exports.ClientEngineMethods = exports.ClientObjectCount = exports.ClientObjects = void 0;
var EnemyNpc_1 = require("../Characters/EnemyNpc");
var FriendlyNpc_1 = require("../Characters/FriendlyNpc");
var Vector2D_1 = require("./Vector2D");
exports.ClientObjects = {}; //objects that have been created
exports.ClientObjectCount = 0;
exports.ClientEngineMethods = {};
exports.ClientEngineMethods["CreateClientObject"] = CreateClientObject;
function CreateClientObject(serverRequest) {
    CreateNewObject(serverRequest.RequestObjectGuid, serverRequest.RequestData);
}
function CreateNewObject(guid, objectData) {
    if (exports.ClientObjects[guid] === undefined) {
        var newObject = void 0;
        switch (objectData.objectType) {
            case "FriendlyNpc":
                newObject = new FriendlyNpc_1.FriendlyNpc(guid, objectData);
                break;
            case "EnemyNpc":
                newObject = new EnemyNpc_1.EnemyNpc(guid, objectData);
                break;
        }
        if (newObject !== null) {
            exports.ClientObjects[guid] = newObject;
            exports.ClientObjectCount++;
        }
    }
}
function Interpolate(oringV, targetV, elapsedTime, travelTime) {
    var direction = oringV.DirectionTo(targetV);
    var t = elapsedTime / travelTime;
    if (t > 1.05) {
        t = 1.05;
    }
    return new Vector2D_1.Vector2D(oringV.x + direction.x * t, oringV.y + direction.y * t);
}
exports.Interpolate = Interpolate;
function CalculateTravelTime(oringV, targetV, speed) {
    if (speed !== 0) {
        var length_1 = oringV.DirectionTo(targetV).GetMagnidute();
        return length_1 / speed;
    }
    return 0;
}
exports.CalculateTravelTime = CalculateTravelTime;
