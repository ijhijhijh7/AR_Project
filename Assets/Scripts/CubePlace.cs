using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CubePlace : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raycastManager;
    private GameObject currentCube;  // 현재 중앙에 표시 중인 큐브

    public void PlaceCube(GameObject selectedPrefab)
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(ray, hits);

        if (hits.Count > 0)
        {
            // 미리보기 큐브 삭제
            if (currentCube != null)
            {
                Destroy(currentCube);
            }

            // 큐브 생성
            GameObject placedCube = Instantiate(selectedPrefab, hits[0].pose.position, selectedPrefab.transform.rotation);  // selectedPrefab의 기본 회전을 사용
            Rigidbody rb = placedCube.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }
    }

    public void SetPreviewCube(GameObject previewCube)
    {
        currentCube = previewCube;
    }
}
