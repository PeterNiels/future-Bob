using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveDestination : MonoBehaviour
{
    public bool answered = false;
    public Transform goal;
    public int opgavenummer;

    public GameObject canvas;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
    }
    void Update()
    {
        if (Vector3.Distance(goal.position, transform.position) < 10 && answered == false)
        {
            agent.destination = goal.position;
            agent.isStopped = false;

            if (Vector3.Distance(goal.position, transform.position) < 5)
            {
                agent.isStopped = true;
                goal.parent.GetComponent<PlayerMovement>().allowtomove = false;
                canvas.SetActive(true);
                canvas.GetComponent<databasefechter>().opgaveClass = canvas.GetComponent<databasefechter>().opgave.opgaveliste[opgavenummer];
                canvas.GetComponent<databasefechter>().spørgsmålet.text = canvas.GetComponent<databasefechter>().opgave.opgaveliste[opgavenummer].opgaver;   
                 
                canvas.GetComponent<databasefechter>().currentEnemy = gameObject.GetComponent<MoveDestination>();
            } 
        }
        else
        {
            agent.isStopped = true;
        }
    }
}
