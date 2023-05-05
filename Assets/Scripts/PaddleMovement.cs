using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
   public float Speed = 4f;
   private bool running = false;
   float movVertical;
   //ai
   private Vector2 startPosition;
   private float startSpeed;
   private BallMovement ball;
   private Vector2 forwardDirection;
   //endai

   [SerializeField] private bool isPlayer1;
   [SerializeField] private bool isAI;
   // Start is called before the first frame update
   void Start()
   {
      ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallMovement>();
      startPosition = transform.position;
      startSpeed = Speed;

      //if (isAI)
      //{
      //   forwardDirection = Vector2.left;
      //}
   }

   // Update is called once per frame
   void Update()
   {
      if (running)
      {
         float scaledSpeed = Speed * Time.deltaTime;
         
         if (isPlayer1)
            movVertical = Input.GetAxis("Vertical");
         else
            movVertical = Input.GetAxis("Vertical2");

         //Clamp sirve para ponerle limites al movimiento
         transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y + movVertical * scaledSpeed, -4f, 4f),
            transform.position.z
         );

         //transform.position += movVertical * scaledSpeed * Vector3.up;

         if (isAI)
         {
            forwardDirection = Vector2.left;
            float targetYposition = GetNewYPosition();
            transform.position = new Vector3(transform.position.x, targetYposition, transform.position.z);
         }
      }

   }

   public void ResetPosition()
   {
      transform.position = startPosition;
   }

   public void Run()
   {
      running = true;
   }
   public void Stop()
   {
      running = false;
      ResetPosition();
   }

   //AI

   private float GetNewYPosition()
   {
      float result = transform.position.y;
      if (isAI)
      {
         if (BallIncoming())
            result = Mathf.MoveTowards(transform.position.y, ball.transform.position.y, Speed * Time.deltaTime);
      }
      else
      {
         result = transform.position.y + movVertical;
      }
      return result;
   }

   private bool BallIncoming()
   {
      float dotP = Vector2.Dot(ball.rb.velocity, forwardDirection);
      Debug.Log(ball.rb.velocity);
      Debug.Log(forwardDirection);
      Debug.Log(dotP);
      return dotP < 0f;
   }

   public void setAI(bool value)
   {
      if (!value)
         Speed = startSpeed;
      else
         Speed *= 0.7f;
      isAI = value;
   }

}
