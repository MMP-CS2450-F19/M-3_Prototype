using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeadControl : MonoBehaviour
{
    //private Rigidbody2D rb2d;

    // bool for bead position, either up or down
    public bool beadState = false;

    // float for bead movement
    public float beadMove = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        // if beadState is false, beadState becomes true, bead moves up a value
        if (!beadState)
        {
            beadState = true;

            // move the bead up 1 unit
            transform.position = new Vector3(transform.position.x, transform.position.y + beadMove, 0.0f);

        }
        else
        {
            beadState = false;

            // move the bead down 1 unit
            transform.position = new Vector3(transform.position.x, transform.position.y - beadMove, 0.0f);
        }
    }
}
