using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("JogarNovamente");
        Button btnPlayAgain = go.GetComponent<Button>();
        btnPlayAgain.onClick.AddListener(PlayAgain);

        GameObject goObj = GameObject.FindGameObjectWithTag("ProximaFase");
        Button btnNextPhase = goObj.GetComponent<Button>();
        btnNextPhase.onClick.AddListener(NextPhase);
    }

    // Update is called once per frame
    void PlayAgain()
    {
        SceneManager.LoadScene("Fase1");
    }
    void NextPhase()
    {
        SceneManager.LoadScene("Fase1");
    }
}
