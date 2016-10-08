using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            show = true;
        }
    }

    // 200x300 px window will apear in the center of the screen.
    private Rect windowRect = new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 200, 300);
    // Only show it if needed.
    private bool show = false;

    void OnGUI()
    {
        if (show)
            windowRect = GUI.Window(0, windowRect, DialogWindow, "Game Over");
    }

    // This is the actual window.
    void DialogWindow(int windowID)
    {
        float y = 20;
        GUI.Label(new Rect(5, y, windowRect.width, 20), "Again?");
        y += 20;

        if (GUI.Button(new Rect(5, y, windowRect.width - 10, 20), "Restart"))
        {
            SceneManager.LoadScene(0);
            show = false;
        }

        y += 20;
        if (GUI.Button(new Rect(5, y, windowRect.width - 10, 20), "Exit"))
        {
            Application.Quit();
            show = false;
        }
    }

}
