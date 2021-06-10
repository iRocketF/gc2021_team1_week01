using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
        Cursor.visible = false;
    }

    public void Quit()
    {
        Debug.Log("Quit game pressed");
        Application.Quit();
    }
}
