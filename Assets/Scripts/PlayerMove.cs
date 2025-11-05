using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Tilemap Settings")]
    public Tilemap waterTilemap; 

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MovePlayer()
    {
        Vector3 direction = Vector3.zero;

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            direction = Vector3.right;
        }
        else if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            direction = Vector3.left;
        }
        else if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            direction = Vector3.up;
        }
        else if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            direction = Vector3.down;
        }

        if (direction != Vector3.zero)
        {
            Vector3 targetPos = rb.transform.position + direction;

            //Check if target tile is walkable before moving
            if (CanMoveTo(targetPos))
            {
                rb.MovePosition(targetPos);
            }
            else
            {
                rb.MovePosition(rb.transform.position + -direction);
                Debug.Log("Blocked! Can't move to " + targetPos);
            }
        }
    }

    private bool CanMoveTo(Vector3 targetWorldPos)
    {
        if (waterTilemap == null) return true;

        Vector3Int cellPos = waterTilemap.WorldToCell(targetWorldPos);
        TileBase tile = waterTilemap.GetTile(cellPos);

        
        return tile == null;
    
    }
}
