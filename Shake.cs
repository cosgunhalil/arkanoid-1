using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shake : MonoBehaviour
{
    // ******************************
     public Vector3 Amount = new Vector3(1f, 1f, 0);
        public float Duration = 1;
        public float Speed = 100;
        //animasyonun belirli bir hızda surekli devam etmesindense dalgalı br şekilde bazı kısımlarının bazı kısımlardan daha hızlı geçilmesini sağlıyor
        public AnimationCurve Curve = AnimationCurve.EaseInOut(0, 1, 1, 0);
        public bool DeltaMovement = true;
        protected Camera Camera;
        protected float time = 0;
        protected Vector3 lastPos;
        protected Vector3 nextPos;
        protected bool destroyAfterPlay;
        private void Awake()
        {
            Camera = GetComponent<Camera>();
        }
        public void Shakes()
        {
            ResetCam();
            time = Duration;
        }
        private void LateUpdate()
        {
            if (time > 0)
            {   //sürekli olarak spamlanmasın diye timedan deltatime çıkarılıyor
                time -= Time.deltaTime;
                if (time > 0)
                {
                    //Perlinnoise 0f ile 1f arasında 2D düzlemde random bir vektör üretiyor bu değer titreşimde yeterli etkiyi vermeceğinden bazı değerler ile çarpılıyor
                    nextPos = (Mathf.PerlinNoise(time * Speed, time * Speed * 2) - 0.5f) * Amount.x * transform.right * Curve.Evaluate(1f - time / Duration) +
                              (Mathf.PerlinNoise(time * Speed * 2, time * Speed) - 0.5f) * Amount.y * transform.up * Curve.Evaluate(1f - time / Duration);
                    Camera.transform.Translate(DeltaMovement ? (nextPos - lastPos) : nextPos);
                    lastPos = nextPos;
                }
                else
                {
                    //last frame
                    ResetCam();
                    if (destroyAfterPlay)
                        Destroy(this);
                }
            }
        }
        private void ResetCam()
        {
            //reset the last delta
            Camera.transform.Translate(DeltaMovement ? -lastPos : Vector3.zero);
            //clear values
            lastPos = nextPos = Vector3.zero;
        }
       
    }

