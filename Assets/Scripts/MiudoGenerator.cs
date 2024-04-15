using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

public class MiudoGenerator : MonoBehaviour
{
    /* TODO : */
    [SerializeField] private Sprite[] corpos = new Sprite[4];
    [SerializeField] private Sprite[] colares = new Sprite[6];
    [SerializeField] private Sprite[] cabecas = new Sprite[4];
    [SerializeField] private Sprite[] rostos = new Sprite[6];
    [SerializeField] private Sprite[] acessorios = new Sprite[10];
    [SerializeField] private Sprite[] MiudoMontado = new Sprite[5];
    [SerializeField] private GameObject corpo;
    [SerializeField] private GameObject colar;
    [SerializeField] private GameObject cabeca;
    [SerializeField] private GameObject rosto;
    [SerializeField] private GameObject acessorio;
    [SerializeField] private string[] textoFuncoes = new string[10];
    [SerializeField] private string[] textoOrigem = new string[8];
    private GameObject[] PartesMiudas;
    private Sprite[][] matriz = new Sprite[5][];
    private ArrayList index = new ArrayList();

    public void criaMiudo()
    {
        iteraMatriz();
        PartesMiudas = new GameObject[5] { corpo, colar, cabeca, rosto, acessorio };
        for(int i = 0; i < MiudoMontado.Length; i++)
        {
            PartesMiudas[i].GetComponent<SpriteRenderer>().sprite = MiudoMontado[i];
        }
    }

    private void iteraMatriz()
    {
        for(int i = 0; i < index.Count;i++)
        {
            MiudoMontado[i] = matriz[i][(int)index[i]];
        }
    }

    public void addIndex(int[] n)
    {
        for (int i = 0; i < n.Length; i++)
        {
            index.Add(n[i]);
        }
    }

    private void Start()
    {

        matriz[0] = corpos;
        matriz[1] = colares;
        matriz[2] = cabecas;
        matriz[3] = rostos;
        matriz[4] = acessorios;

        //int[] exemplo = { 1, 1, 2, 3, 3 };
        //addIndex(exemplo);

        int[] answers = GameManager.Instance.getMiudoAnswers();

        addIndex(answers);


        criaMiudo();
    }
}