using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

public class Player : NetworkBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) { return; }

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast (ray, out hit)) {
                navMeshAgent.SetDestination(hit.point);
            }
        }
    }

    public override void OnStartAuthority() {
        cam.gameObject.SetActive(true);
        cam.enabled = true;
    }
}
