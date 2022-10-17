using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridSpawnController))]
public class EditorController : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GridSpawnController gridSpawnController = (GridSpawnController)target;
        if (GUILayout.Button("Generate Grid System"))
        {
            if (gridSpawnController.gridList.Count <= 0)
            {
                gridSpawnController.SetGridSpawn(5);
            }
        }


        if (GUILayout.Button("Delete Grid System"))
        {
            if (gridSpawnController.gridList.Count > 0)
            {
                foreach (var item in gridSpawnController.gridList)
                {
                    item.SetActive(false);
                }
                gridSpawnController.gridList.Clear();
            }
        }
    }
}