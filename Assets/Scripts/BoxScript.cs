using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxScript : MonoBehaviour
{
    private GameObject score;
    private float min_x = -2.3f, max_x = 2.3f;

    private bool canMove;
    private float move_Speed = 2f;

    private Rigidbody2D myBody;

    private bool gameOver;
    private bool ignoreCollision;
    private bool ignoreTrigger;

    
    private void Awake()
    {

        myBody = GetComponent<Rigidbody2D>();
        myBody.gravityScale = 0f;//left-right moving should be without falling down
        
    }

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindWithTag("Score");
        ResetMoveSpeed(); 

        canMove = true;

        if(Random.Range(0,2)>0)
        {
            move_Speed *= -1f;
        }

        GameplayController.instance.currentBox = this;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBox();
    }

    public void ResetMoveSpeed()
    {
        move_Speed = 3 + score.GetComponent<Score>().scoreGame / 2;
    }

    void NoGravity()
    {
        myBody.gravityScale = 0;
        myBody.angularDrag = 0;
        myBody.drag = 0;
        myBody.mass = 999;
        myBody.transform.Rotate(0, 0, 0);
        //Vector3 temp = myBody.transform.position;
        //temp[1] = score.GetComponent<Score>().scoreGame - 4f;
        //myBody.transform.position = temp;
    }


    void MoveBox()
    {
        if(canMove)
        {
            Vector3 temp = transform.position;
            temp.x += move_Speed * Time.deltaTime;

            if(temp.x >= max_x && move_Speed > 0)
            {
                move_Speed *= -1f;
            }
            else if (temp.x <= min_x && move_Speed < 0)
            {
                move_Speed *= -1f;
            }

            transform.position = temp;
        }
    }

    public void DropBox()
    {
        canMove = false;
        myBody.gravityScale = 3;
    }

    public void Landed()
    {
        if (gameOver) return;

        ignoreCollision = true;
        ignoreTrigger = true;

        GameplayController.instance.SpawnNewBox();
    }

    void RestartGame()
    {
        GameplayController.instance.RestartGame();
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollision) return;

        if (target.gameObject.tag == "Platform")
        {
            GameplayController.instance.MoveCamera2();
            Invoke("NoGravity", 2f);
            Invoke("Landed", 2f);
            ignoreCollision = true;
        }

        if (target.gameObject.tag == "Box")
        {
            GameplayController.instance.MoveCamera2();
            Invoke("NoGravity", 2f);
            Invoke("Landed", 2f);
            ignoreCollision = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (ignoreTrigger) return;

        if (target.tag == "GameOver")
        {
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;

            Invoke("RestartGame", 1f);

        }
    }


}
