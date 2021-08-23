

# DistanceCullingMirrors
### Udon script that exposes additional options for mirrors giving the ability to set distance based culling for players, interactables and optionally all other existing layers, this should help in creating more optimized mirrors.

### This is essentially adding an adjustable far clip distance to mirrors with the ability to set it per layer.

 ## Requirements
 
 * [VRCSDK3-Udon](https://vrchat.com/home/download) v.2021.08.04.15.07+
 * [Merlins Udon Sharp](https://github.com/MerlinVR/UdonSharp) (For U# Version)
 * Unity 2019.4.29f1
  ## Usage
  Add this script to any existing mirror or use one of the included mirror prefabs.
 
 Setting the culling distance to 0 will disable culling behaviour for that layer.


# Examples
Settings used for the video example.

![DCM](https://user-images.githubusercontent.com/74171114/130367351-38c68131-0916-4820-b067-54d5e257602a.png)

## Video

### Nothing on this mirror is being updated. This is a normal mirror that has an internal culling distance set for players. This makes it so only players near the mirror will be rendered.

https://user-images.githubusercontent.com/74171114/130367299-b0a98aae-1b92-4a40-9026-975f3ac10e57.mp4

### The script will run its function when the player first views any given mirror and will disable itself once it has run.

### Manually setting culling distances in the layer array. Elements correspond to layer number.

![ArrayExample](https://user-images.githubusercontent.com/74171114/130407168-28779920-e812-4dd8-a408-860c96179c9f.png)
