using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
//using UnityEditor.VersionControl;
using System.Reflection;
using System.Collections;
using Unity.VisualScripting;
using static System.Net.Mime.MediaTypeNames;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreBoard;
    //[SerializeField]
    //private TextMeshProUGUI messageFrame;

    [SerializeField]
    private static TMP_Text messageFrame;

    [SerializeField]
    private static TMP_Text playerName;

    public static int countPoints;
    public static int countLife;
    public static string message;

    public float duracaoMensagem = 2f; // Duração da mensagem em segundos
    private static GameObject plataforma1;
    private static GameObject plataforma2;
    private static GameObject plataforma3;
    private static GameObject plataforma4;
    private static GameObject plataforma5;

    private static Vector3 xyPlataforma1;
    private static Vector3 xyPlataforma2;
    private static Vector3 xyPlataforma3;
    private static Vector3 xyPlataforma4;
    private static Vector3 xyPlataforma5;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("TextoMenssagem");
        messageFrame  = go.GetComponent<TMP_Text>();

        GameObject gameObj = GameObject.FindGameObjectWithTag("NamePlayer");
        playerName         = gameObj.GetComponent<TMP_Text>();

        GameObject goPlataforma1 = GameObject.FindGameObjectWithTag("PlataformaUm");
        plataforma1 = goPlataforma1;

        GameObject goPlataforma2 = GameObject.FindGameObjectWithTag("PlataformaDois");
        plataforma2 = goPlataforma2;

        GameObject goPlataforma3 = GameObject.FindGameObjectWithTag("PlataformaTres");
        plataforma3 = goPlataforma3;

        GameObject goPlataforma4 = GameObject.FindGameObjectWithTag("PlataformaQuatro");
        plataforma4 = goPlataforma4;

        GameObject goPlataforma5 = GameObject.FindGameObjectWithTag("PlataformaCinco");
        plataforma5 = goPlataforma5;

        xyPlataforma1 = plataforma1.transform.localPosition;
        xyPlataforma2 = plataforma2.transform.localPosition;
        xyPlataforma3 = plataforma3.transform.localPosition;
        xyPlataforma4 = plataforma4.transform.localPosition;
        xyPlataforma5 = plataforma5.transform.localPosition;

        //Debug.Log(xyPlataforma1);

        newGame();

        if (MenuController.namePlayer.text != null)
        {
            if (MenuController.namePlayer.text == "")
                MenuController.namePlayer.text = "Player 1";

            playerName.text = "Player: " + MenuController.namePlayer.text; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (countLife == 0)
        {
            scoreBoard.text = "GAME OVER" + "\nPontos: " + countPoints.ToString();
        }
        else
        {
            scoreBoard.text = "Pontos: " + countPoints.ToString() + " \nVidas: " + countLife.ToString();
        }

        //Invoke("LimparMensagem", 2f);
        //messageFrame.text = message;
    }

    void LimparMensagem()
    {
        // Limpa a mensagem da tela
        messageFrame.text = "";
    }

    public static void removeLife()
    {
        countLife--;

        posicionaPlataforma();

        PlataformaUm.setFall(false);
        PlataformaDois.setFall(false);
        PlataformaTres.setFall(false);
        PlataformaQuatro.setFall(false);
        PlataformaCinco.setFall(false);
        

        if (countLife <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public static void setPoints(int ponto)
    {
        countPoints += ponto;
    }
    public static void setLife(int life)
    {
        countLife += life;
    }

    public static void newGame()
    {
        countPoints = 0;
        countLife = 3;
    }

    public static void setMessage(string msg)
    {
        messageFrame.text = msg;
    }

    public static void setNamePlayer(string name)
    {
        playerName.text = name;
    }

    public static void posicionaPlataforma()
    {
        plataforma1.transform.localPosition = xyPlataforma1;
        plataforma2.transform.localPosition = xyPlataforma2;
        plataforma3.transform.localPosition = xyPlataforma3;
        plataforma4.transform.localPosition = xyPlataforma4;
        plataforma5.transform.localPosition = xyPlataforma5;
    }
}