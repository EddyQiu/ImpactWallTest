using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    const float MAXVELOCITY = 2.0f;

    [Range(0.0f, 10.0f)]
    public float speed = 5.0f;
    float velocity;

    GameObject character;

    Vector2 MouseLook;
    Vector2 SmoothV;
    Vector2 MouseDir;

    public float sensitivity = 2.0f;
    public float smoothing = 2.0f;

    float translation;
    float strafe;


    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        character = transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {

        //If the menu isn't open then allow the player to freely look around.
        if (!Menu.isMenuOpen)
        {
            MouseDir = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            MouseDir = Vector2.Scale(MouseDir, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

            //Calculates the smoothing 
            SmoothV.x = Mathf.Lerp(SmoothV.x, MouseDir.x, 1f / smoothing);
            SmoothV.y = Mathf.Lerp(SmoothV.y, MouseDir.y, 1f / smoothing);
            MouseLook += SmoothV;

            //Stops the camera from rotating all the way around
            MouseLook.y = Mathf.Clamp(MouseLook.y, -90.0f, 90.0f);
            transform.localRotation = Quaternion.AngleAxis(-MouseLook.y, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(MouseLook.x, character.transform.up);
        }

        
        if (velocity > 0)
        {
            translation = Input.GetAxisRaw("Vertical") * velocity;
            strafe = Input.GetAxisRaw("Horizontal") * velocity;
            translation *= Time.deltaTime;
            strafe *= Time.deltaTime;

            character.transform.Translate(strafe, 0, translation);
            velocity -= 0.5f;
        }
        else if (velocity < 0)
            velocity = 0;

        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && velocity < MAXVELOCITY)
            velocity += speed;



	}

    
}
