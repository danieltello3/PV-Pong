using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
   //public float Speed = 1f;
   public Vector3 Speed = new(1f,0f);
   private Rigidbody2D rb;

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
      rb.velocity = new Vector2(Speed.x, Speed.y);
      
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
         Speed.y = Random.Range(-5f, 5f);
         Speed.x *= -1f;
      };
   }

   private void OnTriggerEnter2D(Collider2D collider)
   {
      Debug.Log("Gol");
   }


}
