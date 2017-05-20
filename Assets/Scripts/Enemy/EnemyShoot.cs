using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

    Transform frontPoint;
    bool facingRight;
    public GameObject bullet;

    GameObject target;
    public LayerMask whatToHit;

    float range = 50;
    float timer;
    float cooldown;

    private Enemy enemy; 

    void Start ()
    {
        cooldown = 1;
        timer = cooldown;
        enemy = GetComponentInParent<Enemy>();
        facingRight = enemy.facingRight;
        frontPoint = transform.parent.FindChild("FirePoint");
    }
	
	void Update ()
    {
        Shoot();
	}

    void Shoot()
    {
        if (target != null)
        {
            timer -= Time.deltaTime;
            RaycastHit2D hit = Physics2D.Raycast(frontPoint.position, target.transform.position - frontPoint.position, range, whatToHit);

            if (hit.transform.tag == "Player" && timer <= 0)
            {
                GameObject newBullet = Object.Instantiate(bullet, frontPoint.position, transform.rotation) as GameObject;
                Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
                Vector2 fireDirection = target.transform.position - frontPoint.position;
                fireDirection.Normalize();
                rb.velocity = fireDirection;
                timer = cooldown;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            target = GameObject.FindGameObjectWithTag("Player");
            enemy.enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            target = null;
            enemy.enabled = true;
        }
    }
}
