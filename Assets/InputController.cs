using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{


		if (Input.GetButton ("PS4_PS")) {
			Application.Quit();
		}

		// Translate camera.
		float leftX = Input.GetAxis ("PS4_LeftStickX");
		float leftY = Input.GetAxis ("PS4_LeftStickY");

		// Zoom camera.
		float l2 = Input.GetAxis ("PS4_L2");
		float r2 = Input.GetAxis ("PS4_R2");

		float dz = 0;
		// L2 pressed
		if (l2 > 0) {
			dz+=l2;
		}

		if (r2 > 0) {
			dz -= r2;
		}

//		float axis = Input.GetAxis (n);
//		Debug.LogFormat ("{0}, {1}", l2, r2);
		Vector3 newPos = gameObject.transform.position;
		newPos.x += leftX;
		newPos.y +=dz;
		newPos.z += leftY;
	
		gameObject.transform.position = newPos;
	}
}
