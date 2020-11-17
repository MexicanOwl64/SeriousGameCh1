using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    introMover walker;

    private GameObject mover;



    void Start()
    {
        walker = new introMover();
    }

    
    void Update()
    {
       
        walker.step();
        walker.CheckEdges();
        
    }
}


public class introMover
{
    private Vector2 location = new Vector2(0F, 0F);
    private Vector2 velocity = new Vector2(0.1F, 0.1F);


    private Vector2 minimumPos, maximumPos;





    // Gives the class a GameObject to draw on the screen
    public GameObject mover; 

    public introMover()
    {
        findWindowLimits();
        location = Vector2.zero;
        
         
}

    public void step()
    {
         
    bool xHitBorder = location.x > maximumPos.x || location.x < minimumPos.x;
        bool yHitBorder = location.y > maximumPos.y || location.y < minimumPos.y;

       

        if (xHitBorder)
        {
            velocity.x = -velocity.x;
        }

        if (yHitBorder)
        {
            velocity.y = -velocity.y;
        }

        // Lets now update the location of the mover
        location += velocity;

        // Now we apply the positions to the mover to put it in it's place
        mover.transform.position = new Vector2(location.x, location.y);
    }

    public void CheckEdges()
    {
        location = mover.transform.position;

        if (location.x > maximumPos.x)
        {
            location = Vector2.zero;
        }
        else if (location.x < minimumPos.x)
        {
            location = Vector2.zero;
        }
        if (location.y > maximumPos.y)
        {
            location = Vector2.zero;
        }
        else if (location.y < minimumPos.y)
        {
            location = Vector2.zero;
        }
        mover.transform.position = location;
    }

    private void findWindowLimits()
    {
        // We want to start by setting the camera's projection to Orthographic mode
        Camera.main.orthographic = true;

        // Next we grab the minimum and maximum position for the screen
        minimumPos = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maximumPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        // We now can set the mover as a primitive sphere in unity
        mover = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //We need to create a new material for WebGL
        Renderer r = mover.GetComponent<Renderer>();
        r.material = new Material(Shader.Find("Diffuse"));
    }
}
