using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMover : MonoBehaviour
{
    public Animator anim; // Ссылка на аниматор
    public List<Transform> waypoints; // Динамический массив трансформов
    public float moveSpeed = 2f; // Скорость движения курицы

    private int currentWaypointIndex = 0; // Индекс текущего целевого трансформа

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
            anim.SetBool("isWalking", true); // Включаем анимацию ходьбы

            // Двигаемся к следующему пути
            while (Vector3.Distance(transform.position, target.position) > 0.1f)
            {
                // Поворачиваем курицу в сторону цели
                Vector3 direction = (target.position - transform.position).normalized;
                transform.forward = direction;

                // Двигаемся к цели
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

                yield return null; // Ждем следующего кадра
            }

            anim.SetBool("isWalking", false); // Останавливаем анимацию

            // Ожидаем случайное время от 5 до 10 секунд
            float waitTime = Random.Range(5f, 10f);
            yield return new WaitForSeconds(waitTime);

            // Переходим к следующему пути
            currentWaypointIndex++;

            // Если достигли конца массива, начинаем сначала
            if (currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex = 0; // Сброс индекса на 0
            }
        }
    }
}