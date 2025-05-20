namespace ScaleGenerator.Tests;
using ScaleGenerator;

public class ScaleGeneratorTests
{
    [Fact]
    public void Chromatic_scales_chromatic_scale_with_sharps()
    {
        string[] expected = ["C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"];
        Assert.Equal(expected, Scale.Chromatic("C"));
    }
    [Fact]
    public void Chromatic_scales_chromatic_scale_with_flats()
    {
        string[] expected = ["F", "Gb", "G", "Ab", "A", "Bb", "B", "C", "Db", "D", "Eb", "E"];
        Assert.Equal(expected, Scale.Chromatic("F"));
    }
    [Fact]
    public void Scales_with_specified_intervals_simple_major_scale()
    {
        string[] expected = ["C", "D", "E", "F", "G", "A", "B", "C"];
        Assert.Equal(expected, Scale.Interval("C", "MMmMMMm"));
    }
    [Fact]
    public void Scales_with_specified_intervals_major_scale_with_sharps()
    {
        string[] expected = ["G", "A", "B", "C", "D", "E", "F#", "G"];
        Assert.Equal(expected, Scale.Interval("G", "MMmMMMm"));
    }
    [Fact]
    public void Scales_with_specified_intervals_major_scale_with_flats()
    {
        string[] expected = ["F", "G", "A", "Bb", "C", "D", "E", "F"];
        Assert.Equal(expected, Scale.Interval("F", "MMmMMMm"));
    }
    [Fact]
    public void Scales_with_specified_intervals_minor_scale_with_sharps()
    {
        string[] expected = ["F#", "G#", "A", "B", "C#", "D", "E", "F#"];
        Assert.Equal(expected, Scale.Interval("f#", "MmMMmMM"));
    }
    [Fact]
    public void Scales_with_specified_intervals_minor_scale_with_flats()
    {
        string[] expected = ["Bb", "C", "Db", "Eb", "F", "Gb", "Ab", "Bb"];
        Assert.Equal(expected, Scale.Interval("bb", "MmMMmMM"));
    }
    [Fact]
    public void Scales_with_specified_intervals_dorian_mode()
    {
        string[] expected = ["D", "E", "F", "G", "A", "B", "C", "D"];
        Assert.Equal(expected, Scale.Interval("d", "MmMMMmM"));
    }
    [Fact]
    public void Scales_with_specified_intervals_mixolydian_mode()
    {
        string[] expected = ["Eb", "F", "G", "Ab", "Bb", "C", "Db", "Eb"];
        Assert.Equal(expected, Scale.Interval("Eb", "MMmMMmM"));
    }
    [Fact]
    public void Scales_with_specified_intervals_lydian_mode()
    {
        string[] expected = ["A", "B", "C#", "D#", "E", "F#", "G#", "A"];
        Assert.Equal(expected, Scale.Interval("a", "MMMmMMm"));
    }
    [Fact]
    public void Scales_with_specified_intervals_phrygian_mode()
    {
        string[] expected = ["E", "F", "G", "A", "B", "C", "D", "E"];
        Assert.Equal(expected, Scale.Interval("e", "mMMMmMM"));
    }
    [Fact]
    public void Scales_with_specified_intervals_locrian_mode()
    {
        string[] expected = ["G", "Ab", "Bb", "C", "Db", "Eb", "F", "G"];
        Assert.Equal(expected, Scale.Interval("g", "mMMmMMM"));
    }
    [Fact]
    public void Scales_with_specified_intervals_harmonic_minor()
    {
        string[] expected = ["D", "E", "F", "G", "A", "Bb", "Db", "D"];
        Assert.Equal(expected, Scale.Interval("d", "MmMMmAm"));
    }
    [Fact]
    public void Scales_with_specified_intervals_octatonic()
    {
        string[] expected = ["C", "D", "D#", "F", "F#", "G#", "A", "B", "C"];
        Assert.Equal(expected, Scale.Interval("C", "MmMmMmMm"));
    }
    [Fact]
    public void Scales_with_specified_intervals_hexatonic()
    {
        string[] expected = ["Db", "Eb", "F", "G", "A", "B", "Db"];
        Assert.Equal(expected, Scale.Interval("Db", "MMMMMM"));
    }
    [Fact]
    public void Scales_with_specified_intervals_pentatonic()
    {
        string[] expected = ["A", "B", "C#", "E", "F#", "A"];
        Assert.Equal(expected, Scale.Interval("A", "MMAMA"));
    }
    [Fact]
    public void Scales_with_specified_intervals_enigmatic()
    {
        string[] expected = ["G", "G#", "B", "C#", "D#", "F", "F#", "G"];
        Assert.Equal(expected, Scale.Interval("G", "mAMMMmm"));
    }
}
