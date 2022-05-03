
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using System;

#if !COMPILER_UDONSHARP && UNITY_EDITOR
using UnityEditor;
using UdonSharpEditor;
#endif

namespace Superbstingray
{
	[UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
	public class SetCameraCullDistances : UdonSharp.UdonSharpBehaviour 
	{
	[Tooltip("A Value Of 0 Will Disable Culling Behaviour")]
	public float PlayerCullingDistance = 20F;

	[Tooltip("A Value Of 0 Will Disable Culling Behaviour")]
	public float PickupCullingDistance = 25F;

	[Tooltip("A Value Of 0 Will Disable Culling Behaviour")]
	public float OtherCullingDistances = 125F;

	[Tooltip("Set Individual Layer Culling Distances")]
	public float[] LayerCullDistances;

	private Camera selfCamera;
	private bool isUpdated;

		public void _EditorCamReset()
		{
			// Reset Float Array
			LayerCullDistances = new float[32];
		}

		public void _EditorCamUpdate()
		{
			// Force Initialize & Set Float Array to 32 Length
			if  (LayerCullDistances == null) { LayerCullDistances = new float[32]; }
			if  (LayerCullDistances.Length != 32) { LayerCullDistances = new float[32]; }
			selfCamera = transform.GetComponent<Camera>();	

			_CameraUpdate();
		}
		public void OnEnable()
		{
			selfCamera = transform.GetComponent<Camera>();
			if  (LayerCullDistances.Length != 32) { LayerCullDistances = new float[32]; }	

			_CameraUpdate();
		}
		public void _CameraUpdate()
		{
			// Update Player Layers Culling Distances 
			if ((LayerCullDistances[9] == 0F)) // Player
			{ LayerCullDistances[9] = PlayerCullingDistance;
			}
			if ((LayerCullDistances[10] == 0F)) // PlayerLocal
			{ LayerCullDistances[10] = PlayerCullingDistance;
			}
			if ((LayerCullDistances[18] == 0F)) // MirrorReflection
			{ LayerCullDistances[18] = PlayerCullingDistance;
			}
			// Update Pickup Related Layer Culling Distances
			if ((LayerCullDistances[8] == 0F)) // Interactive
			{ LayerCullDistances[8] = PickupCullingDistance;
			}
			if ((LayerCullDistances[13] == 0F)) // Pickup
			{ LayerCullDistances[13] = PickupCullingDistance;
			}
			if ((LayerCullDistances[14] == 0F)) // PickupNoEnvironment
			{ LayerCullDistances[14] = PickupCullingDistance;
			}

			// Set Undefined Layers Distances to OtherCullingDistances
			for(int i=0; i<32; i++)
				if ((LayerCullDistances[i] == 0F)) { LayerCullDistances[i] = OtherCullingDistances; }
			
			// Update Camera Culling Properties & Values
			selfCamera.layerCullDistances = LayerCullDistances;


			if (!isUpdated)
			{
				selfCamera.layerCullSpherical = true;
				// Log Update
				Debug.Log(string.Format("[<color=yellow>DCM</color>] [<color=orange>{0}</color>] {1}", gameObject.name, "Applying Culling Distances"));
				Debug.Log(string.Format("[<color=yellow>DCM</color>] {0} <color=lightblue>{1}m</color>", "Player Culling Distance", PlayerCullingDistance));
				Debug.Log(string.Format("[<color=yellow>DCM</color>] {0} <color=lightblue>{1}m</color>", "Pickups Culling Distance", PickupCullingDistance));
				Debug.Log(string.Format("[<color=yellow>DCM</color>] {0} <color=lightblue>{1}m</color>", "Other Culling Distances", OtherCullingDistances));
			}
			//Disable this Behaviour Once Completed
			gameObject.GetComponent<SetCameraCullDistances>().enabled = false;
			isUpdated = true;
		}
	}
}
#if !COMPILER_UDONSHARP && UNITY_EDITOR
namespace SetCameraCullDistances
{
	[CustomEditor(typeof(Superbstingray.SetCameraCullDistances))]
	public class LayerCullCameraEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			if (UdonSharpGUI.DrawDefaultUdonSharpBehaviourHeader(target)) return;
			EditorGUILayout.Space();

			if (GUILayout.Button(new GUIContent("Update Camera", "Updates the attached Camera")))
			{
				Superbstingray.SetCameraCullDistances Cdst = (Superbstingray.SetCameraCullDistances)target;
				Cdst._EditorCamReset();
				Cdst._EditorCamUpdate();
			}
			EditorGUILayout.Space();
			base.OnInspectorGUI();
		}
	}
}
#endif
