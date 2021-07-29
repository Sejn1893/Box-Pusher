using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    private Vector3 _destinationPosition;
    private bool _canMove;
    // Start is called before the first frame update
    void Start()
    {
        
        _destinationPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if(_canMove)
        {
            if (Vector3.Distance(transform.position, _destinationPosition) <= 0.1f)
            {
                transform.position = _destinationPosition;
            }
            transform.position = Vector3.MoveTowards(transform.position, _destinationPosition, 2f * Time.deltaTime);
        }
    }
    public bool BoxMove(Vector3 direction)
    {
        BoxObjectDetect(direction);
        if (_canMove)
        {
            _destinationPosition = transform.position + direction;
        }
        return _canMove;
    } 
    private void BoxObjectDetect(Vector3 direction)
    {
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = direction;
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 1f))
        {
            if (hit.collider.gameObject.tag == "Wall" || hit.collider.gameObject.tag == "Box")
            {
                _canMove = false;
            }
            else
            {
                _canMove = true;
            }
        }
        else
        {
            _canMove = true;
        }
    }
}
