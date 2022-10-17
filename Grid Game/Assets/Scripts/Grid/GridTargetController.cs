using UnityEngine;
using Kardas;

public class GridTargetController : MonoBehaviour
{

    [SerializeField] private GridSpawnController gridSpawnController;
    [SerializeField] private Color choiceColor;

    private Ray ray;
    private RaycastHit hit;



    void Update()
    {
        SetGridTarget();
    }



    private void SetGridTarget()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isHit = Physics.Raycast(ray, out hit);

        if (Input.GetMouseButtonUp(0))
        {
            if (isHit && hit.collider.CompareTag(Tag.GRID))
            {
                hit.collider.transform.GetChild(0).gameObject.SetActive(true);
                hit.collider.GetComponent<SpriteRenderer>().color = choiceColor;
                hit.collider.GetComponent<GridEnvironmentController>().isEmpty = true;
            }


            if (isHit && hit.collider.GetComponent<GridEnvironmentController>().isEmpty && gridSpawnController.gridList.Count > 0)
            {
                foreach (var item in gridSpawnController.gridList)
                {
                    item.GetComponent<GridEnvironmentController>().CheckGrid();

                }

            }

            gridSpawnController.CheckIsComplete();
        }
    }
}
