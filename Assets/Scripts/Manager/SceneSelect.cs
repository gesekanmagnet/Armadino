using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSelect : MonoBehaviour
{
    public void SelectScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
