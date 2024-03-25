using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("saiu do jogo");
        Application.Quit();
    }
}
