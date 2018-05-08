using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Place this on player in the meditation scene

public class DeepBreathingExercise : MonoBehaviour
{

    public GameObject focus;
    public GameObject BackGround;
    public Transform position;
    public HUDMessage HUD;

    private Vector3 originalScale = new Vector3(12, 12, 12);
    private Vector3 doubleScale = new Vector3(24, 24, 24);
    bool isGrowing = true;

    void Update()
    {
        Vector3 currentScale = focus.transform.localScale;
        if (isGrowing)
        {
            focus.transform.localScale += new Vector3(.07f, .07f, .07f);
        }
        else
        {
            focus.transform.localScale -= new Vector3(.04f, .04f, .04f);
        }
        if (currentScale[0] > doubleScale[0])
        {
            isGrowing = false;
        }
        if (currentScale[0] < originalScale[0])
        {
            isGrowing = true;
        }
    }

    public void BeginDeepBreathing()
    {
        StartCoroutine(DeepBreathingProcess());
    }

    IEnumerator DeepBreathingProcess()
    {
        string message1 = "Take deep breaths. Follow along with the circle";
        HUD.startHUDMessage(message1, 6f);
        //Spawn focus high above original menu and in distant view of player
        Instantiate(focus);
        Instantiate(BackGround);
        focus.transform.position = new Vector3(100, 5000, 150);
        BackGround.transform.position = new Vector3(200, 5000, 300);
        BackGround.transform.localScale += new Vector3(BackGround.transform.localScale[0]*3, BackGround.transform.localScale[1]*3, BackGround.transform.localScale[2]*3);
        //teleports player far above menu area
        gameObject.transform.position = new Vector3(0, 5000, 0);
        //originalScale = focus.transform.localScale;
        //doubleScale = new Vector3(focus.transform.localScale[0] * 2, focus.transform.localScale[1] * 2, focus.transform.localScale[2] * 2);
        yield return new WaitForSeconds(10.5f);
        string message2 = "Breathe from the belly";
        HUD.startHUDMessage(message2, 4f);
        //wait for exercise to end
        yield return new WaitForSeconds(120);
        //destroy focus object and return player to menu
        //Destroy(focus);
        //Destroy(BackGround);
        BackGround.transform.localScale += new Vector3(BackGround.transform.localScale[0] / 4, BackGround.transform.localScale[1] / 4, BackGround.transform.localScale[2] / 4);
        gameObject.transform.position = new Vector3(0, -15.21f, -18.88f);
    }
}
