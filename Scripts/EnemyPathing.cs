using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
     WaveConfig waveConfig;
     List<Transform> waypoints;

    int waypoinIndex = 0;

	// Use this for initialization
	void Start () {
        
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypoinIndex].transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (waypoinIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypoinIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypoinIndex++;
            }
        }
        else
        {
            
            Destroy(gameObject);
        }

    }
}
