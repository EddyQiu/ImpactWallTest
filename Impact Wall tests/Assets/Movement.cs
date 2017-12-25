using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    float velocity;
    private Vector3 v3RotX = new Vector3(0.0f ,1.0f, 0);
    private Vector3 v3RotY = new Vector3(1.0f, 0, 0);

    Vector2 mousePos;
    Vector2 lastPos;

    public GameObject Speed_GO;
    private Text Speed_Text;

    // Use this for initialization
    void Start () {
        Speed_Text = Speed_GO.GetComponent<Text>();
        mousePos = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {

        mousePos = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        //  Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.Log(mousePos.x + " and " + mousePos.y);

        if (mousePos.x > 0)
            transform.Rotate(v3RotX);
        else if (mousePos.x < 0)
            transform.Rotate(-v3RotX);



        // if (mousePos.y > 0)
        // transform.Rotate(-v3RotY);
        //else if (mousePos.y < 0)
        //transform.Rotate(v3RotY);




        if (Speed_Text != null)
            Speed_Text.text = ("" + velocity);

        // if (velocity > 0 && velocity < 1)
        //transform.position = transform.forward * Time.deltaTime * velocity;

        if (Input.GetKey(KeyCode.W) && velocity < 1)
            velocity += 0.1f;
        else if (velocity > 0)
            velocity -= 0.05f;
        else
            velocity = 0;
        
      
	}

    
}
