using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;
    [SerializeField]
    private float _platformSpeed = 3;
    private bool _targetReached = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // go to b
        // check if at b
        // go back to a 
        if (_targetReached == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _platformSpeed * Time.deltaTime);
            if(transform.position == _targetB.position)
            {
                _targetReached = true;
            }
        }
        else if (_targetReached == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _platformSpeed * Time.deltaTime);
            if(transform.position == _targetA.position)
            {
                _targetReached = false;
            }
        }

    }

    // collision detection
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    } 
}
