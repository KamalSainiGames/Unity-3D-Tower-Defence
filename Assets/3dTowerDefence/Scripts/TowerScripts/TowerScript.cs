using UnityEngine;

public class TowerScript : MonoBehaviour
{
    private float damage = 10f;
    //private float range = 5f;
    //private float fireRate = 1f;

   
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Towers tower;
    

   // private float nextFireTime;

    private void Update()
    {

    }



    private void Shoot(EnemyScript target)
    {
        target.TakeDamage(damage);
    }
}
