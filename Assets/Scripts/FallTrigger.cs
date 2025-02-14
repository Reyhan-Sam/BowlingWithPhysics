using UnityEngine;
using System;
using UnityEngine.Events;

public class FallTrigger : MonoBehaviour
{
    public UnityEvent OnPinFall = new();
    public bool isPinFallen = false;
    private void OnTriggerEnter(Collider triggeredObject){
       // Debug.Log($"{gameObject.name} collided with {triggeredObject.gameObject.name}");

        if(triggeredObject.CompareTag("Ground") && !isPinFallen){
            isPinFallen = true;
            OnPinFall?.Invoke();
            Debug.Log($"{gameObject.name} has fallen");

        }
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
