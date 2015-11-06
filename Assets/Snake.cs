using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {
	private Vector2 vector;
	public GameObject tailPreb;
 	private List<Transform> tail = new List<Transform>();
	public GameObject youlose;
	private bool eat;

	void Start () {

	}


	void Update () {
		bool right = Input.GetKey (KeyCode.RightArrow);
		bool left = Input.GetKey (KeyCode.LeftArrow);
		bool up = Input.GetKey (KeyCode.UpArrow);
		bool down = Input.GetKey (KeyCode.DownArrow);

		if (right == true) {
			vector = Vector2.right;

		} 
		else if (left == true) {
			vector = Vector2.left;

		} 
		else if (up == true) {
			vector = Vector2.up;

		}
		else if (down == true) {
			vector = Vector2.down;

		}
		if (vector.x != 0 || vector.y != 0) {
			Invoke ("MoveMove", 1);

		}

	}

	void MoveMove(){
		GameObject clone = (GameObject)Instantiate (tailPreb, transform.position, Quaternion.identity); 
		tail.Insert(0, clone.transform);
		if(tail.Count >0){
			tail.Last ().position = transform.position;
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1);
		}
		transform.Translate (vector);
		CancelInvoke ("MoveMove");
	}


	void OnTriggerEnter2D(Collider2D other){
		youlose.SetActive (true);
		Invoke ("ReLoad", 2);
	}
	
	void ReLoad(){
		Application.LoadLevel (0);
	}
	

}
