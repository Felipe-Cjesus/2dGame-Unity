using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : MonoBehaviour
{
    private float xInicial;
    //private bool esquerda = true;
    private SpriteRenderer sr;
    [SerializeField]
    private float velocidade = 1.5f;
    [SerializeField]
    private float deslocamento = 2;
    [SerializeField]
    bool esquerda;

    /*
    private Transform posicao;
    private float velocidade = 0.002f;
    //private int lado;
    [SerializeField]
    float limite;
    [SerializeField]
    bool startLeft;

    private float esquerda;
    private float direita;
    */

    // Start is called before the first frame update
    void Start()
    {
        xInicial = transform.position.x;
        sr = GetComponent<SpriteRenderer>();

        /*
        posicao = transform;
        esquerda = posicao.position.x - limite;
        direita = posicao.position.x + limite;
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (esquerda)
        {
            sr.flipX = true;
            transform.Translate(new Vector2(-velocidade, 0) * Time.deltaTime);
            if (transform.position.x < xInicial - deslocamento)
            {
                esquerda = false;
            }
        }
        else
        {
            sr.flipX = false;
            transform.Translate(new Vector2(velocidade, 0) * Time.deltaTime);
            if (transform.position.x > xInicial + deslocamento)
            {
                esquerda = true;
            }
        }

        /*
        if (!startLeft)
        {
            transform.Translate(-velocidade, 0f, 0f);
            if (transform.position.x <= esquerda) {
                startLeft = true;
            }
        }
        else {
            transform.Translate(velocidade, 0f, 0f);
            if (transform.position.x >= direita)
            {
                startLeft = false;
            }
        }
        */
        
    }
}

