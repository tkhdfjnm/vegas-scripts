// FadeIn FadeOut proessing

using System.Windows.Forms;
using ScriptPortal.Vegas;

public class EntryPoint {
    private static readonly double FadeInMS = 50.0; // CHANGE HERE
    private static readonly CurveType FadeInCurve = CurveType.Fast; // CHANGE HERE
    private static readonly double FadeOutMS = 50.0; // CHANGE HERE
    private static readonly CurveType FadeOutCurve = CurveType.Slow; //CHANGE HERE

    public void FromVegas(Vegas vegas) {
        Timecode FadeInTimecode = Timecode.FromMilliseconds(FadeInMS);
        Timecode FadeOutTimecode = Timecode.FromMilliseconds(FadeOutMS);

        foreach (Track track in vegas.Project.Tracks) {
            if (track.Selected) {
                foreach (TrackEvent evnt in track.Events) {
                    if (evnt.Selected) {
                        evnt.FadeIn.Length = FadeInTimecode;
                        evnt.FadeIn.Curve = FadeInCurve;
                        evnt.FadeOut.Length = FadeOutTimecode;
                        evnt.FadeOut.Curve = FadeOutCurve;
                    }
                }
            }
        }
    }
}
