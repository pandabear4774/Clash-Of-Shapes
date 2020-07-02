using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTower : MonoBehaviour
{
    private bool active;
    private string enemyTag;
    public GameObject[] enemies;
    public GameObject target;
    private float closest;
    private float reloadTimer;
    public float reloadRate = 1f;
    public GameObject bulletPrefab;

    private void Start()
    {
        active = true;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }/*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SquareUp"))
        {
            Debug.Log("HIT WALL TOWER");
            active = true;
            enemyTag = "SquareDown";
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
        if (collision.gameObject.CompareTag("SquareDown"))
        {
            active = true;
            enemyTag = "SquareUp";
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
    }
    */
    public void UpdateTarget()
    {
        enemies = GameObject.FindGameObjectsWithTag("SquareUp");
        foreach (GameObject enemy in enemies)
        {
            if (target == null)
            {
                closest = -114;
            }
            if (enemy.transform.position.x > closest)
            {
                closest = enemy.transform.position.x;
                target = enemy;
            }
        }
        Debug.Log(enemies.Length);
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
