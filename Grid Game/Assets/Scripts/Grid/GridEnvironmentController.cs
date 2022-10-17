using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridEnvironmentController : MonoBehaviour
{

    [SerializeField] private RebuildButtonController rebuildButtonController;
    [SerializeField] private List<Vector3> direction = new List<Vector3>();
    [SerializeField] private LayerMask layerMask;


    public bool isEmpty = false;
    public bool isComplete = false;
    public int markedGrid = 0;


    private RaycastHit hit;



    private void Start()
    {
        rebuildButtonController = GameObject.FindObjectOfType<RebuildButtonController>();
    }



    public void CheckGrid()
    {
        if (isEmpty)
        {
            markedGrid = 0;

            for (int i = 0; i < direction.Count; i++)
            {
                bool IsHit = Physics.Raycast(transform.position, direction[i], out hit, 0.6f, layerMask);

                if (IsHit && hit.collider.GetComponent<GridEnvironmentController>().isEmpty == true)
                {
                    markedGrid++;

                    if (markedGrid >= 2)
                    {
                        isComplete = true;
                        StartCoroutine(Complate());
                    }
                }
            }
        }
    }



    IEnumerator Complate()
    {
        yield return new WaitForSeconds(0.1f);
        rebuildButtonController.SetRebuildButton();
    }
}