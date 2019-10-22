using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 0.175f;
    private float moveTime = 1f;
    private Rigidbody2D rb;
    private Vector3 lastPos;
    Vector2 movement;
    private float attackSpeed = 6f;
    public GameObject fireball;
    private float timer = 3f;
    private float fireTime  = 0.4f;
    private bool moved = false;
    private int health = 5;
    public GameObject flag;
    private float damageTime = 1f;
    private float damageWait = 1f;
    private int keyCount = 0;
    public GameObject door;
    public GameObject text;
    private bool paused = false;
    private AudioSource [] sounds;
    private AudioSource song;
    private AudioSource ambience;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sounds = GetComponents<AudioSource>();
        song = sounds[0];
        ambience = sounds[1];
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        moveTime += Time.deltaTime;
        damageWait += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.W) && moveTime >= moveSpeed){
            moved = true;
            if(!Collision.onTop){
                rb.transform.Translate(0f , 1f, 0f);
            }
        }else if(Input.GetKeyDown(KeyCode.S) && moveTime >= moveSpeed){
            moved = true;
            if(!Collision.onGround){
                rb.transform.Translate(0f , -1f, 0f);
            }
        }else if(Input.GetKeyDown(KeyCode.D) && moveTime >= moveSpeed){
            moved = true;
            if(!Collision.onRightWall){
                rb.transform.Translate(1f , 0f, 0f);
            }
        }else if(Input.GetKeyDown(KeyCode.A) && moveTime >= moveSpeed){
            moved = true;
            if(!Collision.onLeftWall){
                rb.transform.Translate(-1f , 0f, 0f);
            }
        }
        if(moved){
            moved = false;
            moveTime = 0;
        }
        if(Input.GetMouseButton(0) && timer >= fireTime){
            timer = 0;
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = target - playerPos;
            direction.Normalize();
            GameObject fire = Instantiate(fireball, playerPos, Quaternion.identity);
            double rotation = Math.Atan(direction.y/direction.x) * 180f /  Math.PI;
            if(direction.x < 0 && direction.y >=0){
                rotation += -180;
            }else if(direction.x < 0 && direction.y <0){
                rotation += 180;
            }
            fire.transform.localRotation = Quaternion.Euler(fire.transform.localRotation.x, fire.transform.localRotation.y, (float)rotation);
            fire.GetComponent<Rigidbody2D>().velocity = direction * attackSpeed;
        }
        if(Input.GetKeyDown(KeyCode.RightControl)){
            health = 0;
        }
        if(Input.GetKeyDown(KeyCode.RightShift)){
            keyCount = 6;
        }
        if(health <= 0){
            Instantiate(flag, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if(EnemyCollision.onPlayer && damageWait >= damageTime){
            damageWait = 0f;
            health -= 1;
        }
        if(keyCount >= 6 && Collision.onDoor){
            Destroy(door);
        }
        if(Collision.onChest && Input.GetKeyDown(KeyCode.LeftShift)){
            text.gameObject.SetActive(true);
            paused = true;
            Time.timeScale = 0;
        }   
        if(Input.GetKeyDown(KeyCode.Escape) && paused){
            Time.timeScale = 1;
            paused = false;
            text.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Skull"){
            Destroy(other.gameObject);
            health-= 1;
        }
        if(other.gameObject.tag == "Key"){
            Destroy(other.gameObject);
            keyCount++;
        }
        if(other.gameObject.tag == "Zoom"){
            Camera.main.orthographicSize = 7f;
            ambience.Pause();
            song.Play(0);
        }
    }
}
