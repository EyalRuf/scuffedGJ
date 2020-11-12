using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player)), RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int direction = 0;

    public Player player;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        float hMovement = player.pInput.movementInput.x;
        float vMovement = player.pInput.movementInput.y;

        if (Mathf.Abs(hMovement) > Mathf.Abs(vMovement))
        {
            direction = hMovement > 0 ? 0 : hMovement < 0 ? 2 : direction;
        } else
        {
            direction = vMovement > 0 ? 3 : vMovement < 0 ? 1 : direction;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (player.pInput.movementInput * this.moveSpeed * Time.deltaTime));
    }
}
