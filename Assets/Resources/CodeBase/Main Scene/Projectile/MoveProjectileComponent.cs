using UnityEngine;

namespace Resources.CodeBase.Main_Scene.Projectile
{
    
    public class MoveProjectileComponent : MonoBehaviour
    {
        [SerializeField] private float speed; // скорость полета пули

        #region Mono

        private void Update()
        {
            Movement();
        }

        #endregion

        #region User Methods

        public void Movement() // Движение пули
        {
            Vector3 movement = new Vector3(0f, 1f, 0f);

            // что бы скорость была стабильной в любом случае
            
            transform.Translate(movement * speed * Time.deltaTime);
        }

        #endregion
    }
}