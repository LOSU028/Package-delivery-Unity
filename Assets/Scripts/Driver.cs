using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 1f;
    [SerializeField] private float moveSpeed = 0.01f; 
    [SerializeField] float slowSpeed = 20f;
    [SerializeField] float boostSpeed = 40f;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        //Queremos que el carro rote en la direccion que estemos presionando en nuestras teclas, por lo tanto podemos accedaer eje
        //horizontal para esto y multiplicar por nuestra velocidad de rotacion para rotar de manera deseada
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        //Queremos lograr el carro se mueva hacia enfrente o hacia atrás, por lo tanto accedemos a las flechas arriba y abajo y las multiplicamos por nuestro movespeed para movernos en estas direcciones al ritmo que deseemos 
        float moveDirection = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //Rotamos sobre el eje Z en este caso, los demas ejes afectan el juego de manera tridimensional 
        transform.Rotate(0,0,-steerAmount);
        // Para movernos en cualquier dirección basta con movernos en el eje Y en este caso, ya que si rotamos el eje y es realtivo a la rotación de nuestro carro, y por lo tanto podemos acceder a todas las direcciones solamente con movernos en este eje
        transform.Translate(0,moveDirection,0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        moveSpeed -= slowSpeed;
        if(moveSpeed <= 0){
            moveSpeed = 5;
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "boost"){
            moveSpeed += boostSpeed;
            //moveSpeed -= boostSpeed;
            
        }
    }
}
