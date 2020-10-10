using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private bool canMove;
    private float move_Speed = 2.7f;
    private float min_x = -2.4f, max_x = 2.4f;
    private bool bird_direction;
    
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        bird_direction = true;

    }

    // Update is called once per frame
    void Update()
    {
        MoveBird();
    }

    void MoveBird()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += move_Speed * Time.deltaTime;;

            if ((temp.x >= max_x) && (bird_direction == true))
            {
                move_Speed *= -1f;
                transform.Rotate(0f, 180f, 0f);
                bird_direction = false;
            }
            else if ((temp.x <= min_x) && (bird_direction==false))
            {
                move_Speed *= -1f;
                transform.Rotate(0f, 180f, 0f);
                bird_direction = true;
            }

            transform.position = temp;
        }
    }
}
