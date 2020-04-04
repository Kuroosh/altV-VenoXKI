//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

import alt from 'alt-client';
import * as game from "natives";

let TrafficList = {};
let TrafficListCounter = 0;
alt.onServer('NPC:CreateTraffic', (pedname, posx, posy, posz, rot, VehicleName) => {
    let NPC = game.createPed(0, alt.hash(pedname), posx, posy, posz, rot, 0, 0);
    TrafficList[TrafficListCounter] = {
        Name: pedname,
        PosX: posx,
        PosY: posy,
        PosZ: posz,
        Rotation: rot,
        Ped: NPC,
    };

    let veh = game.createVehicle(alt.hash(VehicleName), posx, posy, posz, rot, 0, 0, 0);

    alt.setTimeout(() => {
        game.taskWarpPedIntoVehicle(NPC.scriptID, veh.scriptID, -1);
    }, 500);

    TrafficListCounter++;
    alt.log("Called Traffic");
});




alt.onServer('NPC:Delete', () => {

});

alt.onServer('NPC:DeleteAll', () => {
    for (var NPC in TrafficListCounter) {
        if (TrafficList[NPC].Ped != null) {
            game.deletePed(TrafficList[NPC].Ped.scriptID);
        }
    }
});


alt.onServer('NPC:Update', () => {

});

alt.onServer('NPC:WarpToVehicle', (Vehicle) => {

});

