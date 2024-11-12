using LibGit2Sharp;

namespace GitBuddy;

/// <summary>
/// Represents a Git tag model.
/// </summary>
public class TagModel
{
    readonly Tag _tag;

    /// <summary>
    /// Gets or sets the name of the tag.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the hash of the tag.
    /// </summary>
    public byte[] Hash { get; set; }

    public string HashString { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TagModel"/> class.
    /// </summary>
    /// <param name="tag">The Git tag.</param>
    public TagModel(Tag tag)
    {
        _tag = tag;
        Name = tag.FriendlyName;
        HashString= tag.Target.Sha;
        Hash = Sha256Hash.ComputeSHA256Hash(tag.Target.Sha);
    }
}
