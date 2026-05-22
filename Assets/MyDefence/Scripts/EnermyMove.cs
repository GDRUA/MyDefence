using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform target;             // 이동 목적지 (End 오브젝트)
    public float speed = 5f;             // 이동 속도
    public float arrivalDistance = 0.1f; // 도착 인정 거리

    private bool isArrived = false;      // 중복 실행 방지 플래그

    void Update()
    {
        if (target == null || isArrived) return;

        // 1. 종점을 향해 이동
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // 2. 도착 판정
        if (Vector3.Distance(transform.position, target.position) <= arrivalDistance)
        {
            OnArrival();
        }
    }

    // 종점에 도착했을 때 실행되는 함수
    void OnArrival()
    {
        isArrived = true; // 다시 실행되지 않도록 막음

        // [요구사항 2] Debug.Log 출력
        Debug.Log("종점 도착!!!!");

        // [요구사항 1] 오브젝트 kill (Destroy)
        Destroy(gameObject);
    }
}