using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Enemies enemiesType;

    [SerializeField] private Image healthBarImg;
    [SerializeField] private GameObject healthBarObj;

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
                Die();
            }
        }
    }

    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;
    }

    private void Die()
    {
        //play Death animation
        this.gameObject.SetActive(false);
    }


    private void Update()
    {
        if (!IsEnemyReached && !GameManager.IsEnemyReached)
        {
            MoveAlongPath();
        }
        else
        {
            WinningAnimation();
            Debug.Log("Enemy is Stopped!");
        }

    }

    bool IsEnemyReached = false;
    private void MoveAlongPath()
    {
        if (currentWaypointIndex >= Waypoints.points.Length)
        {
            ReachBase();
            return;
        }

        Transform targetWaypoint = Waypoints.points[currentWaypointIndex];

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetWaypoint.position,
            moveSpeed * Time.deltaTime);

        transform.LookAt(targetWaypoint);


        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;
        }
    }

    private void ReachBase()
    {
        IsEnemyReached = true;
        GameManager.IsEnemyReached = true;
        Debug.Log("Enemy is reached to base");
        // Base ko damage do
        // GameManager.Instance.TakeDamage(enemyDamage);
        //play Base Destroy Animation
        //Disable tower
    }

    private void WinningAnimation()
    {
       //Adding Enemy win animation;
    }
}
