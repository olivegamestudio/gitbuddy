using LibGit2Sharp;

namespace GitBuddy;

/// <summary>
/// Represents a Git commit model.
/// </summary>
public class CommitModel
{
    readonly Commit _commit;

    /// <summary>
    /// Gets or sets the commit message.
    /// </summary>
    public string Message { get; set; 
    }

    /// <summary>
    /// Gets or sets the commit hash.
    /// </summary>
    public byte[] Hash { get; set; }

    public string HashString { get; set; }

    /// <summary>
    /// Gets or sets the author of the commit.
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// Gets or sets the date and time of the commit.
    /// </summary>
    public DateTime CommitDate { get; set; }

    /// <summary>
    /// Gets or sets the list of tags associated with the commit.
    /// </summary>
    public List<TagModel> Tags { get; set; } = new();

    /// <summary>
    /// Gets or sets the list of branches associated with the commit.
    /// </summary>
    public List<BranchModel> Branches { get; set; } = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="CommitModel"/> class.
    /// </summary>
    /// <param name="commit">The Git commit.</param>
    public CommitModel(Commit commit)
    {
        _commit = commit;
        Message = commit.MessageShort;
        Hash = Sha256Hash.ComputeSHA256Hash(commit.Sha);
        HashString = commit.Sha;
        Author = commit.Committer.Name;
        CommitDate = commit.Committer.When.DateTime;
    }
}
