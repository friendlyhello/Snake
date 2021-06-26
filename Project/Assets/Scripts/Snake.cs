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
            transform.position = new Vector3(

            // Mathf.Round uses whole numbers, so it allows for grid-like movement
            Mathf.Round(transform.position.x) + _direction.x,
            Mathf.Round(transform.position.y) + _direction.y,
            0.0f
            );
    }
}
