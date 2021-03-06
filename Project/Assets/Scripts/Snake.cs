using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    // Vector 2 variable for movement directions
    private Vector2 _direction = Vector2.right;

    // Create and initialize (new) List of T ransforms that will hold snake segments
    private List<Transform> _segment = new List<Transform>();

    // Reference to snake segment prefab
    public Transform _segmentPrefab;

    private int initialSize = 5;

    private void Start()
    {
        ResetState();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }

        else if(Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }

        else if(Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }
    }

    
    private void FixedUpdate()  
    {
        // Loop through the segments in backwards order
        // It makes sure that each segment added is following the one in front of it
        for (int i = _segment.Count - 1; i > 0; i--)
        {
            _segment[i].position = _segment[i - 1].position;
        }

        transform.position = new Vector3(

        // Mathf.Round uses whole numbers, so it allows for grid-like movement
        Mathf.Round(transform.position.x) + _direction.x,
        Mathf.Round(transform.position.y) + _direction.y,
        0.0f
        );
    }

    private void Grow()
    {
        // Reference to new segment
        Transform segment = Instantiate(_segmentPrefab);

        // set position of segment at the end of the snake (always add to tail)
        //  _segment[_segment.Count - 1] will get the last segment prefab
        segment.position = _segment[_segment.Count - 1].position;

        _segment.Add(segment);
    }

    private void ResetState()
    {
        // Clear out list of segments

        // index 1 in int i = 1is the second segment prefab, 0 is the head
        // and is not to be destroyed! Because the head at index 0 is also
        // the asset this script is attached to!
        for (int i = 1; i < _segment.Count; i++)
        {
            Destroy(_segment[i].gameObject);
        }

        _segment.Clear();
        _segment.Add(transform);

        // Set initialize size of snake with a for loop
        for (int i = 1; i < initialSize; i++)
        {
            _segment.Add(Instantiate(_segmentPrefab));
        }

        transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Make sure "other" object colliding is Snake/Player
        if (other.tag == "Food")
        {
            Grow();
        }

        else if(other.tag == "Obstacle")
        {
            ResetState();
        }
    }
}
