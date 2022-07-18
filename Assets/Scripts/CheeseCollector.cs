using UnityEngine;
using UnityEngine.UI;

public class CheeseCollector : MonoBehaviour
{
    public double cheeses;
    public Text cheeseText;
    //public Text cheeseTextGameOver;
    //public Text cheeseTextFinish;
    [SerializeField] ParticleSystem pointEffect;
    AudioSource audioSource;
    public AudioClip audioClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("Cheeses"))
        {
            pointEffect.Play();
            PointCalculator(collision);
            audioSource.PlayOneShot(audioClip, 0.5f);
        }
    }


    //Calculating and printing points to the UI here
    private void PointCalculator(Collider collision)
    {
        Destroy(collision.gameObject);
        cheeses++;
        cheeseText.text = "Cheeses: " + cheeses;
        //cheeseTextGameOver.text = "Cheeses: " + cheeses;
        //cheeseTextFinish.text = "Cheeses: " + cheeses;


    }

}
