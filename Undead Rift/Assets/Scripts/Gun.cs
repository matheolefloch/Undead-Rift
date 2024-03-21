using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gun : MonoBehaviour
{
    [SerializeField] private GunData gunData;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject ImpactEffect;
    [SerializeField] TextMeshProUGUI ReloadText; 
    [SerializeField] TextMeshProUGUI AmmoText; 
    public Camera fpsCamera;
    // 
    float timeSinceLastShot;
    private void Start()
    {
        gunData.reloading = false;
        gunData.currentAmmo = gunData.magSize;
        PlayerShoot.shootInput = Shoot;
        PlayerShoot.reloadInput = StartReload;
    }

    public void StartReload()
    {
        if (!gunData.reloading) { 
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        ReloadText.enabled = false;

        gunData.reloading = true;

        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magSize;

        gunData.reloading = false;
    }

    private bool CanShoot() {
        return !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);
    }
    public void Shoot()
    {
        if (gunData.currentAmmo > 0) 
        {
            if (CanShoot()) 
            {
                if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    if (damageable != null) { 
                        damageable.TakeDamage((int)gunData.damage);
                    }
                    GameObject ImpactGO = Instantiate(ImpactEffect,hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                    Destroy(ImpactGO, 2f);
                }
                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                OnGunShot();
            }
        }
        else 
        {
            if (CanShoot()) 
                ReloadText.enabled = true;
        }
    }

    private void Update()
    {
        AmmoText.text = $"{gunData.currentAmmo} / {gunData.magSize}";
        timeSinceLastShot += Time.deltaTime;
        Debug.DrawRay(fpsCamera.transform.position, fpsCamera.transform.forward*gunData.maxDistance);
    }

    private void OnGunShot()
    {
        muzzleFlash.Play();
    }
}
