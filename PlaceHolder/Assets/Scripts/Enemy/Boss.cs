using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private float hp = 100f;
    private List<Transform> waypoints;
    private GameObject player;
    private int currentWaypointIndex;
    private float speed;
    private bool isWaiting = false;
    private float waitTime = 1f;

    public GameObject projectilePrefab;
    public float minLaunchInterval = 2f;
    public float maxLaunchInterval = 5f;

    void Start()
    {
        hp = 100f;
        speed = 5f;

        waypoints = new List<Transform>();
        foreach (Transform child in transform)
        {
            waypoints.Add(child);
        }

        foreach (Transform waypoint in waypoints)
        {
            waypoint.parent = null;
        }

        if (waypoints.Count > 0)
        {
            currentWaypointIndex = 0;
            StartCoroutine(MoveToNextWaypoint());
        }

        StartCoroutine(LaunchProjectiles());
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();

        transform.rotation = Quaternion.LookRotation(direction);
    }

    private IEnumerator MoveToNextWaypoint()
    {
        while (true)
        {
            if (waypoints.Count == 0)
                yield break;

            if (!isWaiting)
            {
                Transform target = waypoints[currentWaypointIndex];
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    target.position,
                    speed * Time.deltaTime
                );

                if (Vector3.Distance(transform.position, target.position) < 0.1f)
                {
                    isWaiting = true;
                    yield return new WaitForSeconds(waitTime);

                    isWaiting = false;
                    int nextWaypointIndex;
                    do
                    {
                        nextWaypointIndex = Random.Range(0, waypoints.Count);
                    } while (nextWaypointIndex == currentWaypointIndex);

                    currentWaypointIndex = nextWaypointIndex;
                }
            }
            yield return null;
        }
    }

    private IEnumerator LaunchProjectiles()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minLaunchInterval, maxLaunchInterval));
            LaunchProjectileAtPlayer();
        }
    }

    private void LaunchProjectileAtPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();

            transform.rotation = Quaternion.LookRotation(direction);

            GameObject projectile = Instantiate(
                projectilePrefab,
                transform.position + direction,
                Quaternion.identity
            );
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * speed;
            }
            Destroy(projectile, 3f);
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
            Debug.Log("ПОБЕДА");
        }
    }
}
