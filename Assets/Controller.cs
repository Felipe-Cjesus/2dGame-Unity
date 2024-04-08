using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI texto;

    public static int contador = 0;
    public static int vidas = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vidas == 0) {
            texto.text = "GAME OVER" + "\nPontos: " + contador.ToString();
        } 
        else {
            texto.text = "Pontos: " + contador.ToString() + " \nVidas: " + vidas.ToString();
        } 
    }
}
