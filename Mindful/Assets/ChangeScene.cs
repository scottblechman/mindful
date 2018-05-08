using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void changeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}