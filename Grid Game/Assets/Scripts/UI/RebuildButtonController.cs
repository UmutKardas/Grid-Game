using System;
using UnityEngine;
using TMPro;

public class RebuildButtonController : MonoBehaviour
{
    [SerializeField] private CameraController cameraController;
    [SerializeField] private GridSpawnController gridSpawnController;
    [SerializeField] private TMP_InputField gridInputfield;
    [SerializeField] private TMP_Text invalidValueText;

    [HideInInspector] public int gridInput;



    public void SetRebuildButton()
    {
        gridSpawnController.SetGridListClear();
        gridInput = Convert.ToInt32(gridInputfield.text);

        if (gridInput > 20 || gridInput <= 1)
        {
            invalidValueText.gameObject.SetActive(true);
        }
        else
        {
            invalidValueText.gameObject.SetActive(false);
            gridSpawnController.SetGridSpawn(gridInput);
            cameraController.SetCameraFieldValue(gridInput);
        }
    }

}
