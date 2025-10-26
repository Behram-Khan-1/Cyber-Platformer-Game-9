using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints; //Transform waypoints
    [SerializeField] private float speed = 3f; //Transform waypoints

    public void EnterPipe(CharacterMovement player)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(MoveThroughPipe(player));
    }

    private IEnumerator MoveThroughPipe(CharacterMovement player)
    {
        PauseManager.instance.TogglePause(true);

        int currentWaypointIndex = 0;
        player.transform.position = waypoints[currentWaypointIndex].position;
        while (currentWaypointIndex < waypoints.Count - 1)
        {
            currentWaypointIndex++;
            while (Vector3.Distance(player.transform.position, waypoints[currentWaypointIndex].position) > 0.05f)
            {
                player.transform.position = Vector2.MoveTowards(player.transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);
                yield return null;
            }
        }

        player.transform.position = waypoints[currentWaypointIndex].position;
        yield return new WaitForSeconds(0.2f);
        player.ResetAfterPipeExit();
        PauseManager.instance.TogglePause(false);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
