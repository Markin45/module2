using System.Collections.Generic;


public static class TagManager
{
    private static readonly Dictionary<TagType, string> _tags = new Dictionary<TagType, string>
    {
        {TagType.Player, "Player"}
    };

    public static string GetTag(TagType type)
    {
        return _tags[type];
    }
}
