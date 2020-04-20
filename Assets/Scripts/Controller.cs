using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
	//This helps the controller to count by groups
	public CountGroups[] groups;
	//This is the UI using TextMeshPro plugin.
	private TMP_Text text;
	//The start will be 0. Can be changed for lessons.
	private int count = 0;

	private void Start()
	{
		//Will set the UI to read 0 until a bead is clicked.
		text = GetComponent<TMP_Text>();
		text.text = count.ToString();
	}

	public void UpdateCount()
	{
		count = 0;
		//Checks all groups
		for (int i = 0; i < groups.Length; i++)
		{
			//For all beads in the group
			for (int j = 0; j < groups[i].beads.Length; j++)
			{
				//If beads are active or not
				if (groups[i].beads[j].truthiness)
				{
					//If beads are active add their value to the count
					count += groups[i].value;
				}
			}
		}
		//Update the count to be displayed to the UI
		text.text = count.ToString();
	}
}

[System.Serializable]
public class CountGroups
{
	//This class will allow for all of the beads to be counted
	//Name is the name of the group
	public string name;
	//Value of the group. EG group will have 1, 5, 10 value to be added to counter.
	public int value;
	//Array of beads in a specific grouping.
	public BeadControl[] beads;
}

