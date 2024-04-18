using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private static int[] bodyParts;

    int actualScene;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setMiudoAnswers(int[] answers)
    {
        bodyParts = new int[answers.Length];

        for (int i = 0;i < answers.Length;i++)
        {
            bodyParts[i] = answers[i];
        }

        SceneManager.LoadScene("MiudoGeracao");
    }

    public int[] getMiudoAnswers()
    {
        return bodyParts;
    }
}
