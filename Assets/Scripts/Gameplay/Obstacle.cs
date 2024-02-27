using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Player"))
        {
            GameManager.currentPhase = EnumManager.Phase.GAMEOVER;
        }
    }
}