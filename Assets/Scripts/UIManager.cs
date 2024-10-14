using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button placeButton;
    [SerializeField] private Button rotateButton;
    [SerializeField] private CubePlace cubePlacer;
    [SerializeField] private CubePreview cubePreview;
    [SerializeField] private GameStart gameStarter;

    [SerializeField] private GameObject[] cubePrefabs;

    private void Start()
    {
        startButton.onClick.AddListener(() => gameStarter.StartGame());
        placeButton.onClick.AddListener(() => {
            cubePlacer.PlaceCube(cubePreview.GetCurrentCube());
            cubePreview.CreatePreviewCube(GetRandomCubePrefab());
        });
        rotateButton.onClick.AddListener(() => cubePreview.RotateCurrentCube());

        cubePreview.CreatePreviewCube(GetRandomCubePrefab());
    }

    private GameObject GetRandomCubePrefab()
    {
        int randomIndex = Random.Range(0, cubePrefabs.Length);
        return cubePrefabs[randomIndex];
    }
}
