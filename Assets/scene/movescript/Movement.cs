
using UnityEngine;
using UnityEngine. AI;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public Camera camera;
    private NavMeshAgent agent;
    private RaycastHit hit;
    private string groundTag = "Ground";
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.collider.CompareTag(groundTag))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }

    }
}
