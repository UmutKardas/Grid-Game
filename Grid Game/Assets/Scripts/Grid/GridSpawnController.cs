using UnityEngine;
using System.Collections.Generic;

public class GridSpawnController : MonoBehaviour
{

    [SerializeField] private ScoreController scoreController;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private GameObject gridPrefab;
    [SerializeField] private GameObject grids;

    public List<GameObject> gridList = new List<GameObject>();



    public void SetGridSpawn(float value)
    {
        for (int i = 0; i < value; i++)
        {
            for (int k = 0; k < value; k++)
            {
                GameObject grid = Instantiate(gridPrefab, new Vector3(i, k, 0f), Quaternion.identity);
                gridList.Add(grid);
                grid.transform.parent = grids.transform;
            }
        }
        SetGridTransform(value);
    }



    private void SetGridTransform(float value)
    {
        grids.transform.position = new Vector3(grids.transform.position.x - (value / 2) + 0.5f, grids.transform.position.y - (value / 2) + 0.5f, 0f);
        cameraController.SetCameraFieldValue(value);
    }



    public void CheckIsComplete()
    {
        for (int i = 0; i < gridList.Count; i++)
        {
            if (gridList[i].GetComponent<GridEnvironmentController>().isComplete)
            {
                scoreController.SetScoreValue();
                foreach (var item in gridList)
                {
                    item.GetComponent<GridEnvironmentController>().isComplete = false;
                }
            }
        }
    }



    public void SetGridListClear()
    {
        if (gridList.Count > 0)
        {
            foreach (GameObject item in gridList)
            {
                Destroy(item);
            }
            gridList.Clear();
        }
    }
}
