using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

public class MiudoGenerator : MonoBehaviour
{
    /* TODO : */
    [SerializeField] private Sprite[] cenarios = new Sprite[8];
    [SerializeField] private Sprite[] corpos = new Sprite[4];
    [SerializeField] private Sprite[] colares = new Sprite[6];
    [SerializeField] private Sprite[] cabecas = new Sprite[4];
    [SerializeField] private Sprite[] rostos = new Sprite[6];
    [SerializeField] private Sprite[] acessorios = new Sprite[10];
    [SerializeField] private Sprite[] MiudoMontado = new Sprite[5];

    [SerializeField] private GameObject cenario;
    [SerializeField] private GameObject corpo;
    [SerializeField] private GameObject colar;
    [SerializeField] private GameObject cabeca;
    [SerializeField] private GameObject rosto;
    [SerializeField] private GameObject acessorio;

    [SerializeField] private string[] textoFuncoes = new string[10];
    [SerializeField] private string[] textoOrigem = new string[8];

    [SerializeField] private Material[] materials = new Material[8];

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

        addTexture();
    }
    //ATENCAO -- SE FOR ADICIONAR MAIS PERGUNTAS É NECESSARIO SUBTRAIR OQ N E PARTE DE MIUDO DO INDEX COUNT
    private void iteraMatriz()
    {
        for(int i = 0; i < index.Count - 1; i++)
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

        matriz[4] = corpos;
        matriz[2] = colares;
        matriz[0] = cabecas;
        matriz[1] = rostos;
        matriz[3] = acessorios;

        int[] answers = GameManager.Instance.getMiudoAnswers();

        addIndex(answers);


        criaMiudo();
    }

    //Função que adiciona textura no miudo montado
    private void addTexture()
    {
        SpriteRenderer cen = cenario.GetComponent<SpriteRenderer>();
        cen.sprite = cenarios[(int)index[5]];

        Material mat = materials[(int)index[5]];

        corpo.GetComponent<SpriteRenderer>().material = mat;
        colar.GetComponent<SpriteRenderer>().material = mat;
        cabeca.GetComponent<SpriteRenderer>().material = mat;
        rosto.GetComponent<SpriteRenderer>().material = mat;
        acessorio.GetComponent<SpriteRenderer>().material = mat;
        cen.material = mat;

    }
}