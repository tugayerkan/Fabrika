using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BumperCar : MonoBehaviour
{
    public int id;
    public bool isCrashed = false;
    public NavMeshAgent navMeshAgent;
    public Rigidbody rb;
    private Vector3 defaultPos;
    private Vector3 defaultEuler;
    public GameObject meshes;
    public bool stunned = false;


    private void Awake()
    {
        defaultPos = transform.position;
        defaultEuler = transform.eulerAngles;
    }
    public void ResetCar()
    {
        transform.position = defaultPos;
        transform.eulerAngles = defaultEuler;
        rb.isKinematic = false;
        navMeshAgent.enabled = true;
        meshes.SetActive(true);
        isCrashed = false;
        stunned = false;
    }
    public void GameOver()
    {
        rb.isKinematic = true;
        navMeshAgent.enabled = false;
        meshes.SetActive(false);
    }


}
