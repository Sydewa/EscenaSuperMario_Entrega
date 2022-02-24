using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    float dirX;
    public SpriteRenderer dirMirada;
    public Animator _animator;
    public bool isGrounded = false;
    private GameManager gameManager;

    Rigidbody2D _rBody;


    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }


    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        Debug.Log(dirX);
        
        //transform.position += new Vector3(dirX, 0, 0) * speed * Time.deltaTime;


        if(dirX == -1)
        {
            dirMirada.flipX = true;
            _animator.SetBool("Run_transition", true);
        }
        else if(dirX == 1)
        {
            dirMirada.flipX = false;
            _animator.SetBool("Run_transition", true);
        }
        else
        {
            _animator.SetBool("Run_transition", false);
        }
    
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            _rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _animator.SetBool("Jump_transition", true);
        
        }
       

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        /*if(collider.gameObject.CompareTag("Goombas"))
        {
            Debug.Log("Goomba muerto");
        }*/

        if(collider.gameObject.layer == 6)
        {
            Debug.Log("Goomba muerto");
            gameManager.DeathGoomba(collider.gameObject);
        }

        if(collider.gameObject.CompareTag("DeadZone"))
        {
            Debug.Log("Morido");
            gameManager.DeathMario();
            
        }
        if(collider.gameObject.CompareTag("Moneda"))
        {
            Destroy(collider.gameObject);
            gameManager.MonedaSound();
        }
        if (collider.gameObject.CompareTag("Bandera"))
        {
            
            gameManager.BanderaSound();
        }

    }
    //movimiento player
    void FixedUpdate()
    {
        _rBody.velocity = new Vector2(dirX * speed, _rBody.velocity.y);

    }
    


}
