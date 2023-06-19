using UnityEngine;

public class GvrAudioSoundfield : MonoBehaviour
{
    
    // public void Awake()
    // {
    //     if (GetComponent<ResonanceAudioSource>() != null) return;
    //     var resAudioSoundfield = gameObject.AddComponent<ResonanceAudioSource>();
    //     var audioSource = gameObject.GetComponent<AudioSource>();
    //     if (audioSource == null)
    //     {
    //         audioSource = gameObject.AddComponent<AudioSource>();
    //     }
    //     
    //     resAudioSoundfield.bypassRoomEffects = bypassRoomEffects;
    //     resAudioSoundfield.gainDb = gainDb;
    //     audioSource.playOnAwake = playOnAwake;
    //     // See https://resonance-audio.github.io/resonance-audio/develop/unity/getting-started.html#gvraudiosoundfield
    //     audioSource.clip = soundfieldClip0102;
    //     // audioSource.clip = soundfieldClip0304; // TODO How do we handle this
    //     audioSource.loop = soundfieldLoop;
    //     audioSource.mute = soundfieldMute;
    //     audioSource.pitch = soundfieldPitch;
    //     audioSource.priority = soundfieldPriority;
    //     audioSource.spatialBlend = soundfieldSpatialBlend;
    //     audioSource.dopplerLevel = soundfieldDopplerLevel;
    //     audioSource.volume = soundfieldVolume;
    //     audioSource.rolloffMode = soundfieldRolloffMode;
    //     audioSource.maxDistance = soundfieldMaxDistance;
    //     audioSource.minDistance = soundfieldMinDistance;
    // }

    /// Denotes whether the room effects should be bypassed.
    public bool bypassRoomEffects = true;

    /// Input gain in decibels.
    public float gainDb = 0.0f;

    /// Play source on awake.
    public bool playOnAwake = true;

    public AudioClip soundfieldClip0102 = null;

    public AudioClip soundfieldClip0304 = null;

    /// Is the audio clip looping?
    public bool soundfieldLoop = false;

    /// Un- / Mutes the soundfield. Mute sets the volume=0, Un-Mute restore the original volume.
    public bool soundfieldMute = false;

    /// The pitch of the audio source.
    [Range(-3.0f, 3.0f)]
    public float soundfieldPitch = 1.0f;

    /// Sets the priority of the soundfield.
    [Range(0, 256)]
    public int soundfieldPriority = 32;

    /// Sets how much this soundfield is affected by 3D spatialization calculations
    /// (attenuation, doppler).
    [Range(0.0f, 1.0f)]
    public float soundfieldSpatialBlend = 0.0f;

    /// Sets the Doppler scale for this soundfield.
    [Range(0.0f, 5.0f)]
    public float soundfieldDopplerLevel = 0.0f;


    /// The volume of the audio source (0.0 to 1.0).
    [Range(0.0f, 1.0f)]
    public float soundfieldVolume = 1.0f;

    /// Volume rolloff model with respect to the distance.
    public AudioRolloffMode soundfieldRolloffMode = AudioRolloffMode.Logarithmic;

    public float soundfieldMaxDistance = 500.0f;

    public float soundfieldMinDistance = 1.0f;

}
