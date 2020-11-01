using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartNewGame()
    {
        print("Sobir");
        SceneManager.LoadScene("__MAIN__");
    }
    
    public void Quit()
    {

        print("Wypad");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
