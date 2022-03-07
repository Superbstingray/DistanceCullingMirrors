



# DistanceCullingMirrors
### Udon script that exposes additional options for mirrors giving the ability to set distance based culling per layer functioning like an adjustable far clip distance. This will help with creating more optimized mirrors.

 ## Requirements
 
 * [VRCSDK3-Udon](https://vrchat.com/home/download) v.2021.08.04.15.07+
 * [VRChat-Community Merlins Udon Sharp](https://github.com/vrchat-community/UdonSharp) (v0.20.3)
 * Unity 2019.4.29f1+
  ## Usage
  Add this script to any existing mirror or use the included mirror prefab.
 
 Setting the culling distance to 0 will disable culling behaviour for that layer.


# Examples
Settings used for the video example.

![DCM](https://user-images.githubusercontent.com/74171114/130367351-38c68131-0916-4820-b067-54d5e257602a.png)

## Video

### Nothing on this mirror is being updated. This is a normal mirror that has an internal culling distance set for players. This makes it so only players near the mirror will be rendered.

https://user-images.githubusercontent.com/74171114/130367299-b0a98aae-1b92-4a40-9026-975f3ac10e57.mp4


## Manually setting culling distances in the layer array.

https://user-images.githubusercontent.com/74171114/130734783-cf06b9c2-bc15-45b6-8e38-fbf2d20dcc90.mp4

## Elements correspond to layer number.

![ArrayExample](https://user-images.githubusercontent.com/74171114/130407168-28779920-e812-4dd8-a408-860c96179c9f.png)
