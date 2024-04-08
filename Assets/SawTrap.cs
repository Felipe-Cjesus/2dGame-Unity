using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : MonoBehaviour
{
    private Transform posicao;
    private float velocidade = 0.002f;
    private int lado;
    [SerializeField]
    float limite;

    private float esquerda;
    private float direita;

    // Start is called before the first frame update
    void Start()
    {
        posicao = transform;
        lado = 0;
        esquerda = posicao.position.x - limite;
        direita = posicao.position.x + limite;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(esquerda);
        // Debug.Log(posicao.position.x);
        // Debug.Log(direita);
        // Debug.Log(" ");
        if (lado == 0)
        {
            transform.Translate(-velocidade, 0f, 0f);
            if (transform.position.x <= esquerda) {
                lado = 1;
            }
        }
        else {
            transform.Translate(velocidade, 0f, 0f);
            if (transform.position.x >= direita)
            {
                lado = 0;
            }
        }
        
    }
}

