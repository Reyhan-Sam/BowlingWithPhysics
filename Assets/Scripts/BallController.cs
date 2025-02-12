using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;
    private bool isBallLaunched;
    private Rigidbody ballRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
    }

    private void LaunchBall(){
        ballRB.AddForce(transform.forward*force,ForceMode.Impulse);

        if(isBallLaunched)return;
        isBallLaunched = true;
        ballRB.AddForce(transform.forward*force, ForceMode.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
