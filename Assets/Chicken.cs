using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMover : MonoBehaviour
{
    public Animator anim; // ������ �� ��������
    public List<Transform> waypoints; // ������������ ������ �����������
    public float moveSpeed = 2f; // �������� �������� ������

    private int currentWaypointIndex = 0; // ������ �������� �������� ����������

    void Start()
    {
        if (waypoints.Count > 0)
        {
            StartCoroutine(MoveToWaypoints());
        }
    }

    private IEnumerator MoveToWaypoints()
    {
        while (true)
        {
            Transform target = waypoints[currentWaypointIndex];
            anim.SetBool("isWalking", true); // �������� �������� ������

            // ��������� � ���������� ����
            while (Vector3.Distance(transform.position, target.position) > 0.1f)
            {
                // ������������ ������ � ������� ����
                Vector3 direction = (target.position - transform.position).normalized;
                transform.forward = direction;

                // ��������� � ����
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

                yield return null; // ���� ���������� �����
            }

            anim.SetBool("isWalking", false); // ������������� ��������

            // ������� ��������� ����� �� 5 �� 10 ������
            float waitTime = Random.Range(5f, 10f);
            yield return new WaitForSeconds(waitTime);

            // ��������� � ���������� ����
            currentWaypointIndex++;

            // ���� �������� ����� �������, �������� �������
            if (currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex = 0; // ����� ������� �� 0
            }
        }
    }
}