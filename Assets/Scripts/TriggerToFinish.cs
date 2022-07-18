using System.Collections;

using UnityEngine;

public class TriggerToFinish : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public SwerveMovement swerveMovement;
    public GameObject finishedPanel;
    [SerializeField] ParticleSystem death;
    AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip dissapointment;


    private void Start()
    {
        death = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();

    }




    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Obstacle")
        {
            death.Play();
            audioSource.PlayOneShot(audioClip, 0.5f);
            audioSource.PlayOneShot(dissapointment, 0.5f);
            RestartMethod(other);
        }

        if (other.gameObject.tag == "Finish")
        {
            death.Play();
            audioSource.PlayOneShot(audioClip, 0.5f);
            audioSource.PlayOneShot(dissapointment, 0.5f);
            RestartMethod(other);
        }
    }

    public void RestartMethod(Collider other)
    {
        IEnumerator TimeDelay()
        {
            
            swerveMovement.forwardSpeed = 0f;
            yield return new WaitForSeconds(2);
            gameOver = true;

            if (gameOver)
            {

                gameOverPanel.SetActive(true);
                player.transform.position = respawnPoint.transform.position;
            }
            else
            {
                swerveMovement.SwerveSettings();
            }


            if (other.gameObject.tag == "Finish")
            {

                if (gameOver)
                {
                    gameOverPanel.SetActive(true);
                    player.transform.position = respawnPoint.transform.position;
                }
                else
                {
                    swerveMovement.SwerveSettings();
                }
            }


            if (other.gameObject.tag == "Trophy")
            {


                if (gameOver)
                {
                    gameOverPanel.SetActive(false);
                    finishedPanel.SetActive(true);
                    player.transform.position = respawnPoint.transform.position;
                }
            }

        }


        StartCoroutine(TimeDelay());



    }

}
