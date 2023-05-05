using System;
using TMPro;
using UnityEngine;

//OBSERVADOR -> BallMovement.cs
public class GameManager : MonoBehaviour
{
   public TextMeshProUGUI TextScore1;
   public TextMeshProUGUI TextScore2;
   public TextMeshProUGUI TextPlayer1;
   public TextMeshProUGUI TextPlayer2;

   public BallMovement ball;
   public PaddleMovement paddle1;
   public PaddleMovement paddle2;
   private bool AI = false;

   // Start is called before the first frame update
   void Start()
   {
      ball.OnGoal += OnGoalDelegate;
      StartGame();
   }

   private void OnGoalDelegate(object sender, EventArgs e)
   {
      Debug.Log("Game Manager GOOOOL");
      OnGoalArgs args = e as OnGoalArgs;
      if(args.player == TipoJugador.PLAYER1)
      {
         int puntaje = int.Parse(TextScore1.text);
         TextScore1.text = (puntaje + 1).ToString();
      }
      else
      {
         int puntaje = int.Parse(TextScore2.text);
         TextScore2.text = (puntaje + 1).ToString();
      }
      StopGame();
   }

   // Update is called once per frame
   void Update()
   {
      if(Input.GetKeyDown(KeyCode.Space)){
         StartGame();
      }

      if (Input.GetKeyDown(KeyCode.LeftControl))
      {
         StopGame();
         if (!AI)
         {
            AI = true;
            paddle2.setAI(true);
         }
         else
         {
            AI = false;
            paddle2.setAI(false);
         }
         ResetScore();
      }

      TextPlayer2.text = AI ? "AI" : "Player 2";
   }

   private void StartGame()
   {
      ball.Run();
      paddle1.Run();
      paddle2.Run();
   }

   private void StopGame()
   {
      ball.Stop();
      paddle1.Stop();
      paddle2.Stop();
   }

   private void ResetScore()
   {
      TextScore1.text = "0";
      TextScore2.text = "0";
   }
}
