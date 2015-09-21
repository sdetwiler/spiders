using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	Vector3 at = new Vector3(0,0,0);
	// https://www.reddit.com/r/Unity3D/comments/1syswe/ps4_controller_map_for_unity/

	// Update is called once per frame
	void Update ()
	{
		Camera cam = gameObject.GetComponent<Camera> ();
		GameObject plane = GameObject.Find ("House");

		if (Input.GetButton ("PS4_PS")) {
			Application.Quit();
		}

		// Depth of field.
		float dpadX = Input.GetAxis ("PS4_DPadX");
		cam.fieldOfView += dpadX;

		// Translate camera.
		float leftX = Input.GetAxis ("PS4_LeftStickX");
		float leftY = Input.GetAxis ("PS4_LeftStickY");

		// Zoom camera.
		float l2 = Input.GetAxis ("PS4_L2");
		float r2 = Input.GetAxis ("PS4_R2");

		// Rot camera.
		float rightX = Input.GetAxis ("PS4_RightStickX");
		float rightY = Input.GetAxis ("PS4_RightStickY");
		Debug.LogFormat ("{0} {1}", rightX, rightY);

		float dz = 0;
		// L2 pressed
		if (l2 > 0) {
			dz+=l2;
		}

		if (r2 > 0) {
			dz -= r2;
		}

		Vector3 newPos = gameObject.transform.position;
		newPos.x += leftX;
		newPos.y +=dz;
		newPos.z -= leftY;
		gameObject.transform.position = newPos;


		Quaternion newPlaneRot = plane.transform.rotation;
		Vector3 angles = plane.transform.rotation.eulerAngles;
		angles.x += rightY;
		angles.z += rightX;
		newPlaneRot.eulerAngles = angles;
		plane.transform.rotation = newPlaneRot;


//		at.x += rightX;
//		at.z += rightY;
//		gameObject.transform.LookAt (at);
//
//		if (rightX!=0f || rightY!=0f) {
//			Vector3 newRot = gameObject.transform.rotation.eulerAngles;
//			newRot.z += rightX;
//			newRot.y += rightY;
//			
//			Quaternion r = gameObject.transform.rotation;
//			r.eulerAngles = newRot;
//			
//			gameObject.transform.rotation = r;
//		}
	}
}
