using UnityEngine;

public class ClothesSize : MonoBehaviour
{
    public  Size CurrentSize => currentsize;
    [SerializeField] private Size currentsize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
       public enum Size
        {
            S = 0,
            M = 1,
            L = 2,
            XXXL = 3,
        }
    
}

