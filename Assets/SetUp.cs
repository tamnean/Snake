using UnityEngine;
using System.Collections.Generic;



public class SetUp : MonoBehaviour {
	public int row;
	public int collumn;
	public GameObject sprite;
	public GameObject snake;
	
	private List<Vector2> grid = new List<Vector2>();

	void Awake () {
		//snake = GetComponent<Transform>();
		for (int x = 1; x<= collumn ; x++) {
			for (int y = 1; y <= row; y++) {
				grid.Add(new Vector2(x,y));
				Instantiate(sprite,new Vector2(x,y),Quaternion.identity);
			}
		}
	}

	void FixedUpdate () {
		Vector2 x = new Vector2 (1,0);
		Vector2 y = new Vector2 (0, 1);
		float snakePositionX = snake.transform.position.x;
		float snakePositionY = snake.transform.position.y;
		if (snakePositionX > collumn)
			snake.transform.Translate (- collumn*x);
		if (snakePositionX < 1)
			snake.transform.Translate ( collumn*x);
		if (snakePositionY > row)
			snake.transform.Translate (- row*y);
		if (snakePositionY < 1)
			snake.transform.Translate ( row*y);
	}
	
}
