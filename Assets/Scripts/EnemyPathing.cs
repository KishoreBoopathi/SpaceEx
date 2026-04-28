using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;
    [SerializeField] float padding;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

	// Use this for initialization
	void Start () {
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        StartCoroutine(MoveInPath());
    }

    public void setWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private IEnumerator MoveInPath()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementPerFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementPerFrame);
            if (waveConfig.GetWaitInPath() && (waypointIndex == (waypoints.Count/2)) && transform.position == targetPosition)
            { 
                yield return new WaitForSeconds(waveConfig.GetWaitTimeInMidPath());
            }
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Vector3 GetMovementBoundaries()
    {

        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

        Vector3 targetPosition = new Vector3(Random.Range(xMin, xMax), Random.Range(yMax, yMin),0.0f);

        return targetPosition;
    }
}
