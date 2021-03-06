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

    [SerializeField]
    Text win_Text;

    public GameObject panel_GO;
    public GameObject player_GO;

    Movement movement;

    public Slider sens_Slider;
    public Slider sm_Slider;

    bool cursor_Locked;

    static public float killCount;
    static public bool winState;

	// Use this for initialization
	void Start () {
        sens_Slider = sens_GO.GetComponent<Slider>();
        sm_Slider = sm_GO.GetComponent<Slider>();
        movement = player_GO.GetComponentInChildren<Movement>();

        sens_Slider.onValueChanged.AddListener(delegate { SetSensitivity(); });
        sm_Slider.onValueChanged.AddListener(delegate { SetSmoothing(); });

        panel_GO.SetActive(false);
        cursor_Locked = true;

        winState = false;
        killCount = 0;

    }

    void Update()
    {
        #if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Tab))
                ToggleMenu();
        #endif

        #if UNITY_STANDALONE && !UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Escape))
                ToggleMenu();
        #endif

        if (winState && win_Text != null)
            win_Text.text = "END GAME";

    }

    void ToggleMenu()
    {
      cursor_Locked = !cursor_Locked;
      if (cursor_Locked)
      {
          Cursor.lockState = CursorLockMode.Locked;
          isMenuOpen = false;
          panel_GO.SetActive(false);
          Time.timeScale = 1;
      }
      else
      {
          Cursor.lockState = CursorLockMode.None;
          isMenuOpen = true;
          panel_GO.SetActive(true);
          Time.timeScale = 0;
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

    public void Close()
    {
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
    }
}
