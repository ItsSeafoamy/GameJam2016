using UnityEngine;
using System.Collections;

public class random : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string resourceName = "";
		int resource = Randmisation ();
		//print (resource);




		if (resource  == 0)
		{
			resourceName= "water";


		}



		if (resource  == 1)
		{
			resourceName= "food";
			//print (resourceName);

		}



		if (resource  == 2)
		{
			resourceName= "money";
			//print (resourceName);

		}

		if (resource  == 3)
		{
			resourceName= "wood";
			//print (resourceName);

		}

		if (resource  == 4)
		{
			resourceName= "stone";


		}



		//print (resourceName);
		int amount = Randmisation1 ();
		print (amount + " of " + resourceName ); 



	}
	
	// Update is called once per frame
	void Update () {
	
	}

	int Randmisation(){


		return Random.Range (0, 5);

	}

	int Randmisation1(){


		return Random.Range (0, 100);

	}
}
