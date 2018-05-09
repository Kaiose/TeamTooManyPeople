using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting_move : MonoBehaviour
{

	public float Move_Speed = 0.1f;

	public float rest_time = 1000f;

	public Slider time_slider;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		// if (rest_time > 0){

		if (Input.GetKey(KeyCode.W))
			transform.Translate(new Vector2(0, Move_Speed));

		if (Input.GetKey(KeyCode.S))
			transform.Translate(new Vector2(0, -Move_Speed));

		if (Input.GetKey(KeyCode.D))
			transform.Translate(new Vector2(Move_Speed, 0));

		if (Input.GetKey(KeyCode.A))
			transform.Translate(new Vector2(-Move_Speed, 0));

		/*}
	else
	{
		transform.Translate(new Vector2(0, -Move_Speed));
	}*/
	}

	private void FixedUpdate()
	{
		Time_tiking();
	}

	public void Time_tiking()
	{
		if (rest_time > 0)
			rest_time = rest_time - 0.5f;
		time_slider.value = rest_time;
	}
}
