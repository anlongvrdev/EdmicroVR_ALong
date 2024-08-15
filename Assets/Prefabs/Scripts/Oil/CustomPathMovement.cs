using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPathMovement : MonoBehaviour
{
    // Mảng các điểm mà vật thể sẽ di chuyển qua
    public Vector3[] pathPoints;
    public float speed = 5f; // Tốc độ di chuyển
    public float rotationSpeed = 5f; // Tốc độ xoay
    private int currentPointIndex = 0; // Chỉ số của điểm hiện tại trong mảng
    private bool movingForward = true; // Hướng di chuyển

    void Update()
    {
        if (pathPoints.Length == 0)
            return;

        // Tính khoảng cách giữa vị trí hiện tại và điểm đích tiếp theo
        float step = speed * Time.deltaTime;
        Vector3 targetPosition = pathPoints[currentPointIndex];

        // Di chuyển vật thể về phía điểm đích
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // Tính toán hướng tới điểm đích
        Vector3 direction = (targetPosition - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            // Tính toán góc quay cần thiết để hướng tới điểm đích
            Quaternion targetRotation = Quaternion.LookRotation(direction,Vector3.up);

            // Xoay dần về phía góc quay mục tiêu
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            //transform.Rotate(0, -90, 0);
        }

        // Kiểm tra xem vật thể đã tới điểm đích chưa
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Đã đến điểm hiện tại, di chuyển đến điểm tiếp theo
            if (movingForward)
            {
                currentPointIndex++;
                if (currentPointIndex >= pathPoints.Length)
                {
                    currentPointIndex = pathPoints.Length - 1;
                    movingForward = false; // Đ ổi hướng khi đạt đến điểm cuối cùng
                }
            }
            else
            {
                currentPointIndex--;
                if (currentPointIndex < 0)
                {
                    currentPointIndex = 0;
                    movingForward = true; // Đổi hướng khi đạt đến điểm đầu tiên
                }
            }
        }
    }

    // Vẽ đường đi trong chế độ Editor để dễ theo dõi
    void OnDrawGizmos()
    {
        if (pathPoints == null || pathPoints.Length < 2)
            return;

        Gizmos.color = Color.red;
        for (int i = 0; i < pathPoints.Length - 1; i++)
        {
            Gizmos.DrawLine(pathPoints[i], pathPoints[i + 1]);
        }
    }
}
