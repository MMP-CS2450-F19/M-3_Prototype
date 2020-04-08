using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeadControl : MonoBehaviour
{
    public Controller controller;

    // bead value
    public int beadVal = 1;

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

    public void Move()
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

    void OnMouseDown()
    {
        // make a new list to store beads to move
        List<GameObject> tempList = new List<GameObject>();

        // check to see if the button is up
        if (!beadState)
        {
            // if down - iterate through the list and find the beads that are above the current bead that are also in the down position
            if(beadVal == 1)
            {
                // iterate through the list for value 1 beads
                int i = 0;

                while(i < 5)
                {
                    if (controller.onePlaceList[i].name != this.name && controller.onePlaceList[i].GetComponent<BeadControl>().beadState == false)
                    {
                        tempList.Add(controller.onePlaceList[i]);
                        i++;
                    }
                    else
                    {
                        // add the bead clicked on, then break
                        tempList.Add(controller.onePlaceList[i]);
                        break;
                    }
                }
            }
            else if (beadVal == 10)
            {
                // iterate through the list for value 10 beads
            }
            else
            {
                //do nothing, more bead rows go here later
            }

            // move all of those beads up
            for (int i = 0; i < tempList.Count; i++)
            {
                // move the bead
                tempList[i].transform.position = new Vector3(tempList[i].transform.position.x, tempList[i].transform.position.y + beadMove, 0.0f);

                // set the state of the bead to true
                tempList[i].GetComponent<BeadControl>().beadState = true;
            }
        }
        // beads are in the up position
        else
        {
            // iterate through all the beads and find the beads that are below the current bead and in the up position
            if (beadVal == 1)
            {
                int beadPosition = 0;
                // find the position of the clicked bead
                for (int i  = 0; i < controller.onePlaceList.Count; i++)
                {
                    if (controller.onePlaceList[i].name == this.name)
                    {
                        // add the clicked bead to the tempList
                        tempList.Add(controller.onePlaceList[i]);
                        beadPosition = i;
                    }
                }
                // loop through the remaining beads and check their state
                for (int j = beadPosition + 1; j < controller.onePlaceList.Count; j++ )
                {
                    if(controller.onePlaceList[j].GetComponent<BeadControl>().beadState == true)
                    {
                        // add the bead if they are in the up state
                        tempList.Add(controller.onePlaceList[j]);
                    }
                }
            }
            else if (beadVal == 10)
            {
                // iterate through the list for value 10 beads
            }
            else
            {
                //do nothing, more bead rows go here later
            }
            // move all of those beads down
            for (int i = 0; i < tempList.Count; i++)
            {
                // move the bead down
                tempList[i].transform.position = new Vector3(tempList[i].transform.position.x, tempList[i].transform.position.y - beadMove, 0.0f);

                // set the state of the bead to false
                tempList[i].GetComponent<BeadControl>().beadState = false;
            }
        }

        // delete the list for garbage collection
        tempList.Clear();

        // run the function to update the GUI sum
    }
}
