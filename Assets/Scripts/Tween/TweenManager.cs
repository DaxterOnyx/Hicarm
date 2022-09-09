using System.Collections.Generic;
using UnityEngine;

namespace Tween
{
    public class TweenManager : MonoBehaviour
    {
        private static TweenManager instance;
        public static TweenManager Instance
        {
            get
            {
                if (instance == null) Debug.LogError("TweenManager is not defined");
                return instance;
            }
        }

        private List<TweenData> datas;

        private void Start()
        {
            instance = this;
            datas    = new List<TweenData>();
        }

        private void Update()
        {
            for (var index = 0; index < datas.Count; index++)
            {
                TweenData tweenData = datas[index];
                if (tweenData.Evaluate())
                {
                    datas.Remove(tweenData);
                }
            }
        }

        internal void AddTweener(ref TweenData data)
        {
            datas.Add(data);
        }
    }

    public static class Tween
    {
        public static TweenData TweenIt(this ref float variable, float start, float end, float duration, TweenData.LerpType type)
        {
            unsafe
            {
                fixed (float* ptr = &variable)
                {
                    var data = new TweenData(ptr, start, end, duration, type);
                    TweenManager.Instance.AddTweener(ref data);
                    return data;
                }
            }
        }
    }

    public struct TweenData 
    {
        private        float    start;
        private        float    end;
        private        float    startedtime;
        private        float    duration;
        private        LerpType type;
        private unsafe float*   setter;

        public unsafe TweenData(float* variable, float start, float end, float duration, LerpType type)
        {
            this.start    = start;
            this.end      = end;
            this.duration = duration;
            this.type     = type;
            startedtime   = Time.time;
            this.setter   = variable;
        }

        public bool Evaluate()
        {
            float ratio;
            float time = Time.time-startedtime;
            float timeRatio = Mathf.Clamp(time / duration, 0, 1);

            switch (type)
            {
                case LerpType.Linear:
                    ratio = timeRatio;
                    break;
                case LerpType.EaseIn:
                    ratio = 1 - Mathf.Cos((timeRatio * Mathf.PI) / 2);
                    break;
                case LerpType.EaseOut:
                    ratio = Mathf.Sin((timeRatio * Mathf.PI) / 2);
                    break;
                case LerpType.EaseInOut:
                    ratio = -(Mathf.Cos(Mathf.PI * timeRatio) - 1) / 2;
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }

            unsafe
            {
                *setter = Mathf.Lerp(start, end, ratio);
            }
            return time > duration;
        }

        public enum LerpType
        {
            Linear,
            EaseIn,
            EaseOut,
            EaseInOut,
        }
    }
}