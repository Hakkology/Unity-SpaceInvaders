using UnityEngine;

[CreateAssetMenu(fileName = "InvaderData", menuName = "Invader/InvaderData")]
public class InvaderData : ScriptableObject
{
    [Header("Animation Settings")]
    [Tooltip("Invader'ın animasyonunda kullanılacak sprite dizisi.")]
    public Sprite[] animationSprites;

    [Tooltip("Animasyonun her kare arasında geçeceği süre (saniye cinsinden).")]
    public float animationTime = 1.0f;
    public int score = 10;
}
