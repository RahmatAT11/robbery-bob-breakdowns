using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnet : MonoBehaviour
{
	Rigidbody2D rb;
	GameObject player;
	Vector2 catDirection;
	float timeStamp;
	bool isMagneting;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (isMagneting)
		{
			catDirection = -(transform.position - player.transform.position).normalized;
			rb.velocity = new Vector2(catDirection.x, catDirection.y) * 10f * (Time.time / timeStamp);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals("CoinMagnet"))
		{
			timeStamp = Time.time;
			player = GameObject.Find("Player");
			isMagneting = true;
		}
	}
}
