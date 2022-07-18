using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public int height;
    private bool finishActivated;
    private FinishLines finishLines;
    private float finishLineCollector;
    private float SumOfFinishHeight;
    public List<CollectibleCubes> collectibleCubesList = new List<CollectibleCubes>();
    public TriggerToFinish triggerEvents;
    [SerializeField] private GameObject Player;
    [SerializeField] ParticleSystem collectEffect;
    [SerializeField] ParticleSystem finishFireworks;
    [SerializeField] ParticleSystem plusOne;
    public AudioClip audioClip;
    AudioSource audioSource;
    public Animator anim;





    private static Collector _instance;

    public static Collector Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        collectEffect = GetComponent<ParticleSystem>();
        plusOne = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        
        
    }

    //Increasing height of the main cube, collecting cube stays bottom.
    void Update()
    {

        Player.transform.position = new Vector3(transform.position.x, height + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -height, 0);


        if (finishActivated)
        {
            Player.transform.position = new Vector3(transform.position.x, height + SumOfFinishHeight, transform.position.z);
            this.transform.localPosition = new Vector3(0, -height - finishLineCollector, 0);
        }

    }


    //Adding cubes and setting the range of the added cubes.
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Cubes")
        {

            
            var collectibleCube = other.gameObject.GetComponent<CollectibleCubes>();
            anim.Play("Jumping");

            if (collectibleCube.GetIsCollected() == false)
            {
                collectEffect.Play();
                plusOne.Play();
                audioSource.PlayOneShot(audioClip, 0.4f);
                collectibleCubesList.Add(collectibleCube);
                height += 1;
                collectibleCube.Collect();
                collectibleCube.SetIndex(height);
                other.gameObject.transform.parent = Player.transform;
            }

        }

        if (other.gameObject.tag == "Finish")
        {
            

            if (collectibleCubesList.Count == 0)
            {

            }
            else
            {
                
                JumpFromObstacles(other);
                finishActivated = true;
                finishLines = other.GetComponent<FinishLines>();
                SumOfFinishHeight = finishLines.finishLineHeight;
            }
        }

        if (other.gameObject.tag == "Trophy")
        {
            finishFireworks.Play();
            triggerEvents.RestartMethod(other);
        }
    }

    public void JumpFromObstacles(Collider other)
    {
        

        if (collectibleCubesList.Count == 0)
        {

        }
        else
        {
            
            collectibleCubesList[collectibleCubesList.Count - 1].gameObject.transform.parent = null;
            collectibleCubesList.RemoveAt(collectibleCubesList.Count - 1);
            height--;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;


        }

    }
}

