using UnityEngine;

public class Finish : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            GameManager.currentPhase = EnumManager.Phase.FINISH;
        }
    }
}