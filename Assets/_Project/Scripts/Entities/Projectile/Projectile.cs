using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shtmup
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed;
        // Add Hit effects

        Transform parent;

        public void SetSpeed(float speed) => this.speed = speed;
        public void SetParent(Transform parent) => this.parent = parent;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            transform.SetParent(null);
            transform.position += transform.up * (speed * Time.deltaTime);
        }

        void OnCollisionEnter(Collision collision)
        {
            //Debug.Log("hit");
            var plane = collision.gameObject.GetComponent<Plane>();
            if (plane != null)
            {
                plane.TakeDamage(10);
            }
            Destroy(gameObject);
        }


    }
}
