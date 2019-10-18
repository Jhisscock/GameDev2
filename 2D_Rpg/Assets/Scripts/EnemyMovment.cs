using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    public Transform player;
    private float minDist = 10f;
    private float maxDist = 5f;
    private Rigidbody2D rb;
    public LayerMask playerLayer;
    public static bool detectPlayer;
    public float collisionRadius = 0.25f;
    private Color debugCollisionColor = Color.red;
    private float timer = 0f;
    private float moveTime = 0.5f;
    private bool follow = false;

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
        if(detectPlayer){
            follow = true;
        }
        if(follow){
            if(Vector3.Distance(transform.position, player.position) <= minDist && timer >= moveTime){
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
        Debug.Log(Collision.onGround);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere((Vector2)transform.position, collisionRadius);
    }
}
