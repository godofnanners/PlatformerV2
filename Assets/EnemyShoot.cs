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
    // Use this for initialization
    void Start ()
    {
        cooldown = 1;
        timer = cooldown;
        enemy = this.GetComponent<Enemy>();
        facingRight = enemy.facingRight;
        frontPoint = transform.FindChild("FirePoint");
    }
	
	// Update is called once per frame
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
            Debug.DrawLine(transform.position, (frontPoint.transform.position - frontPoint.position) * 100, Color.yellow);
            if (hit.transform.tag == "Player" && timer <= 0)
            {
                //Debug.DrawLine(transform.position, hit.point, Color.red);
                GameObject newBullet = Object.Instantiate(bullet, frontPoint.position, transform.rotation) as GameObject;
                Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
                Vector2 fireDirection = target.transform.position - frontPoint.position;
                fireDirection.Normalize();
                rb.velocity = fireDirection;
                timer = cooldown;
            }
            else
            {
                //Debug.DrawLine(frontPoint.position, (target.transform.position - frontPoint.position), Color.yellow);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            target = GameObject.FindGameObjectWithTag("Player");
            enemy.enabled = false;
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, target.transform.position - transform.position, range, whatToHit);
            //Debug.DrawLine(transform.position, (target.transform.position - transform.position) * 100, Color.yellow);
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
