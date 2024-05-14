using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks.Sources;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    new Camera camera;
    [SerializeField]
    GameObject startPosition;
    [SerializeField]
    GameObject checkPoint;
    [SerializeField]
    GameObject checkPoint2;

    private bool jumping = false;
    //private bool check_point = false;
    private bool enterCheckPoint;
    private bool enterCheckPoint2;

    //private Collider2D collider;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("check_point", false);
        enterCheckPoint  = false;
        enterCheckPoint2 = false;
    }

    void die()
    {
        Controller.setMessage("Perdeu 1 vida :(");
        Controller.removeLife();
                
        Thread.Sleep(500);

        if (!enterCheckPoint && !enterCheckPoint2)
        {
            this.transform.position = startPosition.transform.position;
        }
        else
        {
            if(enterCheckPoint)
                this.transform.position = checkPoint.transform.position;
            
            if(enterCheckPoint2)
                this.transform.position = checkPoint2.transform.position;

        }
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        if (hAxis > 0)
        {
            animator.SetBool("Walking", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (hAxis == 0)
        {
            animator.SetBool("Walking", false);
        }
        if (hAxis < 0)
        {
            animator.SetBool("Walking", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        rb.transform.Translate(
            new Vector3(Mathf.Abs(hAxis) * playerSpeed * Time.deltaTime, 0f, 0f)
        );
        
        if (Input.GetButtonDown("Jump") && jumping == false)
        {
            animator.SetBool("Jumping", true);
            jumping = true;
            rb.AddForce(new Vector2(0f, jumpForce),
                ForceMode2D.Impulse);
        }

        if (transform.position.y < -10f)
        {
            die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Chao
        if (collision.gameObject.layer == 6 || collision.gameObject.tag == "Chao")
        {
            jumping = false;
            animator.SetBool("Jumping", false);
        }
        //Lava
        if (collision.gameObject.layer == 7 || 
            collision.gameObject.tag   == "enemy" || 
            collision.gameObject.tag == "trap")
        {
            die();
        }
        if (collision.gameObject.tag == "Finish")
        {
            Controller.setMessage("Voce completou a fase 1!!");
            Thread.Sleep(1000);
            SceneManager.LoadScene("FaseConcluida");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Chao
        if (collision.gameObject.layer == 6 || collision.gameObject.tag == "Chao")
        {
            jumping = true;
        }

        Controller.setMessage("");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {
            enterCheckPoint = true;
            Controller.setMessage("CheckPoint!");
        }

        if (collision.gameObject.tag == "CheckPoint2")
        {
            enterCheckPoint2 = true;
            Controller.setMessage("CheckPoint!");
        }
    }
    /*
    private void LateUpdate()
    {
        camera.transform.position = new Vector3(
            this.transform.position.x,
            this.transform.position.y,
            -10f
            );
    }
    */

}
