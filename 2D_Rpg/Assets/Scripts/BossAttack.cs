using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    private float minDist = 10f;
    private float maxDist = 3f;
    private Rigidbody2D rb;
    public LayerMask playerLayer;
    public static bool detectPlayer;
    public float collisionRadius = 0.25f;
    private Color debugCollisionColor = Color.red;
    private float timer = 0f;
    private float moveTime = 0.5f;
    private bool follow = false;
    private int health = 5;
    public GameObject attack;
    private float attackSpeed = 5.5f;
    private float attackTimer = 3f;
    private float fireTime  = 1.5f;
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        detectPlayer = Physics2D.OverlapCircle((Vector2)transform.position, collisionRadius, playerLayer);
        timer += Time.deltaTime;
        attackTimer += Time.deltaTime;
        if(detectPlayer){
            follow = true;
        }
        if(follow){
            if(Vector3.Distance(transform.position, player.position) >= maxDist && attackTimer >= fireTime){
                attackTimer = 0f;
                Vector2 target = player.position;
                Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
                GameObject fire = Instantiate(attack, transform.position, Quaternion.identity);
                GameObject fire1 = Instantiate(attack, transform.position, Quaternion.identity);
                GameObject fire2  = Instantiate(attack, transform.position, Quaternion.identity);
                Vector2 direction = target - playerPos;
                direction.Normalize();
                fire.GetComponent<Rigidbody2D>().velocity = direction * attackSpeed;
                fire1.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * 1.5f, direction.y) * attackSpeed;
                fire2.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x / 1.5f, direction.y) * attackSpeed;
            }
            //Vector3.Distance(transform.position, player.position) <= minDist
            if(timer >= moveTime){
                timer = 0f;
                if(player.position.x > transform.position.x && !EnemyCollision.onRightWall){
                        rb.transform.Translate(1f, 0f, 0f);
                }else if(player.position.x < transform.position.x && !EnemyCollision.onLeftWall){
                        rb.transform.Translate(-1f, 0f, 0f);
                }
                if(player.position.y > transform.position.y && !EnemyCollision.onTop){
                        rb.transform.Translate(0f, 1f, 0f);
                }else if(player.position.y < transform.position.y && !EnemyCollision.onGround){
                        rb.transform.Translate(0f, -1f, 0f);
                }
            }
        }
        if(health <= 0){
            Instantiate(key, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere((Vector2)transform.position, collisionRadius);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "PlayerAttack"){
            Destroy(other.gameObject);
            health -= 1;
        }
    }
}
