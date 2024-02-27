using UnityEngine;

public class LevelManager : MonoBehaviour {
    [SerializeField] private Transform finish;

    [Range(1, 10)]
    [SerializeField] private int level;

    public Transform Finish {get; private set;}

    public int Level {get; private set;}

    private void Awake() {
        Finish = finish;
        Level = level;
    }
}