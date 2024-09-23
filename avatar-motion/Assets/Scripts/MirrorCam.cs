using UnityEngine;
using UnityEngine.Video;
using System.Collections.Generic;
using System.IO;

public class MirrorCam : MonoBehaviour
{
    public Camera mirrorCamera; // Reference to the mirror camera
    public RenderTexture renderTexture; // Render texture for the camera
    private bool isRecording = false;
    private string currentClipPath;
    private VideoPlayer videoPlayer;
    private List<string> recordedClips = new List<string>(); // List to store recorded clip paths
    private int currentClipIndex = -1; // Index to track the currently playing clip

    private void Start()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
        videoPlayer.targetCamera = mirrorCamera;
    }

    public void StartRecording()
    {
        if (!isRecording)
        {
            isRecording = true;
            string clipName = $"Clip_{System.DateTime.Now:yyyyMMdd_HHmmss}.mp4";
            currentClipPath = Path.Combine(Application.dataPath, "SavedPlayerClips", clipName);
            recordedClips.Add(currentClipPath); // Add the new clip path to the list
            // Start capturing frames
            Debug.Log("Recording started: " + currentClipPath);
            // Logic to start video capturing (use a third-party library or implement your own)
        }
    }

    public void StopRecording()
    {
        if (isRecording)
        {
            isRecording = false;
            // Logic to stop capturing frames and save video
            Debug.Log("Recording stopped: " + currentClipPath);
        }
    }

    public void PlayLastClip()
    {
        if (recordedClips.Count > 0)
        {
            currentClipIndex = recordedClips.Count - 1; // Set to the last clip
            PlayClip(currentClipIndex);
        }
    }

    public void PlayNextClip()
    {
        if (recordedClips.Count > 0)
        {
            currentClipIndex = (currentClipIndex + 1) % recordedClips.Count; // Cycle through clips
            PlayClip(currentClipIndex);
        }
    }

    private void PlayClip(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < recordedClips.Count)
        {
            videoPlayer.url = recordedClips[clipIndex];
            videoPlayer.Play();
            Debug.Log("Playing clip: " + recordedClips[clipIndex]);
        }
    }

    public void StopPlaying()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
            Debug.Log("Stopped playing clip.");
        }
    }
}