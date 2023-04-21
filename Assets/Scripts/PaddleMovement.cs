using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
   public float Speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      float scaledSpeed = Speed * Time.deltaTime;
      float movVertical = Input.GetAxis("Vertical");

      //Clamp sirve para ponerle limites al movimiento
      transform.position = new Vector3(
         transform.position.x,
         Mathf.Clamp(transform.position.y + movVertical * scaledSpeed,-4f,4f),
         transform.position.z
      );

      //transform.position += movVertical * scaledSpeed * Vector3.up;
   }
}
