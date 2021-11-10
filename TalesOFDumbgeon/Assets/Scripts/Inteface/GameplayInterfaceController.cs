using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inteface
{
    public class GameplayInterfaceController : MonoBehaviour
    {

        [SerializeField] private List<RectTransform> icons;
        [SerializeField] private List<RectTransform> banners;
        [SerializeField] private float animationTime;
        [SerializeField] private float hiddenPercent;
        [SerializeField] private RectTransform lifeBar;
        private List<Vector3> _originalPos;
        private List<Vector3> _hiddenPos;
        // Start is called before the first frame update
        void Start()
        {
            _originalPos = new List<Vector3>(banners.Count);
            _hiddenPos = new List<Vector3>(banners.Count);
            foreach (var banner in banners)
            {
                Vector3 original = banner.anchoredPosition;
                _originalPos.Add(original);
                int modX = 1;
                if (original.x < 0) modX = -1;
                _hiddenPos.Add(new Vector3(original.x + (banner.sizeDelta.x * hiddenPercent * modX), original.y, original.z));
            }
            MostrarUI(false);
        }

        public void UpdateLife(float amount)
        {
            //Debug.Log(amount);
            amount = Mathf.Clamp01(amount);
            //Debug.Log(amount);
            StartCoroutine(nameof(UpdateHealthBar), amount);
        }

        IEnumerator UpdateHealthBar(float amount)
        {
            float distance = amount - lifeBar.localScale.x;
            float timeElapsed = 0f;
            while (timeElapsed<=animationTime)
            {
                float step = distance / animationTime * Time.deltaTime;
                float newX = lifeBar.localScale.x + step;
                //if (step > 0 && newX < amount) newX = amount;
                //if (step <= 0 && newX > amount) newX = amount;
                lifeBar.localScale = new Vector3(newX, 1, 1);
                timeElapsed += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            lifeBar.localScale = new Vector3(amount, 1, 1);
            yield return null;
        }
        public void MostrarUI(bool activated)
        {
            Debug.Log("Mostrar UI: " + activated);
            StartCoroutine(nameof(OcultarBanners), activated);
        }

        IEnumerator OcultarBanners(bool activated)
        {
            Debug.Log("Ocultando");
            float elapsedTime = 0f;
            while (elapsedTime<animationTime)
            {
                for (int i = 0; i < banners.Count; i++)
                {
                    float relativeDistance = Mathf.Abs(_hiddenPos[i].x) -Mathf.Abs(_originalPos[i].x);
                    float step = relativeDistance / animationTime * Time.deltaTime;
                    int mult = 1;
                    if (_originalPos[i].x < 0) mult = -1;
                    if (activated) mult *= -1;
                    Vector3 originalPos = banners[i].anchoredPosition;
                    banners[i].anchoredPosition =
                        new Vector3(originalPos.x + step * mult, originalPos.y, originalPos.z);
                }
                for (int i = 0; i < icons.Count; i++)
                {
                    float relativeDistance = 1;
                    if (!activated) relativeDistance = -1;
                    float step = relativeDistance / animationTime * Time.deltaTime;
                    Vector3 originalSize = icons[i].localScale;
                    icons[i].localScale =
                        new Vector3(originalSize.x + step , originalSize.y + step, originalSize.z);
                }
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            
            //MakeSure the UI elements are in place.
            foreach (var icon in icons)
            {
                if (activated)
                    icon.localScale = Vector3.one;
                else
                    icon.localScale = Vector3.zero;
            }
            for(int i = 0; i< banners.Count; i++)
            {
                if (activated)
                    banners[i].anchoredPosition = _originalPos[i];
                else
                    banners[i].anchoredPosition = _hiddenPos[i];
            }
            yield return null;
        }
    }
}
