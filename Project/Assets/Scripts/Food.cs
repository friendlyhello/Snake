using UnityEngine;

public class Food : MonoBehaviour
{
    // Create a reference to the BoxCollider2D in the Editor
    public BoxCollider2D gridArea;

    private void Start()
    {
        RandomizePosition();
    }

    // Function that randomizes position of the food
    private void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;

        // Member variables for x and y
        float x = Random.Range(bounds.min.x, bounds.max.y);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector3(
            Mathf.Round(x),
            Mathf.Round(y),
            0.0f
            );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Make sure "other" object colliding is Snake/Player
        if(other.tag == "Player")
        {
            RandomizePosition();
        }
    }
}
