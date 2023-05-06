using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class Toutorial : MonoBehaviour
{
    private string message0 = "Witaj w naszym RPG, znajdujesz sie w poradniku który nauczy cię jak grać. Gdy Nauczysz sie danej wskazówki kliknji dalej.";
    
    private string message1 = "Przy pomocy klawiszy WSAD możesz się poruszać. Wciśnij każdy z klawiszy";
    private string message5 = "Przy pomocy myszki sterujesz kierunkiem patrzenia swojej postaci, oraz wskazujesz miejsce ataku";
    private string message3 = "Gdy przytzymasz prawy przycisk myszy pojawi się obszar w którym rzucisz czar, po zwolnienu przycisku czar się wykona";
    private string message4 = "Gdy przytzymasz lewy alt możliwe będzie teleportowanie się na pewną odległość, wskazaną przez zmiane koloru koła";
    private string message2 = "aby zacząć biec naciśnij LShift";
    private string message6 = "możesz leczyć się przy podniesieniu mikstury";
    private string message7 = "aby odnowić manę możesz wypić mikturę albo uderzyć przeciwnika ręką";
    private string message8 = "Zacznimy więc gre";

    public GameObject ToutorialText;
    private int _currentmsg = 0;
    private string[] messages;
    public Button startGameButton;

    // Start is called before the first frame update
    void Start()
    {
        ToutorialText=GameObject.FindGameObjectWithTag("ToutorialText");
        startGameButton=GameObject.FindGameObjectWithTag("StartGameTButton").GetComponent<Button>();

        messages = new []{ message0,message1, message2, message3, message4, message5, message6, message7, message8 };
        ToutorialText.GetComponent<TextMeshProUGUI>().text= messages[_currentmsg];
    }

    public void NextMessage()
    {
        
        if (_currentmsg < messages.Length - 1)
        {
            _currentmsg++;
            ToutorialText.GetComponent<TextMeshProUGUI>().text = messages[_currentmsg];
        }else if (_currentmsg == messages.Length-1)
        {
            startGameButton.onClick.AddListener(GoToLevel1);
            startGameButton.GetComponentInChildren<TextMeshProUGUI>().text = "START";
            
            ToutorialText.GetComponent<TextMeshProUGUI>().text = messages[_currentmsg];
        }

      
    }
    // Update is called once per frame
    public void GoToLevel1()
    {
        Thread.Sleep(200);
        SceneManager.LoadScene("Level1");
    }
}
