using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMSwitcher : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    // Enum representing the list of available cameras
    public enum CurrentCameraList
    {
        FollowBall,
        ViewTower,
        ViewPachinko
    }

    // Method to switch camera state based on the enum value
    public void SwitchState(CurrentCameraList curCam)
    {
        switch(curCam)
        {
            case CurrentCameraList.FollowBall:
                _animator.Play("FollowBall");
                break;
                
            case CurrentCameraList.ViewTower:
                _animator.Play("ViewTower");
                break;
                
            case CurrentCameraList.ViewPachinko:
                _animator.Play("ViewPachinko");
                break;
        }
    }
}
