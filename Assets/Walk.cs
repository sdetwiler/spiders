using UnityEngine;
using System.Collections;

public class Walk : MonoBehaviour {
	private Vector3 target;
	public float speed=0.000001f;
//	private SphereCollider objCollider;

	void SetSpeed()
	{
		Animation anim = gameObject.GetComponent<Animation>();

		foreach (AnimationState state in anim) {
			if(state.name.Equals("walk"))
			{
//				state.speed = 10.8f;
			}
//			Debug.Log (state.name);
		}
	}

	// Use this for initialization
	void Start () {
//		Debug.Log ("Walk Start");
		SetSpeed ();
		Animation anim = gameObject.GetComponent<Animation>();
		anim.Play("walk");

		PickTarget();
	}

	void PickTarget() {
		float s = 10.0f;
//		Debug.Log ("PickTarget");
		target = new Vector3(Random.Range(-s, s), transform.localPosition.y, Random.Range(-s, s));
		//		Debug.Log(target);
	}

	void Update() {


		float step = Time.deltaTime *0.25f;

		Vector3 newPos = Vector3.MoveTowards(transform.localPosition, target, step);
		newPos.y = -0.12f;
		transform.localPosition = newPos;

		//		Debug.Log (transform.position);
		float rotSpeed = 6.0f;
		var targetRotation = Quaternion.LookRotation(target - transform.localPosition);
		transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, rotSpeed * Time.deltaTime);

		if( transform.localPosition == target)
		{
			PickTarget();
		}
	}

	void OnCollisionEnter(Collision collision) {
//		Debug.Log ("Collision");
		Animation anim = gameObject.GetComponent<Animation>();
		string attack = "attack" + Random.Range (1,2).ToString();
		anim.Play (attack);
		anim.PlayQueued("walk");
		PickTarget();
	}

	void OnTriggerEnter(Collider collider) {
		Debug.Log ("Trigger");
	}
}
