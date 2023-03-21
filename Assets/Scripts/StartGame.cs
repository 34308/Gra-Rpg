using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void GoToTopDownMovement()
    {
        Thread.Sleep(200);
        SceneManager.LoadScene("Top Down Movement");
    }
}
