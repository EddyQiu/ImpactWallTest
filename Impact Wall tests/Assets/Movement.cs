using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    const float MAXVELOCITY = 2.0f;

    public GameObject Speed_GO;
    private Text Speed_Text;

    [Range(0.0f, 10.0f)]
    public float speed = 5.0f;
    float velocity;

    GameObject character;

    Vector2 MouseLook;
    Vector2 SmoothV;
    Vector2 MouseDir;

    public float sensitivity = 2.0f;
    public float smoothing = 2.0f;


    // Use this for initialization
    void Start () {
        Speed_Text = Speed_GO.GetComponent<Text>();
        Cursor.lockState = CursorLockMode.Locked;
        character = this.transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {

        MouseDir = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));


        MouseDir = Vector2.Scale(MouseDir, new Vector2(sensitivity * smoothing, sensitivity * smoothing));


        SmoothV.x = Mathf.Lerp(SmoothV.x, MouseDir.x, 1f / smoothing);
        SmoothV.y = Mathf.Lerp(SmoothV.y, MouseDir.y, 1f / smoothing);
        MouseLook += SmoothV;

        MouseLook.y = Mathf.Clamp(MouseLook.y, -90.0f, 90.0f);
        transform.localRotation = Quaternion.AngleAxis(-MouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(MouseLook.x, character.transform.up);

        if (velocity > 0)
        {
            character.transform.position += transform.forward * Time.deltaTime * velocity;
            velocity -= 0.5f;
        }
        else if (velocity < 0)
            velocity = 0;




        if (Speed_Text != null)
            Speed_Text.text = ("" + velocity);

        // if (velocity > 0 && velocity < 1)
        //transform.position = transform.forward * Time.deltaTime * velocity;

        if (Input.GetKey(KeyCode.W) && velocity < MAXVELOCITY)
            velocity += speed;


	}

    
}
