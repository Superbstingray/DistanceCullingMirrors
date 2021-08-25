Created by Superbstingray

Distance Culling Mirrors

https://github.com/Superbstingray/DistanceCullingMirrors

V0.55 - 23/08/21 - Made in UdonGraph_2021.08.04.15.07 & UdonSharp_v0.20.2 

Unity 2019 and SDK version 2021.08.04.15.07 or above and UdonSharp is required.

(Functionality)
Udon script that exposes additional options for mirrors giving the ability to set distance based culling for players, interactables and optionally all other existing layers, this should help in creating more optimized mirrors.

The script will run its function when the player first views any given mirror and will disable itself once it has run.

(Usage)
Use one of the provided prefabs or add the script to any existing mirror. If adding the script it will need to be on the same GameObject as the VRC Mirror Reflection component.

Setting the culling distance to 0 will disable culling behaviour for that layer.

Set the Player, Pickup or Other culling distances or manually set distances per layer in Layer Culling Distances. Setting values in Layer Culling Distances will override the values defined by the initial variables.

Make sure that Layer Cull Distances is 32 in length or these values wont be used.






