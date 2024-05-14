using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControllerGameOver : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textoGameOver;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Controller.countPoints.ToString());
        textoGameOver.text = "GAME OVER \n" + " Pontos: " + Controller.countPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
