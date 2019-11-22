using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform target;
    //public Transform playerObject;
    //public float distanceFromObject = 35f;

    
    void Update()
    {
        transform.position = target.position;
        //Vector3 lookOnObject = playerObject.position - transform.position;
        //lookOnObject = playerObject.position - transform.position;
        //transform.forward = lookOnObject.normalized;

        //Vector3 playerLastPosition;
        //playerLastPosition = playerObject.position - lookOnObject.normalized * distanceFromObject;
        //playerLastPosition.y = playerObject.position.y + distanceFromObject / 2;
        //transform.position = playerLastPosition;
    }
}
