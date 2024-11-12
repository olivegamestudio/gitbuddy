using LibGit2Sharp;

namespace GitBuddy;

/// <summary>
/// Represents a Git branch model.
/// </summary>
public class BranchModel
{
    readonly Branch _branch;

    /// <summary>
    /// Gets the friendly name of the branch.
    /// </summary>
    public string Name => _branch.FriendlyName;

    /// <summary>
    /// Gets a value indicating whether the branch is remote.
    /// </summary>
    public bool IsRemote => _branch.IsRemote;

    /// <summary>
    /// Gets or sets the list of commits in the branch.
    /// </summary>
    public List<CommitModel> Commits { get; set; } = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="BranchModel"/> class.
    /// </summary>
    /// <param name="branch">The Git branch.</param>
    public BranchModel(Branch branch)
    {
        _branch = branch;

        foreach (Commit c in branch.Commits)
        {
            Commits.Add(new CommitModel(c));
        }
    }

    /// <summary>
    /// Updates the tags for the commits in the branch.
    /// </summary>
    /// <param name="tags">The collection of tags to update.</param>
    public void UpdateTags(IEnumerable<TagModel> tags)
    {
        foreach (CommitModel commit in Commits)
        {
            commit.Tags = tags.Where(tag => tag.Hash == commit.Hash).ToList();
        }
    }
}
