using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyUtility
{
    public class CoroutineDelay
    {
        private float m_fCheckTime;
        private float m_fTimeAmount;
        private float m_fDelay;

        private float m_fStartTime;
        public float NormalizedTime
        {
            get
            {
                return PassedTime * m_fTimeAmount;
                //return m_fCheckTime * m_fTimeAmount;
            }
        }

        private float PassedTime { get { return Time.time - m_fStartTime; } }
        public bool IsEnd
        {
            get
            {
                //if (m_fCheckTime > m_fDelay)
                if (PassedTime - Time.deltaTime > m_fDelay)
                {
                    Reset();
                    return true;
                }
                else
                {
                    m_fCheckTime += Time.deltaTime;
                    return false;
                }

            }
        }

        public void StartDelay()
        {
            m_fStartTime = Time.time;
        }

        public CoroutineDelay()
        {
            SetDelay(0);
        }
        public CoroutineDelay(float _delay)
        {
            SetDelay(_delay);
        }
        public void SetDelay(float _newDelay)
        {
            m_fStartTime = Time.time;
            m_fCheckTime = 0;
            m_fDelay = _newDelay;
            m_fTimeAmount = 1.0f / m_fDelay;
        }
        public void Reset()
        {
            m_fStartTime = Time.time;
            m_fCheckTime = 0;
        }
    }



}
