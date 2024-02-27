using UnityEngine;

public class Terrain : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Player"))
        {
            PlayerController.canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.collider.CompareTag("Player"))
        {
            PlayerController.canJump = false;
        }
    }
}