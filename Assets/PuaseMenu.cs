using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuaseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeGame()
    {
        Debug.Log("resume");
        Time.timeScale = 1;
        gameObject.SetActive(false);    
    }
    public void ExitGame()
    {
        Thread.Sleep(200);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }
}
