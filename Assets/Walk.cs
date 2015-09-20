using UnityEngine;
using System.Collections;

public class Walk : MonoBehaviour {
	private Vector3 target;
	public float speed=0.1f;
//	private SphereCollider objCollider;
	
	// Use this for initialization
	void Start () {
//		Debug.Log ("Walk Start");
		Animation anim = gameObject.GetComponent<Animation>();
		foreach (AnimationState state in anim) {
			if(state.name.Equals("walk"))
			{
//				state.speed = 0.8f;
			}
			Debug.Log (state.name);
		}
		anim.Play("walk");

		PickTarget();
	}

	void PickTarget() {
		float s = 10.0f;
//		Debug.Log ("PickTarget");
		target = new Vector3(Random.Range(-s, s), 0.0f, Random.Range(-s, s));
//		Debug.Log(target);
	}

	void Update() {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target, step);

		float rotSpeed = 6.0f;
		var targetRotation = Quaternion.LookRotation(target - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);

		if( transform.position == target)
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
//		Debug.Log ("Trigger");
	}
}
