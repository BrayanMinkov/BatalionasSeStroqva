using UnityEngine;
using UnityEngine.Animations;

public class FadeOutStartScene : MonoBehaviour
{
public Animator fadeAnimator;
public string fadeOutTrigger = "FadeOut";


void Start()
{
    fadeAnimator.SetTrigger(fadeOutTrigger);
}
}