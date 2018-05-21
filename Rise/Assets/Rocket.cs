using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UserInput();
	}
   // Process the user input
   private void UserInput () {
      // Space is ship boosters
      if (Input.GetKey(KeyCode.Space)) {
         print("Boosting!");
      }
      // A is rotate left
      if (Input.GetKey(KeyCode.A)) {
         print("Rotate Left");
      }
      // D is rotate right
      else if (Input.GetKey(KeyCode.D)) {
         print("Rotate Right");
      }
   }
}
