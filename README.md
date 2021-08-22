
# DistanceCullingMirrors
### Udon script that exposes additional options for mirrors giving the ability to set distance based culling for players, interactables and optionally all other existing layers.

 ## Requirements
 
 * [VRCSDK3-Udon](https://vrchat.com/home/download) v.2021.08.04.15.07+
 * [Merlins Udon Sharp](https://github.com/MerlinVR/UdonSharp) (For U# Version)
 * Unity 2019.4.29f1
  ## Usage
  Add this script to any existing mirror or use one of the included mirror prefabs.
 
 Setting the culling distance to 0 will disable the culling behaviour.


# Examples

![DCM](https://user-images.githubusercontent.com/74171114/130367351-38c68131-0916-4820-b067-54d5e257602a.png)

## Video

### Nothing on this mirror is being updated. This is a normal mirror that has an internal culling distance set for players.

https://user-images.githubusercontent.com/74171114/130367299-b0a98aae-1b92-4a40-9026-975f3ac10e57.mp4

### The script will run its function when the player first views any given mirror and will disable itself once it has run.
