using UnityEngine;
using Kardas;

public class GridTargetController : MonoBehaviour
{

    private Ray ray;
    private RaycastHit hit;



    void Update()
    {
        SetGridTarget();
    }



    private void SetGridTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool isHit = Physics.Raycast(ray, out hit);

            if (isHit && hit.collider.CompareTag(Tag.GRID))
            {
                hit.collider.transform.GetChild(0).gameObject.SetActive(true);
                hit.collider.tag = Tag.MARKED_GRID;
            }
        }
    }
}
