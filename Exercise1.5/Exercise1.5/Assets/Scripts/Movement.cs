using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed;
    private void Start()
    {
        speed = 10f;
    }

    private void Update()
    {
        
       if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
                speed++;
            
                

                Debug.Log("The Up arrow is being pressed");
                Debug.Log(speed);
            
        }
       else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            speed--;
            Debug.Log("The down arrow is being pressed");
            Debug.Log(speed);
        }

        float horizontal = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(horizontal, 0, 0);
    }
}

