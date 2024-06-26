using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCheckPoint : MonoBehaviour
{
    private new Collider2D collider;
    private Animator animator;
    private Transform posicaoCheckPoint;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        animator.SetBool("animation_flag", false);

        posicaoCheckPoint = transform;

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
            animator.SetBool("animation_flag", true);
        }
    }
}
