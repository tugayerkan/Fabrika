using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMove : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent navMeshAgent;
    public Rigidbody rb;
    public Camera cam;
    public Transform ray;
    public float impactForce = 1.1f;
    public float Smoothness = 0.2f;
    public float rayLength = 5;
    private BumperCar bumper;
    public Transform defaultAgentPoses;





    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Agent"))
        {
            StartCoroutine(CrashDelay());
            rb.AddForce(0, 0, transform.position.z * impactForce, ForceMode.Impulse);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grounded"))
        {
            bumper.isCrashed = true;
            GameManager.singleton.CarCrashed();
        }
    }
    void Start()
    {
        bumper = GetComponent<BumperCar>();
    }


    void Update()
    {

        if (navMeshAgent.isActiveAndEnabled && !bumper.stunned && !bumper.isCrashed) 
        {
            Ray ray = cam.ScreenPointToRay(Vector3.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayLength)) 
            {
                navMeshAgent.SetDestination(hit.point);
            }
        }

        if (bumper.isCrashed == false && bumper.stunned == false)
        {
            navMeshAgent.enabled = true;
        }
    }

    IEnumerator CrashDelay()
    {
        navMeshAgent.enabled = false;
        bumper.stunned = true;
        yield return new WaitForSecondsRealtime(2f);
        bumper.stunned = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = -transform.up * rayLength;
        Gizmos.DrawRay(ray.position, direction);
    }

}
