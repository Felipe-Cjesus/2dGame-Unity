using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    private bool jumping = false;
    private bool check_point = false;
    private Animator animator;
    [SerializeField]
    Camera camera;
    [SerializeField]
    GameObject startPosition;
    [SerializeField]
    GameObject CheckPoint;
    [SerializeField]
    GameObject checkPoint;

    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("check_point", false);

        Debug.Log(startPosition.transform.position);
    }

    void reseta() {
        Controller.vidas--;
        if (Controller.vidas <= 0) {
            //gameover
        }
        this.transform.position = startPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        if (hAxis > 0) {
            animator.SetBool("Walking", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (hAxis == 0) {
            animator.SetBool("Walking", false);
        }
        if (hAxis < 0) {
            animator.SetBool("Walking", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        rb.transform.Translate(
            new Vector3(Mathf.Abs(hAxis) * speed * Time.deltaTime, 0f, 0f)
        );

        if (Input.GetButtonDown("Jump") && jumping == false) {
            animator.SetBool("Jumping", true);
            jumping = true;
            rb.AddForce(new Vector2(0f, jumpForce),
                ForceMode2D.Impulse);
        }

        if (transform.position.y < -10f) {
            reseta();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Chao
        if (collision.gameObject.layer == 6)
        {
            animator.SetBool("Jumping", false);
            jumping = false;
        }
        //Lava
        if (collision.gameObject.layer == 7)
        {
            reseta();
        }

        if (collision.gameObject.tag == "enemy")
        {
            reseta();
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {
            // collider.enabled = false;
            // startPosition.transform.position = checkPoint.transform.position;
            Debug.Log(startPosition.transform.position);
        }
    }

    private void LateUpdate()
    {
        camera.transform.position = new Vector3(
            this.transform.position.x,
            this.transform.position.y,
            -10f
            );
    }

}
