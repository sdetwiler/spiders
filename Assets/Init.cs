using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {

	public int NumSpiders = 1;
	// Use this for initialization
	void Start () {
		for(int i=0; i<NumSpiders; ++i)
		{
			GameObject instance = Instantiate(Resources.Load("spider", typeof(GameObject))) as GameObject;
			instance.transform.parent = gameObject.transform;
			float s = 2.0f;
			instance.transform.position = new Vector3(Random.Range(-s, s), 0.0f, Random.Range(-s, s));
			float scale = 0.15f;
			instance.transform.localScale = new Vector3(scale,scale,scale);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
