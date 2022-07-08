using UnityEngine;

namespace UIScripts
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject spawner1;
        [SerializeField] private GameObject spawner2;
        [SerializeField] private GameObject spawner3;
        [SerializeField] private GameObject spawner4;
        [SerializeField] private GameObject spawner5;
        
        private GameManager _gameManager;
        
        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }
        
        public void Button_Light()
        {
            MakeSelectable();
            Debug.Log("Light Unit Adding");
        }

        public void Button_Medium()
        {
            MakeSelectable();
            Debug.Log("Medium Unit Adding");
        }
    
        public void Button_Heavy()
        {
            MakeSelectable();
            Debug.Log("Heavy Unit Adding");
        }
    
        public void Button_Special()
        {
            MakeSelectable();
            Debug.Log("Special Unit Adding");
        }

        private void MakeSelectable()
        {
            spawner1.GetComponent<Renderer>().material.color = Color.cyan;
            spawner2.GetComponent<Renderer>().material.color = Color.cyan;
            spawner3.GetComponent<Renderer>().material.color = Color.cyan;
            spawner4.GetComponent<Renderer>().material.color = Color.cyan;
            spawner5.GetComponent<Renderer>().material.color = Color.cyan;
            _gameManager.SelectPhase = true;
        }

        public void MakeUnselectable()
        {
            spawner1.GetComponent<Renderer>().material.color = Color.white;
            spawner2.GetComponent<Renderer>().material.color = Color.white;
            spawner3.GetComponent<Renderer>().material.color = Color.white;
            spawner4.GetComponent<Renderer>().material.color = Color.white;
            spawner5.GetComponent<Renderer>().material.color = Color.white;
            _gameManager.SelectPhase = false;
        }
    }
}
