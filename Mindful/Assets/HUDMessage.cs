using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDMessage : MonoBehaviour {

    private Text HUD;
    private int frameNum = 0;

	// Use this for initialization
	void Start () {
        HUD = GetComponent<Text>();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            HUD.CrossFadeAlpha(0.0f, 0.0f, false);
            StartCoroutine(SendHUDMessage("Relax and click the bowl when you're ready", 8));
        }
	}
	
	// Update is called once per frame
	void Update () {
        frameNum++;
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (frameNum % 9000 == 0)
            {
                StartCoroutine(SendHUDMessage("Relaxed yet? Click the bowl to continue", 8));
            }
        }
        
	}

    public void startHUDMessage(string message, float time)
    {
        StartCoroutine(SendHUDMessage(message, time));
    }

    IEnumerator SendHUDMessage(string message, float time)
    {
        HUD = GetComponent<Text>();
        HUD.text = message;
        HUD.CrossFadeAlpha(1.0f, 1.0f, false);
        yield return new WaitForSeconds(time);
        HUD.CrossFadeAlpha(0.0f, 1.0f, false);
    }
}
