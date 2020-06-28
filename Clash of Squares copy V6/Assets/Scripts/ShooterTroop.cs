using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterTroop : MonoBehaviour
{
    public static float cost = 100f;
    private Vector3 offset;
    public GameObject[] enemies;
    public GameObject target;
    private float closest;
    private float reloadTimer;
    public float reloadRate = 1f;
    public GameObject bulletPrefab;
    public float movingTimerReset;
    private float movingTimer;
    public ParticleSystem impactEffect;
    public GameObject scoreMaster;
    // Start is called before the first frame update
    void Start()
    {
        movingTimerReset = 1 / movingTimerReset;
        movingTimer = movingTimerReset;
        reloadTimer = reloadRate;
        offset = new Vector3(transform.localScale.x, 0, 0);
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        reloadTimer -= Time.deltaTime;
        movingTimer -= Time.deltaTime;
        if (target != null && reloadTimer <= 0)
        {
            Shoot();
            reloadTimer = reloadRate;
        }
        if(movingTimer <= 0)
        {
            transform.position += new Vector3(0.5f, 0, 0);
            movingTimer = movingTimerReset;
        }
    }
    public void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        BulletMovement bullet = bulletGO.GetComponent<BulletMovement>();
        if (bullet != null)
        {
            bullet.Seek(target.transform);
        }
    }
    public void UpdateTarget()
    {
        enemies = GameObject.FindGameObjectsWithTag("SquareDown");
        closest = 100f;
        foreach (GameObject enemy in enemies)
        {
            if(target == null)
            {
                closest = 100f;
            }
            var distance = Vector3.Distance(enemy.transform.position, transform.position);
            if(distance < closest)
            {
                target = enemy;
                closest = distance;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SquareUpEnd"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            impactEffect.Play();
            Destroy(gameObject);
            scoreMaster.GetComponent<Score>().IncreaseLeftScore(Mathf.Round(transform.localScale.x));
            Coins.coinAmount += Mathf.Round(transform.localScale.x);
            return;
        }
        if (collision.gameObject.CompareTag("SquareUp"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            return;
        }
        Destroy(gameObject);

    }
}
