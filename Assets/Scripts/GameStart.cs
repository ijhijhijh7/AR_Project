using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject planePrefab; // Plane 프리팹
    [SerializeField] private CubeGrid cubeGrid; // CubeGrid 참조
    [SerializeField] private Button startButton; // Start 버튼 참조

    public void StartGame()
    {
        // Plane을 생성할 위치를 결정 (예시로는 카메라 앞쪽에 생성)
        Vector3 planePosition = Camera.main.transform.position + Camera.main.transform.forward * 5.0f;

        // Plane 프리팹을 주어진 위치에 생성
        GameObject createdPlane = Instantiate(planePrefab, planePosition, Quaternion.identity);

        // CubeGrid에 생성된 Plane을 전달하여 격자 초기화
        cubeGrid.InitializeGrid(createdPlane);

        // Start 버튼 비활성화
        startButton.interactable = false;
    }
}
