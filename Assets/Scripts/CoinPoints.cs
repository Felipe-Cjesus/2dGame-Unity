using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPoints : MonoBehaviour
{
    private Collider2D collider;
    private Animator animator;

    [SerializeField]
    private int valueCoin = 50;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collider.enabled = false;
            Destroy(this.gameObject, 0.9f);
            animator.SetBool("collectedCoin", true);
            
            Controller.setPoints(valueCoin);
        }
    }
}
