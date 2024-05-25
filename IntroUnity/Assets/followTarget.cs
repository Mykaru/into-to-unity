using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTarget : MonoBehaviour
{

    public float followDistance = 5f;
    public Transform target;
    public float followSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + new Vector3(0.0f, 0.0f, -followDistance);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
