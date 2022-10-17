using System;
using UnityEngine;
using TMPro;

public class RebuildButtonController : MonoBehaviour
{

    [SerializeField] private TMP_InputField gridInputfield;
    [SerializeField] private TMP_Text invalidValueText;

    [SerializeField] private CameraController cameraController;
    [SerializeField] private GridSpawnController gridSpawnController;

    [HideInInspector] public int gridInput;



    public void SetRebuildButton()
    {
        gridInput = Convert.ToInt32(gridInputfield.text);
        gridSpawnController.SetGridListClear();

        if (gridInput > 20 || gridInput == 0)
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
