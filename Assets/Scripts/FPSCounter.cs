using System;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text _mLabelFPS = null;

    private int _mRenderCount = 0;
    private DateTime _mRenderTimer = DateTime.MinValue;

    void OnRenderObject()
    {
        ++_mRenderCount;

        if (_mRenderTimer < DateTime.Now)
        {
            _mRenderTimer = DateTime.Now + TimeSpan.FromSeconds(1);
            if (_mLabelFPS)
            {
                _mLabelFPS.text = string.Format("FPS: {0}", _mRenderCount);
            }
            _mRenderCount = 0;
        }
    }
}