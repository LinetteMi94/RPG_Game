using NAudio.Wave;

namespace RPG_Game.Audio;

/// <summary>
/// Представляет звуковой эффект заклинания.
/// Содержит параметры звука и позволяет воспроизводить его во время применения заклинания.
/// </summary>
public class SpellSound(string hitSound,  string missSound)
{
    private string HitSound { get; } = hitSound;
    private string MissSound { get; } = missSound;

    public void PlayHitSound() => PlaySound(HitSound);
    
    public void PlayMissSound() => PlaySound(MissSound);

    private void PlaySound(string sound)
    {
        using var audioFile = new AudioFileReader(sound);
        using var outputDevice = new WaveOutEvent();

        outputDevice.Init(audioFile);
        outputDevice.Play();

        while (outputDevice.PlaybackState == PlaybackState.Playing)
        {
            Thread.Sleep(100);
        }
    }
}