using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGrid : MonoBehaviour
{
    [SerializeField] private GameObject planePrefab;
    [SerializeField] private Vector2 gridSize = new Vector2(10, 10); // 격자의 크기
    [SerializeField] private float cellSize = 0.1f; // 격자의 한 셀의 크기

    private bool[,] grid;
    private GameObject instantiatedPlane; // 동적으로 생성된 Plane

    // Plane을 생성하고 격자를 초기화
    public void InitializeGrid(GameObject plane)
    {
        instantiatedPlane = plane; // 외부에서 생성된 Plane을 받아옴

        // Plane의 크기에 맞춰 격자 배열 초기화
        grid = new bool[(int)gridSize.x, (int)gridSize.y];
    }

    public Vector3 GetNextAvailablePosition()
    {
        // 격자에서 빈 셀을 찾아 그 위치를 반환
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                if (!grid[x, y])
                {
                    grid[x, y] = true; // 해당 위치 사용 중으로 표시
                    return CalculateWorldPosition(x, y); // 월드 좌표로 변환
                }
            }
        }
        return Vector3.zero; // 사용할 수 있는 위치가 없으면 0 반환
    }

    private Vector3 CalculateWorldPosition(int x, int y)
    {
        // Plane의 위치를 기준으로 격자 위치를 월드 좌표로 변환
        Vector3 planePosition = instantiatedPlane.transform.position;
        return planePosition + new Vector3(x * cellSize, 0, y * cellSize);
    }
}
