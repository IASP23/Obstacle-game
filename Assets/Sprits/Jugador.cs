/* Librerias */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Clase Jugador --> REY */
public class Jugador : MonoBehaviour
{
    /* Variables a utilizar */
    public float fuerzaSalto;
    public GameManager gameManager;
    private Animator animator;
    private Rigidbody2D newrigidbody2D;
    private bool salto = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        newrigidbody2D = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        {
            /* Si la tecla presionada es Espacio, nuestro animator  */
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("estaSaltando", true); // El rey pasa a saltar
                if (salto == true) // si salto es verdadero
                {
                    newrigidbody2D.AddForce(new Vector2(0, fuerzaSalto)); // Crea un movimiento en el eje Y, que muestra la 
                    // accion de saltar 
                    salto = false; // Se cambia el valor de salto a Falso, para controlar que solo se pueda saltar una voz 
                    // mientras realiza la accion de desplazamiento en el eje y 
                }

            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo") // Verifica si el objeto que ha colisionado tiene la etiqueta Suelo 
        {
            animator.SetBool("estaSaltando", false); // dentro de animator cambiamos a falso 
            salto = true; // El jugador puede volver a saltar 
        }
        if (collision.gameObject.tag == "Obstaculo")
        {
            gameManager.gameOver = true;
        }
    }

}
