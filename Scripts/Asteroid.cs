using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Player player;
    public int damageValue;

	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<Player>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Debug.Log("YEEEEEEEEEEEEEEEEEEEE");
            player.health -= damageValue;
            Destroy(gameObject);
        }
    }
}
