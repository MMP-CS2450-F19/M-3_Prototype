using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CapsuleCollider2D))]
public class BeadControl : MonoBehaviour
{
	//Bead index in the group
	public int index;
	//Active or not
	public bool truthiness;
	//How much the bead will move on the rail
	public float moveAmount;
	//How quickly the animation from LeanTween will be run.
	public float moveSpeed;
	//Group of beads. Grouped by value
	public BeadControl[] beadsGroup;
	//Beads original position so it can return to its starting position
	private float homePosition;

	private void Start()
	{
		//Caches the Beads positions so it knows where it "lives" and can return easily
		homePosition = transform.localPosition.y;
		//Bead indexes its own position in the grouping so that it can move everyone above or below them if needed.
		for (int i = 0; i < beadsGroup.Length; i++)
		{
			if (beadsGroup[i].gameObject == this.gameObject)
			{
				index = i;
			}
		}
	}
	//Mouse must be clicked up and down. 
	private void OnMouseUpAsButton()
	{
		ToggleValue();
		//This will update the count displayed on the screen.
		FindObjectOfType<Controller>().UpdateCount();
	}

	public void ToggleValue()
	{
		//if true or false
		if (truthiness)
		{
			//DEACTIVATION - DOWN: this loops through the group of beads on the rail and moves them depending on which bead was clicked.
			for (int i = 0; i < beadsGroup.Length; i++)
			{
				if (i >= index)
				{
					beadsGroup[i].Activate(false);
				}
			}
		}
		else
		{
			//ACTIVATION - UP: this loops through the group of beads on the rail and moves them depending on which bead was clicked.
			for (int i = 0; i < beadsGroup.Length; i++)
			{
				if (i <= index)
				{
					beadsGroup[i].Activate(true);
				}
			}
		}
	}

	public void Activate(bool activation)
	{
		//will set the bool to true or false depending on whether it was true or false before.
		truthiness = activation;
		if (activation)
		{
			//This will mark the bead as Active (up position for lower beads, down position for upper beads) and WILL be counted.
			transform.LeanMoveLocalY(homePosition + moveAmount, moveSpeed).setEaseOutElastic();
		}
		else
		{
			//This will mark the bead as Unactive (down position for the lower beads, up position for higher beads) and wil NOT be counted.
			transform.LeanMoveLocalY(homePosition, moveSpeed).setEaseOutElastic();
		}
	}
}