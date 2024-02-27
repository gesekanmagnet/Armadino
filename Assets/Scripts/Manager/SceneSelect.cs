using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSelect : MonoBehaviour
{
    public void SelectScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
