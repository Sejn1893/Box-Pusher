using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    private Vector3 _direction;
    private Vector3 _destinationPosition;
    private bool _canMovePlayer;
    // Start is called before the first frame update
    void Start()
    {
        _destinationPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _destinationPosition) <= 0.1f)
        {
            transform.position = _destinationPosition;

            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            if (h != 0)
            {
              _direction = new Vector3(h, 0, 0);
                ObjectDetection();
            }
            else if (v != 0)
            {
               _direction = new Vector3(0, 0, v);
                ObjectDetection();
            }
            else
            {
                _direction = Vector3.zero;
            }
            if (_canMovePlayer)
            {
                _destinationPosition = transform.position + _direction;
            }
            
            
        }
        transform.position = Vector3.MoveTowards(transform.position, _destinationPosition, Speed * Time.deltaTime);
        
    }
    private void ObjectDetection()
    {
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = _direction;
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 1f))
        {
            if (hit.collider.gameObject.tag == "Box")
            {
                BoxMovement MoveBox = hit.collider.gameObject.GetComponent<BoxMovement>();
                _canMovePlayer = MoveBox.BoxMove(_direction);
            }
            else if (hit.collider.gameObject.tag == "Wall")
            {
                _canMovePlayer = false;
            }
            else
            {
                _canMovePlayer = true;
            }
        }
        else
        {
            _canMovePlayer = true;
        }

    }
}
