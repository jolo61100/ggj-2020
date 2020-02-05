using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
  public float speed = 5.0f;
  private Rigidbody2D _rigidbody2D;
  private SpriteRenderer _spriterenderer;
  private float horizontalMovement;
  private static player Instance;



  public Animator animator;

  void Awake()
  {

    DontDestroyOnLoad(this.gameObject);
    if (Instance == null)
    {
      Instance = this;
    }
    else
    {
      Destroy(gameObject);
    }



    _rigidbody2D = GetComponent<Rigidbody2D>();
    _spriterenderer = GetComponent<SpriteRenderer>();
  }



  void Update()
  {
    horizontalMovement = Input.GetAxis("Horizontal") * speed;
    animator.SetFloat("speed", Mathf.Abs(horizontalMovement));


    _rigidbody2D.velocity = new Vector2(horizontalMovement, _rigidbody2D.velocity.y);

    if (Input.GetKeyDown(KeyCode.A))
    {
      _spriterenderer.flipX = true;
    }
    if (Input.GetKeyDown(KeyCode.D))
    {
      _spriterenderer.flipX = false;
    }
    RestrictMovement();
  }

  void RestrictMovement()
  {
    Vector3 upperRightCorner = Camera.main.ViewportToWorldPoint(new
        Vector3(1, 1, 0));
    Vector3 lowerLeftCorner = Camera.main.ViewportToWorldPoint(new
      Vector3(0, 0, 0));

    float restrictedX = Mathf.Clamp(transform.position.x, lowerLeftCorner.x, upperRightCorner.x);
    float restrictedY = Mathf.Clamp(transform.position.y, lowerLeftCorner.y, upperRightCorner.y);

    transform.position = new Vector3(restrictedX, restrictedY, 0);

  }


}