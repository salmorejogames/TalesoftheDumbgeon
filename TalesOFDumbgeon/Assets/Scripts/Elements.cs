

using UnityEngine;

public static class Elements 
{
    public enum Element
        {
            Normal = -1,
            Caos=0,
            Brisa=1,
            Copo=2,
            Guijarro=3,
            Brasa=4
        }
        
        public static float GetElementMultiplier(Element starter, Element objetive)
        {
            //Debug.Log((int) objetive + " " + ((int) starter + 2 % 5));
            if(starter==Element.Normal || objetive == Element.Normal)
                return 1;
            
            //Debug.Log("Objetive: " +  ((int) objetive) + " Starter: " + (((int) starter + 2) % 5));
            if ((int) objetive == (((int) starter + 2) % 5))
                return 2;
            if ((int) starter == (((int) objetive + 2) % 5))
                return 0.5f;
            
            return 1;
        }

        public static Element GetCounter(Element baseElement)
        {
            if (baseElement == Element.Normal)
                return Element.Normal;
            else
                return (Element) (((int) baseElement + 2) % 5);
        }

        public static Element GetRandomElement()
        {
            int opcion = Random.Range(-1, 5);
            return (Element) opcion;
        }
        
}
