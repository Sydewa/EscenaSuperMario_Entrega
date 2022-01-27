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

    Rigidbody2D _rBody;


    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rBody = GetComponent<Rigidbody2D>();

    }


    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        Debug.Log(dirX);
        
        transform.position += new Vector3(dirX, 0, 0) * speed * Time.deltaTime;
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
}
