using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public static event EventHandler OnAnyMouseCatch;

    [Header("Patrol Settings")]
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float speed = 3f;

    private Vector3 targetPosition;
    // Performans için: Distance kontrolünde karesini kullanmak daha hýzlýdýr (Sqrt iþlemi yapmaz)
    private float stopDistanceSqr = 0.01f; // 0.1f * 0.1f = 0.01f

    private void Start()
    {
        targetPosition = startPoint.position;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 moveDir = (targetPosition - transform.position).normalized;
        transform.position += moveDir * speed * Time.deltaTime;

        // Görseli döndür
        if (moveDir != Vector3.zero)
        {
            float rotateSpeed = 10f;
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        }

        // Mesafe kontrolü (sqrMagnitude iþlemciyi daha az yorar)
        if ((transform.position - targetPosition).sqrMagnitude < stopDistanceSqr)
        {
            targetPosition = targetPosition == startPoint.position ? endPoint.position : startPoint.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponentInParent<Player>();

        // Player bulunduysa iþlem yap
        if (player != null && player.HasKitchenObject())
        {
            OnAnyMouseCatch?.Invoke(this, EventArgs.Empty);

            player.GetKitchenObject().DestroySelf();
        }
    }

}
