using UnityEngine;
using System.Collections;

public class RenderToggle : MonoBehaviour {

	public bool EnableRendering = true;

	private bool pressed = false;

	// Use this for initialization
	void Start () {
		SetRenderingMode (EnableRendering);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("PS4_Triangle")) {
			if (!pressed) {
				pressed = true;
				ToggleRendering ();
			}
		} else {
			pressed = false;
		}



	
	}

	void SetRenderingMode(bool mode) {
		MeshRenderer[] renderers = gameObject.GetComponentsInChildren<MeshRenderer>();

		foreach (MeshRenderer r in renderers) {
			r.enabled = mode;
		}

	}

	void ToggleRendering() {
		EnableRendering = !EnableRendering;
		SetRenderingMode (EnableRendering);
	}
}
