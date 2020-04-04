
//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
let player = alt.Player.local;
let cursor = false;
export function ShowCursor(bool) {
    if (cursor == false && bool == false || cursor == true && bool == true) {
        return;
    }
    alt.toggleGameControls(!bool);
    alt.showCursor(bool);
    cursor = bool;
}
export function GetCursorStatus() {
    if (cursor) { return true; }
    else { return false; }
}

export function DrawText(msg, screenPos, scale, fontType, ColorRGB, useOutline = true, useDropShadow = true, layer = 0, align = 0) {
    let hex = msg.match('{.*}');
    if (hex) {
        const rgb = hexToRgb(hex[0].replace('{', '').replace('}', ''));
        r = rgb[0];
        g = rgb[1];
        b = rgb[2];
        msg = msg.replace(hex[0], '');
    }
    if (ColorRGB == undefined || ColorRGB == null) { ColorRGB = 255; }
    //game.setScriptGfxDrawOrder(layer);
    game.beginTextCommandDisplayText('STRING');
    game.addTextComponentSubstringPlayerName(msg);
    game.setTextFont(fontType);
    game.setTextScale(scale[0], scale[1]);
    game.setTextWrap(0.0, 1.0);
    game.setTextCentre(true);
    game.setTextColour(ColorRGB[0], ColorRGB[1], ColorRGB[2], ColorRGB[3]);
    game.setTextJustification(align);

    if (useOutline) game.setTextOutline();

    if (useDropShadow) game.setTextDropShadow();

    game.endTextCommandDisplayText(screenPos[0], screenPos[1]);
}



//function drawText3d(msg, pos = [0, 0, 0], scale, fontType, r, g, b, a, useOutline = true, useDropShadow = true) {

export function Draw3DText(msg, x, y, z, fontType, color, useOutline = true, useDropShadow = true) {
    const [bol, _x, _y] = game.getScreenCoordFromWorldCoord(x, y, z);
    const camCord = game.getFinalRenderedCamCoord();
    const dist = game.getDistanceBetweenCoords(camCord.x, camCord.y, camCord.z, x, y, z, 1)


    if (dist > 20) return;

    let scale = (4.00001 / dist) * 0.3
    if (scale > 0.2)
        scale = 0.2;


    const fov = (1 / game.getGameplayCamFov()) * 100;
    scale = scale * fov;

    if (bol) {
        game.setTextScale(scale, scale);
        game.setTextFont(fontType);
        game.setTextProportional(true);
        game.setTextColour(color[0], color[1], color[2], color[3]);
        game.setTextDropshadow(0, 0, 0, 0, 255);
        game.setTextEdge(2, 0, 0, 0, 150);
        game.setTextDropShadow();
        game.setTextOutline();
        game.setTextCentre(true);
        game.beginTextCommandDisplayText("STRING");
        game.addTextComponentSubstringPlayerName(msg);
        if (useOutline) game.setTextOutline();
        if (useDropShadow) game.setTextDropShadow();
        game.endTextCommandDisplayText(_x, _y + 0.025);
    }

}



export function CreateBlip(name, pos, sprite, color, shortrange) {
    let blip = new alt.PointBlip(pos[0], pos[1], pos[2]);
    blip.alpha = 10;
    blip.sprite = sprite;
    blip.color = color;
    blip.shortRange = shortrange;
    blip.name = name;
}

export function CreatePed(PedName, Vector3Pos, rot) {
    game.createPed(0, alt.hash(PedName), Vector3Pos[0], Vector3Pos[1], Vector3Pos[2], rot, 0, 0);
}

export function frontOfPlayer(distance) {
    var result = game.getEntityForwardVector(player.scriptID);
    var pos = {
        x: player.pos.x + result.x * distance,
        y: player.pos.y + result.y * distance,
        z: player.pos.z + result.z * distance
    }
    return pos;
}