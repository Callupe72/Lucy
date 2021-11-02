using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerData[] players;
    public MiniGame[] gamesToLoad;
    [HideInInspector]public int oldGameLoaded = -1;
    public TextMeshProUGUI miniGameTxt;

    public static GameManager Instance;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        //UduinoManager.Instance.pinMode(3, PinMode.Output);  // setup du pin 3 pour �criture
        //UduinoManager.Instance.digitalWrite(3, State.HIGH); // allume "une led"
        //UduinoManager.Instance.digitalWrite(3, State.LOW); // eteint

        LoadGame(0);
    }

    public void LoadGame(int indexLoadGame)
    {
        miniGameTxt.text = gamesToLoad[indexLoadGame].miniGameName;
        if (oldGameLoaded != -1)
            gamesToLoad[oldGameLoaded].gameObject.SetActive(false);
        gamesToLoad[indexLoadGame].gameObject.SetActive(true);
        oldGameLoaded = indexLoadGame;
    }
}
