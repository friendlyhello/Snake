using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    // Vector 2 variable for movement directions
    private Vector2 _direction;

    // List of transforms that will hold snake segments
    private List<Transform> _segment;

    // Reference to snake segment prefab
    public Transform _segmentPrefab;

    private void Start()
    {
        _segment = new List<Transform>();
        _segment.Add(transform);
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
        // Loop through the segments in reverse
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
        Transform segment = Instantiate(_segmentPrefab);
        segment.position = _segment[_segment.Count - 1].position;

        _segment.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Make sure "other" object colliding is Snake/Player
        if (other.tag == "Food")
        {
            Grow();
        }
    }
}
