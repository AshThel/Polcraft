using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float predkoscRuchu = 6;
    public float predkoscSkoku = 8;
    public float grawitacja = 20;
    Vector3 kierunekRuchu = Vector3.zero;

    float yObrot = 0;
    float yObr;
    float xObr;
    public float czulosc = 4;
    Camera cam;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        RuchGracza();
        ObrotMyszy();
	}

    void RuchGracza()
    {
        CharacterController postac= GetComponent<CharacterController>();

        if (postac.isGrounded)
        {
            kierunekRuchu = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            kierunekRuchu = transform.TransformDirection(kierunekRuchu);
            kierunekRuchu *= predkoscRuchu;

           if (Input.GetKeyDown(KeyCode.Space))
            {
                kierunekRuchu.y = predkoscSkoku;
            }
        }

        kierunekRuchu.y -= grawitacja * Time.deltaTime;
        postac.Move(kierunekRuchu * Time.deltaTime);
    }

    void ObrotMyszy()
    {
        yObr = -Input.GetAxis("Mouse Y") * czulosc;
        xObr = Input.GetAxis("Mouse X") * czulosc;

        yObrot *= yObr;
        yObrot = Mathf.Clamp(yObrot, -80, 80);

        if (xObr != 0)
        {
            transform.eulerAngles += new Vector3(0, xObr, 0);
        }

        if (yObr != 0)
        {
            cam.transform.eulerAngles = new Vector3(yObrot, transform.eulerAngles.y, 0);
        }
    }
}
