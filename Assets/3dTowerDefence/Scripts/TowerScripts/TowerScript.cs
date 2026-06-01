using UnityEngine;
using DG.Tweening;

public class TowerScript : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform weaponTransform;

    [SerializeField] private TowerType tower;

    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 5f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private Color towerrangeColor;

    private float nextFireTime;

    private EnemyScript currentTarget;
    private void OnDrawGizmos()
    {
        Gizmos.color = towerrangeColor;
        Gizmos.DrawWireSphere(transform.position, range);

        if (currentTarget != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, currentTarget.transform.position);
        }
    }

    private void Update()
    {
        FindTarget();

        if (currentTarget == null)
            return;

        float distance = Vector3.Distance(transform.position, currentTarget.transform.position);

        if (distance > range)
        {
            currentTarget = null;
            return;
        }

        RotateWeapon();

        if (Time.time >= nextFireTime)
        {
            Shoot(currentTarget);
            nextFireTime = Time.time + (1f / fireRate);
        }


    }


    private void FindTarget()
    {
        currentTarget = null;

        float shortestDistance = range;

        foreach (EnemyScript enemy in WaveSystemScript.EnemySpawnedList)
        {
            if (enemy == null)
                continue;

            float distance = Vector3.Distance(transform.position,enemy.transform.position);

            if (distance <= range && distance < shortestDistance)
            {
                shortestDistance = distance;
                currentTarget = enemy;
            }
           
        }
    }

    private void RotateWeapon()
    {
        Vector3 direction = currentTarget.transform.position - weaponTransform.position;

        direction.y = 0f;

        Quaternion lookRotation = Quaternion.LookRotation(direction);

        weaponTransform.rotation = Quaternion.Slerp(weaponTransform.rotation, lookRotation, 10f * Time.deltaTime);
    }

    private void Shoot(EnemyScript target)
    {
        GameObject projectile = Instantiate(projectilePrefab, projectilePrefab.transform.position, weaponTransform.rotation);
        projectile.transform.DOMove(target.transform.position, 0.3f);
        projectile.SetActive(true);
        Destroy(projectile, 0.5f);
        target.TakeDamage(damage);
        
    }
}
