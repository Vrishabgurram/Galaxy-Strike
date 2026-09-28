using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] lasers;
    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Transform trackingTarget;
    [SerializeField] private float targetDistance = 100f;
    [SerializeField] private float bulletSpeed = 150f;

    bool isFiring = false;
    ParticleSystem.EmissionModule[] emissionModules;

    private void Start()
    {
        Cursor.visible = false;
        // Cache emission modules for each laser
        emissionModules = new ParticleSystem.EmissionModule[lasers.Length];

        for (int i = 0; i < lasers.Length; i++)
        {
            var main = lasers[i].main;
            main.startSpeed = bulletSpeed;

            emissionModules[i] = lasers[i].emission;
            emissionModules[i].enabled = false; // off initially
        }
    }

    private void OnFire(InputValue value)
    {
        isFiring = value.isPressed;

        // Enable or disable emission for all lasers
        for (int i = 0; i < emissionModules.Length; i++)
        {
            emissionModules[i].enabled = isFiring;
        }
    }

    private void Update()
    {
        ProcessFire();
        TrackMouse();
        TrackTarget();
        RotateToTarget();
    }

    private void RotateToTarget()
    {
        foreach (ParticleSystem laser in lasers)
        {
            Vector3 dir = trackingTarget.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            laser.transform.rotation = lookRotation;
        }
    }

    private void TrackTarget()
    {
        Vector3 targetPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        trackingTarget.position = Camera.main.ScreenToWorldPoint(targetPosition);
    }

    private void TrackMouse()
    {
        crosshair.position = Input.mousePosition;
    }

    private void ProcessFire()
    {
        foreach (ParticleSystem laser in lasers)
        {
            if (isFiring)
            {
                if (!laser.isPlaying)
                {
                    laser.Clear(); // ensures instant restart
                    laser.Play();
                }
            }
            /*else
            {
                if (laser.isPlaying)
                {
                    laser.Stop();
                }
            }*/
        }
    }
}
