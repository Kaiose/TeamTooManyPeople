using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotator : MonoBehaviour {

	[SerializeField]
	private float speed = 40.0f;

	Quaternion origin;

	Coroutine flipper = null;
	// Use this for initialization
	void Start () {
		origin = transform.rotation;
	}
	
	// Update is called once per frame
	private void FixedUpdate () {
		transform.Rotate (Vector3.back* speed);
	//	StartCoroutine (flip ());
	}
	//IEnumerator flip()
	//{
	//	transform.rotation = origin;
	//	int n_frames = 100;
	//	while (n_frames-- > 0) {
	//		transform.Rotate (Vector3.forward * speed);
	//		yield return null;
	//	}
	//}
}
