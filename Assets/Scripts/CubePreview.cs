using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePreview : MonoBehaviour
{
    private GameObject currentCube;

    void Update()
    {
        UpdatePreviewCubePosition();
    }

    public void CreatePreviewCube(GameObject cubePrefab)
    {
        if (currentCube != null)
        {
            Destroy(currentCube);  // 기존 미리보기 큐브 삭제
        }

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cubePosition = Camera.main.transform.position + cameraForward * 0.5f;

        currentCube = Instantiate(cubePrefab, cubePosition, Quaternion.Euler(90, 0, 0));
        Rigidbody previewRb = currentCube.AddComponent<Rigidbody>();
        previewRb.isKinematic = true;
    }

    public void UpdatePreviewCubePosition()
    {
        if (currentCube != null)
        {
            Vector3 cameraForward = Camera.main.transform.forward;
            Vector3 cubePosition = Camera.main.transform.position + cameraForward * 0.5f;
            currentCube.transform.position = cubePosition;
        }
    }

    public void RotateCurrentCube()
    {
        if (currentCube != null)
        {
            currentCube.transform.Rotate(Vector3.forward, 90f);
        }
    }

    public GameObject GetCurrentCube()
    {
        return currentCube;
    }
}
