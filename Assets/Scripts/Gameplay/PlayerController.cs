using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;

    public Rigidbody2D player;

    public static Transform start;
    public static Transform finish;

    public float BreakDistance;
    public float JumpForce;

    private float breakDistance;
    private Vector2 velocity;
    public static bool canJump;

    private void Start() {
        // if(start == null) return;
        transform.position = start.position;
        player.transform.parent = null;
        breakDistance = finish.localPosition.x - Mathf.Abs(BreakDistance);
    }

    private void Update() {
        // player.AddForce(new Vector2(2, 0), ForceMode2D.Force);

        if(player.transform.localPosition.x >= 0 && transform.position.x <= breakDistance)
        {
            FollowPlayer();
        }
        
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(canJump){
                gameManager.jump++;
                AddForce(JumpForce);
            }
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            AddForce(-JumpForce * 2);
        }

        if(Input.GetKeyDown(KeyCode.P) && GameManager.currentPhase != EnumManager.Phase.PAUSE)
        {
            velocity = player.velocity;
            player.velocity = Vector2.zero;
            GameManager.currentPhase = EnumManager.Phase.PAUSE;
        }
        else if(Input.GetKeyDown(KeyCode.P) && GameManager.currentPhase == EnumManager.Phase.PAUSE)
        {
            GameManager.currentPhase = EnumManager.Phase.START;
            player.velocity = velocity;
        }
    }

    void FollowPlayer()
    {
        transform.position = new Vector2(player.transform.localPosition.x, transform.position.y);
    }

    void AddForce(float force)
    {
        player.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
    }
}