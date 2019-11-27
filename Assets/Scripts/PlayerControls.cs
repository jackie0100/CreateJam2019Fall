using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControls : Character
{
    // Movement
    public float MovementSpeed; 
    public List<Sprite> Sprites;
    private int newRotation;
    public SpriteRenderer render;
    public int layerMask;
    // Attack 
    public int AttackSpeed;
    private float attackCountDown;

    [SerializeField]
    SoundEvent _soundEffect;

    [SerializeField]
    new AudioSource _audioSource;

    // Start is called before the first frame update

    Animator anim;
    public TextMesh text; 

    void Start()
    {
        if (_audioSource == null)
            _audioSource = GetComponent<AudioSource>();

        attackCountDown = AttackSpeed;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attacking();
        text.text = Health.ToString();
    }

    void FixedUpdate () {

    }

    private void Movement () {
        float x = 0, y = 0;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            y += MovementSpeed;
            newRotation = 0;
            anim.SetInteger("Direction", 0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            y += -MovementSpeed;
            newRotation = 1;
            anim.SetInteger("Direction", 1);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            x += -MovementSpeed;           
            newRotation = 2;
            anim.SetInteger("Direction", 2);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            x += MovementSpeed;
            newRotation = 3;
            anim.SetInteger("Direction", 3);
        }
        Vector3 move = new Vector3(x,y,0).normalized;
        if (x == 0 && y == 0)
        {
            anim.SetInteger("Direction", -1);
        }
        if (!Physics2D.Raycast(transform.position,move, MovementSpeed * Time.deltaTime * 2,1 << layerMask)){
            GetComponent<Rigidbody2D>().velocity = move * MovementSpeed;

        } else {
            print("collide");
        }
        if (newRotation != currentRotation){
            render.sprite = Sprites[newRotation];
            currentRotation = newRotation;
        }
    }
    private void Attacking () {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && attackCountDown <= 0){
            attackCountDown = AttackSpeed;
            Attack();
            _audioSource.SetSoundSettingsAndPlayOneShot(_soundEffect);
        }
        if (attackCountDown > 0){
            attackCountDown -= Time.deltaTime;
        }
    }

}
