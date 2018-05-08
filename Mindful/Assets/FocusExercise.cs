using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Place this on player in the meditation scene

public class FocusExercise : MonoBehaviour {

    public GameObject focus;
    public Transform position;
    public HUDMessage HUD;

    public void BeginFocus()
    {
        StartCoroutine(FocusProcess());
    }

    IEnumerator FocusProcess()
    {
        string message1 = "“If your eyeballs move, this means that you’re thinking, or about to start thinking. If you don’t want to be thinking at this particular moment, try to keep your eyeballs still.” –Lydia Davis";
        HUD.startHUDMessage(message1, 10f);
        //Spawn focus high above original menu and in distant view of player
        Instantiate(focus);
        focus.transform.position = new Vector3(-750, 5000, 500);
        //teleports player far above menu area
        gameObject.transform.position = new Vector3(0, 5000, 0);
        yield return new WaitForSeconds(10.5f);
        string message2 = "Look at the dot for one minute";
        HUD.startHUDMessage(message2, 4f);
        //wait for exercise to end
        yield return new WaitForSeconds(60);
        //destroy focus object and return player to menu
        //Destroy(focus);
        gameObject.transform.position = new Vector3(0, -15.21f, -18.88f);
    }
}
