using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercotroller_move : MonoBehaviour
{

    public float dashDistance;
    public float dashDuration;
    public KeyCode dashKey = KeyCode.Space;
    public float dashCooldown;
    private float lastDashTime = -Mathf.Infinity;

    private bool isDashing = false;
    private float dashTimer;
    private Vector2 dashDirection;
    private Vector2 lastInputDirection;
    void Start()
    {
        dashDistance = 1.5f;
        dashDuration = 0.1f;
    }

    // Start is called before the first frame update
    [SerializeField] private float Speed;
    // Update is called once per frame
    void Update()
    {
        if (!isDashing)
        {
            float X = Input.GetAxisRaw("Horizontal");
            float Y = Input.GetAxisRaw("Vertical");
            Vector2 inputDirection = new Vector2(X, Y);
            if (inputDirection != Vector2.zero)
            {
                lastInputDirection = inputDirection.normalized;
            }
            transform.Translate(new Vector2(X, Y) * Time.deltaTime * Speed);
        }
        // 대쉬 입력 처리
        if (!isDashing && Input.GetKeyDown(dashKey) && Time.time > lastDashTime + dashCooldown)
        {
            isDashing = true;
            dashDirection = lastInputDirection;
            dashTimer = 0f;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (isDashing)
        {
            dashTimer += Time.deltaTime;
            if (dashTimer < dashDuration)
            {
                GetComponent<Rigidbody2D>().velocity = dashDirection.normalized * ((dashDistance) / dashDuration);
            }
            else
            {
                isDashing = false;
                lastDashTime = Time.time;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }

}
