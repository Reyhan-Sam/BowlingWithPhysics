using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private BallController ball;
    [SerializeField] GameObject pinCollection;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;
    private FallTrigger[] FallTriggers;
    private FallTrigger[] pins;
    private GameObject pinObjects;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
       // pins = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include);
        pins = FindObjectsByType<FallTrigger>(FindObjectsSortMode.None);

        foreach (FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();
    }


    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();

    }

    private void SetPins(){
        if(pinObjects){
            foreach(Transform child in pinObjects.transform){
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }

        pinObjects = Instantiate(pinCollection, pinAnchor.transform.position, Quaternion.Euler(0,90,0), transform); 

        FallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include,FindObjectsSortMode.None);

        foreach(FallTrigger pin in FallTriggers){

            pin.OnPinFall.AddListener(IncrementScore);
        }   

        
    }
    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }

    

}
