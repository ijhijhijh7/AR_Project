using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject boardPrefab;
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private Button startButton;

    public void StartGame()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(ray, hits);

        if (hits.Count > 0)
        {
            Instantiate(boardPrefab, hits[0].pose.position, hits[0].pose.rotation);
            startButton.interactable = false; // 버튼 비활성화
        }
    }
}
