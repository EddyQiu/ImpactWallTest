﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menu : MonoBehaviour {

    public static bool isMenuOpen = false;

    [SerializeField]
    GameObject sens_GO;
    [SerializeField]
    GameObject sm_GO;

    public GameObject panel_GO;

    public GameObject player_GO;
    Movement movement;

    public Slider sens_Slider;
    public Slider sm_Slider;

	// Use this for initialization
	void Start () {
        sens_Slider = sens_Slider.GetComponent<Slider>();
        sm_Slider = sm_Slider.GetComponent<Slider>();
        movement = player_GO.GetComponent<Movement>();

        sens_Slider.onValueChanged.AddListener(delegate { SetSensitivity(); });
        sm_Slider.onValueChanged.AddListener(delegate { SetSmoothing(); });

        panel_GO.SetActive(false);

    }

    void Update()
    {

       // if (Input.GetAxisRaw("Fire1") != 0 && !Menu.isMenuOpen)
            //Cursor.lockState = CursorLockMode.Locked;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == 0)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;

            isMenuOpen = !isMenuOpen;
            panel_GO.SetActive(isMenuOpen);

        }
    }
	
    void SetSensitivity()
    {
        if (movement != null)
        {
            movement.sensitivity = sens_Slider.value;
            Text t = sens_GO.GetComponentInChildren<Text>();
            if (t != null)
                t.text = "" + sens_Slider.value;
                
        }          
    }

    void SetSmoothing()
    {
        if (movement != null)
        {
            movement.smoothing = sm_Slider.value;
            Text t = sm_GO.GetComponentInChildren<Text>();
            if (t != null)
                t.text = "" + sm_Slider.value;
        }
    }
}
