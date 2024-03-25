using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField]
    private string próximaCena;
    void Start()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(próximaCena);
    }
}
