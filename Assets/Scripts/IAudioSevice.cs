using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudioService
{
    void ShootSound();
    void BackgroundMusic();
    void HitSound();
    void HealSound();
    void StopBackgroundMusic();
}