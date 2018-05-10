using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gamekit2D;


public class Shooting_Move : MonoBehaviour
{
    public PlayerCharacter pc;
    public CameraFixed cam_fixed;    
    public float Move_Speed = 1.5f;
    public float rest_time = 1000f;
    private bool flag = false;
    public Slider time_slider;
    public GameObject cloude;
    public GameObject bumb;

    public Transform stop;
    private bool stop_;

    // Use this for initialization
    void Start()
    {
        stop_ = true;
        cam_fixed = GetComponent<CameraFixed>();
    }
    
    private void FixedUpdate()
    {
        if (transform.position.x < stop.position.x)
        {
            Time_tiking();
            if(stop_ == true)
            transform.Translate(new Vector2(+0.06f, 0));
        }

        if (rest_time > 0)
        {
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
            stop_ = false;
            transform.Translate(new Vector2(0, -Move_Speed * 1.5f));
            Destroy(cam_fixed);
            if (flag == false)
            {
                PlayerCharacter.PlayerInstance.TimeOut();
                flag = true;
            }
            Destroy(cloude);
            bumb.SetActive(true);
            bumb.transform.Translate(new Vector2(0, +Move_Speed * 1.5f));
        }
    }

    public void Time_tiking()
    {
        rest_time = rest_time - 0.75f;            
    
        time_slider.value = rest_time;         
    }
}
