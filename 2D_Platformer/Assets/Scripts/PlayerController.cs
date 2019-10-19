using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{
    private float jHeight = 5f;
    private float speed = 3f;

    public float dSpeed = 20f;
    private bool hasDashed = false;
    private bool walkCheck = true;
    private Rigidbody2D rb;
    public GameObject spawnPoint;
    public GameObject player;
    private int count = 1; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);

        Walk(dir);
        if(Collision.onGround){
            RechargeDash();
        }
        if(Input.GetKeyDown(KeyCode.Space) && Collision.onWall){
            rb.gravityScale = 1f;
            if(Collision.onRightWall){
                StartCoroutine(walkDisable(0.1f));
                Jump((Vector2.up + Vector2.left), true);
            }else if(Collision.onLeftWall){
                StartCoroutine(walkDisable(0.1f));
                Jump((Vector2.up + Vector2.right), true);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            if(Collision.onGround){
                Jump(Vector2.up, false);
            }
        }
        if(Input.GetKeyDown(KeyCode.Z)){
            if(xRaw != 0 || yRaw != 0){
                if(!hasDashed){
                    Dash(xRaw, yRaw);
                    GetComponent<SpriteRenderer>().color = Color.magenta;
                }
            }
        }
        if(Input.GetKey(KeyCode.LeftShift) && Collision.onWall){
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0f;
            if(Input.GetKey(KeyCode.UpArrow)){
                rb.velocity = new Vector2 (rb.velocity.x, dir.y * speed);
            }else if(Input.GetKey(KeyCode.DownArrow)){
                rb.velocity = new Vector2 (rb.velocity.x, dir.y * speed);
            }
        }
        rb.gravityScale = 1f;
    }

    void Walk(Vector2 n){
        if(walkCheck){
            rb.velocity = new Vector2(n.x * speed, rb.velocity.y);
        }
    }

    void Jump(Vector2 n, bool wall){
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += n * jHeight;
    }

    void Dash(float x, float y){
        hasDashed = true;
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(x, y);
        rb.velocity += dir * dSpeed;
        walkCheck = false;
        hasDashed = true;
        StartCoroutine(walkDisable(0.5f));
    }

    IEnumerator walkDisable(float timer){
        walkCheck = false;
        yield return new WaitForSeconds(timer);
        walkCheck = true;
    }

    void RechargeDash(){
        GetComponent<SpriteRenderer>().color = Color.blue;
        hasDashed = false;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "hazard"){
            String currSecene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currSecene);
        }
        if(other.tag == "newScene"){
            Scene scene = SceneManager.GetActiveScene();
            string name = scene.name;
            Int32.TryParse(name, out int i);
            SceneManager.LoadScene((i+1).ToString());
        }
        if(other.tag == "powerup"){
            RechargeDash();
            Destroy(other.gameObject);
        }
    }
}
