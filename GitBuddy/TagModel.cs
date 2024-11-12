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
    public string Hash { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TagModel"/> class.
    /// </summary>
    /// <param name="tag">The Git tag.</param>
    public TagModel(Tag tag)
    {
        _tag = tag;
        Name = tag.FriendlyName;
        Hash = tag.Target.Sha;
    }
}
