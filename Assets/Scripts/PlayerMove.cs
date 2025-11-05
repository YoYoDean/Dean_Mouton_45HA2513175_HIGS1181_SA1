using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    
   public void MovePlayer()
    {
        
            if (Keyboard.current.dKey.wasPressedThisFrame)
            {
                rb.MovePosition(rb.transform.position + Vector3.right);
                
            }
            else if (Keyboard.current.aKey.wasPressedThisFrame)
            {
                rb.MovePosition(rb.transform.position + Vector3.left);
              
            }
            else if (Keyboard.current.wKey.wasPressedThisFrame)
            {
                rb.MovePosition(rb.transform.position + Vector3.up);
               
            }
            else if (Keyboard.current.sKey.wasPressedThisFrame)
            {
                rb.MovePosition(rb.transform.position + Vector3.down);
               
            }
        }
    
}
