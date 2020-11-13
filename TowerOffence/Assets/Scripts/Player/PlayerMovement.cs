using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Player)), RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int direction = 0;
    public bool isWalking = false;

    public bool knockback = false;
    private Vector2 knockbackNewPos = Vector2.zero;
    public float knockbackDuration = 0.75f;
    public float knockbackTimer = 0.75f;
    public float knockbackLerp = 0.08f;
    public float knockbackStrength = 3.5f;

    public Player player;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        if (knockback)
        {
            knockbackTimer -= Time.deltaTime;
            if (knockbackTimer <= 0)
            {
                knockback = false;
            }
        } else
        {
            float hMovement = player.pInput.movementInput.x;
            float vMovement = player.pInput.movementInput.y;

            isWalking = (Mathf.Abs(hMovement) > 0 || Mathf.Abs(vMovement) > 0);

            if (Mathf.Abs(hMovement) > Mathf.Abs(vMovement))
            {
                direction = hMovement > 0 ? 0 : hMovement < 0 ? 2 : direction;
            } else
            {
                direction = vMovement > 0 ? 3 : vMovement < 0 ? 1 : direction;
            }
        }
    }
    void FixedUpdate()
    {
        if (knockback)
        {
            float newx = Mathf.Lerp(rb.position.x, knockbackNewPos.x, knockbackLerp);
            float newy = Mathf.Lerp(rb.position.y, knockbackNewPos.y, knockbackLerp);
            rb.MovePosition(new Vector2(newx, newy));
        }
        else
        {
            rb.MovePosition(rb.position + (player.pInput.movementInput * this.moveSpeed * Time.deltaTime));
        }
    }

    internal void Knockback(Vector2 OtherPlayerPos)
    {
        float px = transform.position.x;
        float py = transform.position.y;
        float otherPx = OtherPlayerPos.x;
        float otherPy = OtherPlayerPos.y;

        Vector2 knockbackDir = new Vector2(px - otherPx, py - otherPy);
        knockbackNewPos = rb.position + (knockbackDir * knockbackStrength);
        knockback = true;
        knockbackTimer = knockbackDuration;
    }
}
