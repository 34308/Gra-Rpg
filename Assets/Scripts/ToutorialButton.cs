using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class ToutorialButton : MonoBehaviour
{
    public void GoToToutorial()
    {
        Thread.Sleep(200);
        SceneManager.LoadScene("Top Down Movement");
    }
}
