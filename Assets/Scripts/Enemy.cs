using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{  
    //Variable para controlar la velocidad
    public float movementSpeed = 4.5f;
    //Variable para saber en que direccion se mueve en el eje x
    private int directionX = 1;
    //variable para almacenar el rigidbody del enemigo
    private Rigidbody2D rigidBody; 
    public bool isAlive = true;
    private GameManager gameManager;

    
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
      if (isAlive)
      {
        rigidBody.velocity = new Vector2(directionX * movementSpeed, rigidBody.velocity.y);
      }
      else 
      {
        rigidBody.velocity = Vector2.zero;
      }
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
      //si detecta collision con un objeto con tag Tuberia
      if(hit.gameObject.tag == "Tuberia")
      {
        Debug.Log ("me he chocado");
        //si nos vomeos a la derecha cambiara la direccion de movimiento a la izquierda
        if(directionX == 1)
        {
           directionX = -1;
        }  
        //si nos movemos a la izquierda la cambia a la derecha
        else
        {
          directionX = 1;
        } 
      }
      if(hit.gameObject.tag == "Goombas")
      {
        Debug.Log ("me he chocado");
        //si nos vomeos a la derecha cambiara la direccion de movimiento a la izquierda
        if(directionX == 1)
        {
           directionX = -1;
        }  
        //si nos movemos a la izquierda la cambia a la derecha
        else
        {
          directionX = 1;
        } 
      }
      else if(hit.gameObject.tag == "MuereMario")
      {
        Destroy(hit.gameObject);
        gameManager.DeathMario();
      }
    } 
}
