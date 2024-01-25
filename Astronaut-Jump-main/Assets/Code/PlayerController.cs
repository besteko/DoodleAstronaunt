using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private Rigidbody2D myRigidbody;
	[SerializeField] private SpriteRenderer renderer;
	[SerializeField] private float speed;
	[SerializeField] private float limit;

	private bool IsJumping => myRigidbody.velocity.y > 0.01f;

	private float input;


	public void Jump(float force)
	{
		if (IsJumping) return;

		var velocity = myRigidbody.velocity;
		velocity.y = force;
		myRigidbody.velocity = velocity;
	}

	private void Update()
	{
		input = Input.GetAxis("Horizontal");
		if (input != 0)
			renderer.flipX = input < 0;

		GameManager.Instance.Score = (int)transform.position.y;
		 if (!IsGrounded())
    { 
        // Eğer zeminde değilse, rotasyonu sıfırla
        transform.rotation = Quaternion.identity;
    }
		 
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		var position = transform.position;
		position.x += input * speed * Time.deltaTime;
		position.x = Mathf.Clamp(position.x, -limit, limit);
		transform.position = position;
	  // transform.rotation = Quaternion.identity;
	}

	private bool IsGrounded()
{
    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
    
    // Eğer altında bir collider varsa, zeminde olduğunu kabul et
    foreach (Collider2D collider in colliders)
    {
        if (collider.gameObject != gameObject && collider.isTrigger == false)
        {
            return true;
        }
    }

    // Eğer altında collider yoksa, zeminde değil kabul et
    return false;
}

	 

}