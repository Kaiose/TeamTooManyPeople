using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gamekit2D;
public class Shooting_Move : MonoBehaviour
{
    public PlayerCharacter pc;

    public CameraFixed cam_fixed;
    
    public float Move_Speed = 0.1f;

    public float rest_time = 1000f;

    private bool flag = false;

    public Slider time_slider;

    // Use this for initialization
    void Start()
    {
        cam_fixed = GetComponent<CameraFixed>();
    }

    // Update is called once per frame
    void Update()
    {

        if (rest_time > 0){

        if (Input.GetKey(KeyCode.W))
            transform.Translate(new Vector2(0, Move_Speed));

        if (Input.GetKey(KeyCode.S))
            transform.Translate(new Vector2(0, -Move_Speed));

        if (Input.GetKey(KeyCode.D))
            transform.Translate(new Vector2(Move_Speed, 0));

        if (Input.GetKey(KeyCode.A))
            transform.Translate(new Vector2(-Move_Speed, 0));

        }
	else
	{

         //   print("timeout");
            transform.Translate(new Vector2(0, -Move_Speed));
            Destroy(cam_fixed);
            if (flag == false)
            {
                PlayerCharacter.PlayerInstance.TimeOut();
                flag = true;
            }
         }
    }

    private void FixedUpdate()
    {
        Time_tiking();
    }

    public void Time_tiking()
    {
        if (rest_time > 0)
            rest_time = rest_time - 3.0f;
        time_slider.value = rest_time;
    }
}
