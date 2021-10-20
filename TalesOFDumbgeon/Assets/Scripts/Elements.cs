

using UnityEngine;

public static class Elements 
{
    public enum Element
        {
            Caos=0,
            Brisa=1,
            Copo=2,
            Guijarro=3,
            Brasa=4
        }
        
        public static float GetElementMultiplier(Element starter, Element objetive)
        {
            Debug.Log((int) objetive + " " + ((int) starter + 2 % 5));
            if ((int) objetive == ((int) starter + 2 % 5))
                return 2;
            if ((int) starter == ((int) objetive + 2 % 5))
                return 0.5f;
            
            return 1;
        }
        
}
