using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Movement
    public float MovementSpeed; 
    public List<Sprite> Sprites;
    private int currentRotation;
    private int newRotation;
    public SpriteRenderer render;
    public int layerMask;
    // Attack 
    public GameObject AttackObject;
    public int Damage;
    public int AttackSpeed;
    public float AttackCountDown;
    public float AttackOffSet;
    public int Health;
    // Start is called before the first frame update
    void Start()
    {
        AttackCountDown = AttackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
    }

    void FixedUpdate () {

    }

    private void Movement () {
        float x = 0, y = 0;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            y += MovementSpeed;
            newRotation = 0;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            y += -MovementSpeed;
            newRotation = 1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            x += -MovementSpeed;           
            newRotation = 2;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            x += MovementSpeed;
            newRotation = 3;
        }
        Vector3 move = new Vector3(x,y,0);
        if (!Physics2D.Raycast(transform.position,move, MovementSpeed * Time.deltaTime * 2,1 << layerMask)){
            GetComponent<Rigidbody2D>().velocity = move.normalized * MovementSpeed;
        } else {
            print("collide");
        }
        if (newRotation != currentRotation){
            render.sprite = Sprites[newRotation];
            currentRotation = newRotation;
        }
    }
    private void Attack () {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && AttackCountDown <= 0){
            AttackCountDown = AttackSpeed;
            Instantiate(AttackObject, GetAttackPostion(), GetAttackRotation());
        }
        if (AttackCountDown > 0){
            AttackCountDown -= Time.deltaTime;
        }
    }
    private Vector3 GetAttackPostion() {
        Vector3 vector = transform.position;
        switch (currentRotation){
            case 0: {
                vector += Vector3.up * AttackOffSet;
                break;
            }
            case 1 : {                
                vector += Vector3.down * AttackOffSet;
                break;
            }
            case 2 : {                
                vector += Vector3.left * AttackOffSet;
                break;
            }
            case 3 : {
                vector += Vector3.right * AttackOffSet;
                break;
            }
            default: {
                break;
            }
        }
        return  vector;
    }
    private Quaternion GetAttackRotation() {
        Quaternion quaternion = new Quaternion();
        switch (currentRotation){
            case 0: {
                quaternion = Quaternion.Euler(0,0,0);
                break;
            }
            case 1 : {                
                quaternion = Quaternion.Euler(0,0,180);
                break;
            }
            case 2 : {                
                quaternion = Quaternion.Euler(0,0,90);
                break;
            }
            case 3 : {
                quaternion = Quaternion.Euler(0,0, 270);
                break;
            }
            default: {
                break;
            }
        }
        return  quaternion;
    }
}
