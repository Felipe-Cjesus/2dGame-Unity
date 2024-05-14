using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlataformaCinco : MonoBehaviour
{
    private float yInicial;
    public bool fall = false;
    [SerializeField]
    private float velocidade = 8;
    [SerializeField]
    private float deslocamento = 10;

    private static bool fallReset = true;

    // Start is called before the first frame update
    void Start()
    {
        yInicial = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (fall == true && fallReset == true)
        {
            this.transform.Translate(new Vector2(0, -velocidade) * Time.deltaTime);
            if (transform.position.y < -50)
                fall = false;
        }
    }
    public void fallPlatform()
    {
        yInicial = this.transform.position.y;
        fall = true;
        fallReset = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("fallPlatform", 1f);
        }
    }

    public static void setFall(bool LGvalor)
    {
        fallReset = LGvalor;
    }
}
