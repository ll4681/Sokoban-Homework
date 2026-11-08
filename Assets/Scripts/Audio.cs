using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GridMoveSound : MonoBehaviour
{
    [SerializeField] private AudioClip moveSound;
    [SerializeField] private float volume = 1f;

    [SerializeField] private float cellSize = 1f;

    private AudioSource audioSource;
    private Vector3 startingPosition;
    private Vector2Int previousCell;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.playOnAwake = false;

        startingPosition = transform.position;
        previousCell = Vector2Int.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement =
            transform.position - startingPosition;

        Vector2Int currentCell = new Vector2Int(
            Mathf.RoundToInt(displacement.x / cellSize),
            Mathf.RoundToInt(displacement.z / cellSize)
        );

        if (currentCell != previousCell)
        {
            if (moveSound != null)
            {
                audioSource.PlayOneShot(moveSound, volume);
            }

            previousCell = currentCell;
        }
    }
}