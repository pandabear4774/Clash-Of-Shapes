using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTower : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject target;
    private float closest;
    private float reloadTimer;
    public float reloadRate = 1f;
    public GameObject bulletPrefab;

    private void Start()
    {
        closest = 114;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    public void UpdateTarget()
    {
        enemies = GameObject.FindGameObjectsWithTag("SquareDown");
        foreach (GameObject enemy in enemies)
        {
            if (target == null)
            {
                closest = 114;
            }
            if (enemy.transform.position.x < closest)
            {
                closest = enemy.transform.position.x;
                target = enemy;
            }
        }
    }
    private void Update()
    {
        reloadTimer -= Time.deltaTime;
        if (target != null && reloadTimer <= 0)
        {
            Shoot();
            reloadTimer = reloadRate;
        }
    }
    public void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
        BulletMovement bullet = bulletGO.GetComponent<BulletMovement>();
        if (bullet != null)
        {
            bullet.Seek(target.transform);
        }
    }
}
