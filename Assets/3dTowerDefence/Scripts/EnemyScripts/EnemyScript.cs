using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private EnemyType enemieType;

    [SerializeField] private Image healthBarImg;
   

    public float moveSpeed, health, damage;
    private float maxHealth = 50;
    private int currentWaypointIndex;



    private void Start()
    {
        Health = maxHealth;
    }

    private float Health
    {
        get { return health; }
        set
        {
            health = value;
            healthBarImg.fillAmount = health / maxHealth;
            if (health <= 0)
            {
                StartCoroutine(Die());
            }
        }
    }

    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(0.5f);
        //play Death animation
        this.gameObject.SetActive(false);
        WaveSystemScript.EnemySpawnedList.Remove(this);
    }


    private void Update()
    {
        if (!IsEnemyReached && !GameManager.IsEnemyReached)
        {
            MoveAlongPath();
        }
        else
        {
            EnemyVictoryAnimation();
            Debug.Log("Enemy is Stopped!");
        }

    }

    bool IsEnemyReached = false;
    private void MoveAlongPath()
    {
        if (currentWaypointIndex >= Waypoints.points.Length)
        {
            ReachATBase();
            return;
        }

        Transform targetWaypoint = Waypoints.points[currentWaypointIndex];

        transform.position = Vector3.MoveTowards(transform.position,targetWaypoint.position,moveSpeed * Time.deltaTime);

        transform.LookAt(targetWaypoint);


        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;
        }
    }

    private void ReachATBase()
    {
        IsEnemyReached = true;
        GameManager.TowersDefeted();

        Debug.Log("Enemy is reached to base");
        
        //play Base Destroy Animation
        //Disable tower
    }

    private void EnemyVictoryAnimation()
    {
       //Adding Enemy win animation;
    }
}
