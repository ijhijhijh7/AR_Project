using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CubePlace : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;    // 배치할 큐브 프리팹
    [SerializeField] Button placeButton;       // 착수 버튼
    [SerializeField] ARRaycastManager raycastManager;

    private GameObject currentCube;  // 현재 중앙에 표시 중인 큐브

    void Start()
    {
        // 착수 버튼에 클릭 이벤트 할당
        placeButton.onClick.AddListener(PlaceCubeAtRaycastHit);

        // 미리보기 큐브를 초기화
        CreatePreviewCube();
    }

    void Update()
    {
        // 매 프레임마다 카메라 앞에 미리보기 큐브를 업데이트
        if (currentCube != null)
        {
            UpdatePreviewCubePosition();
        }
    }

    // 미리보기 큐브 생성
    void CreatePreviewCube()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cubePosition = Camera.main.transform.position + cameraForward * 0.5f;  // 카메라 앞 0.5미터

        // 큐브를 생성
        currentCube = Instantiate(cubePrefab, cubePosition, Quaternion.identity);
    }

    // 미리보기 큐브의 위치 업데이트
    void UpdatePreviewCubePosition()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cubePosition = Camera.main.transform.position + cameraForward * 0.5f;  // 카메라 앞 0.5미터
        currentCube.transform.position = cubePosition; // 미리보기 큐브의 위치 업데이트
    }

    void PlaceCubeAtRaycastHit()
    {
        Ray ray = new Ray();
        ray.origin = Camera.main.transform.position;
        ray.direction = Camera.main.transform.forward;

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(ray, hits);
        if (hits.Count > 0)
        {
            // 미리보기 큐브를 삭제
            if (currentCube != null)
            {
                Destroy(currentCube);
            }

            // 레이캐스트 위치에 큐브를 생성
            Instantiate(cubePrefab, hits[0].pose.position, hits[0].pose.rotation);
        }

        // 미리보기 큐브를 다시 생성
        CreatePreviewCube();
    }
}
