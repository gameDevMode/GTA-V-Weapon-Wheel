using System.Collections;
using UnityEngine;

namespace GTAWeaponWheel.Scripts
{
    public class Weapon : MonoBehaviour
    {
        public int Index;
        public string Name;
        public int Clips;
        public int ClipSize;
        private int ammo;

        public int Ammo => ammo;
        public int AmmoInUse => ammoInUse;

        private int ammoInUse;
        private bool _isReloading = false;
        
        public Weapon(int index = 0, string name = "Pistol", int clips = 5, int clipSize = 30)
        {
            Index = index;
            Name = name;
            Clips = clips;
            ClipSize = clipSize;
        }

        private void Start()
        {
            ammo = Clips * ClipSize;
            ammoInUse = ClipSize; //The ammo in our current clip
        }

    
        private void Shoot()
        {
            if(ammo + ammoInUse <= 0)
                return;
            
            if (ammoInUse > 0)
            {
                ammoInUse--;
            }
            else
            {
                StartCoroutine(Reload());
            }
        }

        private bool exec = false;
        private IEnumerator Reload()
        {
            //We need to reload!
            //Change the Clip Only Once
            if (!exec)
            {
                ammo -= ClipSize;
                Clips--;
                exec = true;
            }
            _isReloading = true;
            yield return new WaitForSeconds(1f);
            ammoInUse = ClipSize;
            exec = false;
            _isReloading = false;
        }
    
        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !_isReloading)
                Shoot();
            if (ammoInUse <= 0 && ammo > 0)
            {
                //Reload Automatically
                StartCoroutine(Reload());
            }
        }
    }
}