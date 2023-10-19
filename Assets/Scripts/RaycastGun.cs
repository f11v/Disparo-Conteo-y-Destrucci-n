using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RaycastGun : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 50f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;

    LineRenderer laserLine;
    float fireTimer;

    int cubeShots = 0;
    int sphereShots = 0;

    ConteoEsferas conteoEsferas;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
        conteoEsferas = FindObjectOfType<ConteoEsferas>(); // Encuentra el objeto con el script ConteoEsferas
    }

    void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && fireTimer > fireRate)
        {
            fireTimer = 0;
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
            {
                laserLine.SetPosition(1, hit.point);

                if (hit.transform.CompareTag("Cube")) 
                {
                    cubeShots++;
                    if (cubeShots >= 2)
                    {
                        Destroy(hit.transform.gameObject);
                        cubeShots = 0;

                        // Llama a la función para contar el cubo eliminado
                        conteoEsferas.CuboEliminado();
                    }
                }
                else if (hit.transform.CompareTag("Sphere")) 
                {
                    sphereShots++;
                    if (sphereShots >= 3)
                    {
                        Destroy(hit.transform.gameObject);
                        sphereShots = 0;

                        // Llama a la función para contar la esfera eliminada
                        conteoEsferas.EsferaEliminada();
                    }
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            }
            StartCoroutine(ShootLaser());
        }
    }

    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}

