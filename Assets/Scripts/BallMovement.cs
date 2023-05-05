using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TipoJugador
{
   PLAYER1,PLAYER2
}

class OnGoalArgs : EventArgs
{
   public TipoJugador player;
}

//OBSERVADO
public class BallMovement : MonoBehaviour
{
   public event EventHandler OnGoal;

   public Vector3 Speed = new(7f,0f);
   public Rigidbody2D rb;
   private bool running = false;

   // Start is called before the first frame update
   void Start()
   {
      rb = transform.GetComponent<Rigidbody2D>();
      //rb.velocity = new Vector2(Speed.x, Speed.y);
   }

   // Update is called once per frame
   private void Update()
   {
      //float scaledSpeed = Speed * Time.deltaTime;

      //transform.position += Vector3.right * scaledSpeed;
      if (running)
         rb.velocity = new Vector2(Speed.x, Speed.y);
      else
      {
         rb.velocity = Vector2.zero;
         transform.position = new Vector3(0f, 0f, 0f);
      }
         
      
   }

   //private void OnTriggerEnter2D(Collider2D collision)
   //{
   //   Debug.Log("Collision");
   //   Speed *= -1;
   //}

   private void OnCollisionEnter2D(Collision2D collision)
   {
      

      if(collision.collider.transform.CompareTag("Wall"))
      {
         Speed.y *= -1f;
      }
      else
      {
         Speed.y = UnityEngine.Random.Range(-5f, 5f);
         Speed.x *= -1f;
      };
   }

   private void OnTriggerEnter2D(Collider2D collider)
   {
      Debug.Log("Gol");
      OnGoalArgs args = new OnGoalArgs();
      if (rb.velocity.x < 0)
      {
         //gol jugador 2 (paddle derecha)
         args.player = TipoJugador.PLAYER2;
      }
      else
      {
         //gol jugador 1 (paddle izq)
         args.player = TipoJugador.PLAYER1;
      }
      
      OnGoal?.Invoke(this,args);

      transform.position = new Vector3(0f, 0f, 0f);
      Speed.y *= 0;
   }

   public void Run()
   {
      running = true;
   }
   public void Stop()
   {
      running = false;
   }


}
