using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Colours
{
    
    private static Vector4[] reds = { new Vector4(0.7960785f, 0, 0, 1), new Vector4(0.5176471f, 0, 0, 1), new Vector4(0.3882353f, 0.01176471f, 0.01960784f, 1) };
    private static Vector4[] blues = { new Vector4(0.1764706f, 0.5764706f, 0.8431373f, 1), new Vector4(0.01960784f, 0.3490196f, 0.572549f, 1), new Vector4(0.007843138f, 0.2705882f, 0.4470589f, 1) };
    private static Vector4[] greens = { new Vector4(0.4705883f, 0.7058824f, 0, 1), new Vector4(0.282353f, 0.4980392f, 0, 1), new Vector4(0.2117647f, 0.3803922f, 0.02745098f, 1) };
    private static Vector4[] yellows = { new Vector4(0.9882354f, 0.8666667f, 0.003921569f, 1), new Vector4(0.8392158f, 0.5882353f, 0, 1), new Vector4(0.5333334f, 0.4f, 0.03137255f, 1) };
    private static Vector4[] pinks = { new Vector4(0.9882354f, 0.3803922f, 0.4470589f, 1), new Vector4(0.8039216f, 0.1882353f, 0.2470588f, 1), new Vector4(0.6039216f, 0.01176471f, 0.05882353f, 1) };


    public static readonly Dictionary<EnumColours, Vector4[]> coloursDictionary = new Dictionary<EnumColours, Vector4[]>()
    {
        {EnumColours.Red, reds},
        {EnumColours.Blue, blues },
        {EnumColours.Green, greens },
        {EnumColours.Yellow, yellows },
        {EnumColours.Pink, pinks }
    };
    
    
}
public enum EnumColours
{
    Red,
    Blue,
    Green,
    Yellow,
    Pink,
    Black,
    White
}